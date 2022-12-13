using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_445
{
    public class OrderProcessing
    {
        public static event orderSucceedEvent orderSucceed; 

        //The thread may be blocked here.
        private String curiseName;

        public OrderProcessing(string curiseName)
        {
            this.curiseName = curiseName;
        }

        /*
            Description:
            This will traverse the three cells to get the order matching the right curiseID;
            Notes: This may fetch an Null order since multiThreading, however it will not cause any duplicate order confirmation.
         
         */
        //The thread may blocked in here since it will try to access the cells after getting the Semaphore
        public OrderClass getOrder(string curiseID)
        {
            OrderClass newOrder = null;
            for (int i = 0; i < 3; i++)
            {
                newOrder = MultiCellBuffer.getOneOrder(i, curiseID);   //"1" is for test
                if (newOrder != null)
                {
                    i = 3;
                }
            }
            return newOrder;

        }

        //This is the place the parent thread of OrderProcessing create the child thread to deal with the order in cells.
        public void runOrder()
        {
            Thread thread = new Thread(new ThreadStart(OrderRunning));
            thread.Start();
        }


        /*
         Description:
         This is the starting point for the thread which is belong to Cruise1;
         Functions: The thread will blocked untill some ticketagent put the Cruise1's order into the buffer cell, by using the Semaphores;
         
         Future Improvement: the true keyword should be modified into the judgment condition statement which can tell if the cruise processes  are terminated.
         */
        public void startingPoint1()
        {
            while(true)
            {
                MultiCellBuffer._consumer1Pool.WaitOne();
                runOrder();
            }
        }



        /*
         Description:
         This is the starting point for the thread which is belong to Cruise2;
         The functions are same as startingPoing1() as below.

        */
        public void startingPoint2()
        {
            while (true)
            {
                MultiCellBuffer._consumer2Pool.WaitOne();
                runOrder();
            }

        }

        //Functions: Get order from cells and check if the order illegal. Confirmation will done in this method
        //It will checking if the order illegal in this function.
        public void OrderRunning()
        {
            //Once it get the order, it will release the Semaphore to allow the ticketagent thread continue put orders in cells.
            var order = getOrder(this.curiseName);
            MultiCellBuffer._producerPool.Release();
            if (order == null)
            {
                Console.WriteLine("Order is empty");
                return;
            }

            //string senderId = orderClass.SenderId;
            int cardNo = order.CardNo;
            string receiverID = order.ReceiverID;
            int quantity = order.Quantity;
            string senderId = order.SenderId;
            double price = order.Price;

            if (checkcardNo(cardNo) && cheackqty(receiverID, quantity))
            {
                orderSucceed(senderId, cardNo, receiverID, quantity, price);
                //Console.WriteLine("The order was confirmed");
            }
            else
            {
                Console.WriteLine("Order cancell due to the invalid order");
            }

        }


        public static bool checkcardNo(int cardNo)
        {
            if (cardNo >= 5000 && cardNo <= 7000)
            {
                return true;
            }
            Console.WriteLine("Wrong Card Number");
            return false;
        }

        public static bool cheackqty(string receiverID, int quantity)
        {
            //string CruiseId = "Cruise" + receiverID;

            int num = -1;
            switch (Convert.ToInt32(receiverID))
            {
                case 1: num = Cruise1.ticket_num;
                    break;
                case 2: num = Cruise2.ticket_num;
                    break ;
                default: Console.WriteLine("Wrong Cruise's Name");
                    return false;
            }

            if (num == -1)
            {
                Console.WriteLine("Wrong ticket Number！");
                return false;
            }


            if (quantity > num)
            {
                Console.WriteLine("Cruise{0} don't have enough tickets！", receiverID);
                return false;
            }

            switch (Convert.ToInt32(receiverID))
            {
                case 1:
                    Cruise1.ticket_num = num - quantity;
                    break;
                case 2:
                    Cruise2.ticket_num = num - quantity;
                    break;
                default:
                    Console.WriteLine("Wrong Cruise's Name");
                    return false;
            }

            return true;
        }


        

    }
}
