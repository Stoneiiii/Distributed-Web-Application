using assignment2_445;
using System;
using System.Threading;


namespace assignment2_445
{

	//可优化的点还是很多的
	public class MultiCellBuffer
	{

		private static OrderClass[] Cells = new OrderClass[3];     //Only references here;

		//The lock and Semaphores are declared at the class level so that it is visible to all threads.
		public static Semaphore _producerPool = new Semaphore(3, 3);  //This indicates how many empty cells in this buffercell in real time.
		public static Semaphore _consumer1Pool = new Semaphore(0, 3); //This semaphore can implement Synchronization mechanism that can tell Cruise1 orderprocessing thread to dealwith
        public static Semaphore _consumer2Pool = new Semaphore(0, 3); //This will tell Cruise2 if there are order for him.

		//This lock object will be applied to each cell. 
		public static ReaderWriterLock rwl = new ReaderWriterLock();



		//To Lookup if the cell is empyty;
		public static bool isCellNULL(int index)
		{
			bool temp = false;
			rwl.AcquireReaderLock(-1);			//Only read require
			temp = (Cells[index] == null);
			rwl.ReleaseLock();

			return temp;

		}


		//Try to put the order into the empyty cell.
		public static void addOrdertoCell(OrderClass order)
		{
			for (int i = 0; i < 3; i++)
			{
				if (isCellNULL(i))
				{
					rwl.AcquireWriterLock(-1);  //Read firstly, only the cell is empty, then acquire WriterLock that will boost performance
					Cells[i] = order;			//Put the order into the cell
					rwl.ReleaseLock();
					break;
				}
			}
		}






		//Warning:Thread can be blocked here
		//Attention：No try except final statement
		public static OrderClass getOneOrder(int cellIndex, string curiseID)
		{
			OrderClass temp = null;
			rwl.AcquireReaderLock(-1);
			if (!isCellNULL(cellIndex))
			{
				if (Cells[cellIndex].ReceiverID == curiseID)
				{
					rwl.ReleaseLock();
					/*
					 * The thread can be blocked here and the order can be fetched
					 * by another thread, but it doesn't matter, the orderprocessing will consider it invalid and do
					 * nothing on it.
					 */
					rwl.AcquireWriterLock(-1);
					temp = Cells[cellIndex];
					Cells[cellIndex] = null;

				}
			}
			rwl.ReleaseLock();


			return temp;            //if it is not null, this is must be the oder submitting to the curiseID
		}



	}
}
