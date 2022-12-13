using assignment2_445;
using System;
using System.Diagnostics;
using System.Threading;

/*
    requirement for class:
Each ticket agent is a thread created by a different object instantiated from the same class
*/

namespace assignment2_445
{
    public class TicketAgent
    {
        private string agentID;
        private double need;       //This is an Imagined market need the TicketAgent predicts,which ranges from (0,1)
        private int cardNo;

        //Create an different need for each agent thread, for creat different ticket number model
        public void setneed()
        {
            Random r = new Random();
            need = r.NextDouble();
        }


        public string AgentID
        {
            get { return agentID; }
            set { agentID = value; }
        }


        //This is the starting point for the TicketAgent thread;
        public void AgentSleep()
        {
            Random r = new Random();
            setneed();
            //Console.WriteLine(need);
            Thread.Sleep(r.Next(5000, 8000));       //This will cause discording starting of the threads.
        }


        //This is very simple model to calculate the number of ticket need to be ordered. However, it can easily be extended.
        private int calQuantity(double priceDiff)
        {

            int quantity = (int)Math.Ceiling((this.need * priceDiff));
            //Console.WriteLine(need);
            return quantity;
        }

        //This the event drive function, will be call by the price changing event.
        public void recvOrder(double price_old, double price_new, string senderID, string receiverID)
        {
            OrderClass newOrder;
            //Here you need to be able to receive the originalPrice, the currentPrice, and the curiseID of the curise

            double originalPrice = price_old;
            double currentPrice = price_new;
            string curiseID = receiverID;
            string agentID = senderID;



            /*            while (true)
                        {
                            Thread.Sleep(1000);
                            double priceDiff = originalPrice - currentPrice;
                            int quantity = calQuantity(priceDiff);
                            if (quantity > 0)
                            {
                                newOrder = new OrderClass(agentID, cardNo, curiseID, quantity, currentPrice);
                                submitOrder(newOrder, curiseID);
                            }
                        }*/
            Random r = new Random();
            cardNo = r.Next(4000, 8000);

            //Model of the number of purchases
            double priceDiff = originalPrice - currentPrice;
            int quantity = calQuantity(priceDiff);
            if (quantity > 0)
            {
                newOrder = new OrderClass(agentID, cardNo, curiseID, quantity, currentPrice);
                
                Console.WriteLine("Agent{0} receive pricecut from Cruise{1}. Start to order", senderID, receiverID);
                submitOrder(newOrder, curiseID);
            }
            else 
            {
                Console.WriteLine("quantity < 0!!!!");
            }
            
            

        }



        //The part contains the codes which try to access the cell
        //Once it finishes the order submitting, it will realse the semaphore accordingly.
        public void submitOrder(OrderClass newOrder, String whichCurise)
        {
            MultiCellBuffer._producerPool.WaitOne();         //Only three orders can be producerd in cells

            //The most critical part in this function
            MultiCellBuffer.addOrdertoCell(newOrder);

            Console.WriteLine("The order was submitted!");

            //Tell curise1 he can go into the cell
            if (whichCurise == "1")
            {
                MultiCellBuffer._consumer1Pool.Release();
            }
            else
            {
                MultiCellBuffer._consumer2Pool.Release();   //Tell curise2 he can go into the cell
            }

            //Not sure if this will cause the Deadlock or liveLock
        }

        //agent receive confirmation by event drived and than print the order information.
        public void orderSucceed(string senderId, int cardNo, string receiverID, int quantity, double price)
        {
            Console.WriteLine("Agent:{0} ,cardnum:{1}, Cruise:{2}， ticketnum:{3}, price:{4} ", senderId, cardNo, receiverID, quantity, price);//order succeed
        }

    }
}