using System;
using System.Diagnostics;
using System.Threading;
using assignment2_445;

namespace assignment2_445
{
    public delegate void priceCutEvent(double price_old, double price_new, string senderID, string receiverID);   //Declaring Pricecut event 
    public delegate void orderSucceedEvent(string senderId, int cardNo, string receiverID, int quantity, double price);
    public class Program
    {

        public static Thread[] t;

        //We don't need have outside input
        static void Main(string[] args)
        {
            //Declaring the Cruise threads and starting both.
            Cruise1 b = new Cruise1("1");       //creating a Cruise1 class ship, ID:1
            Cruise2 d = new Cruise2("2");       //creating a Cruise2 class ship, ID:2
            Thread C1 = new Thread(new ThreadStart(b.price_update));          //creating thread to make cruise1's price up and donw
            Thread C2 = new Thread(new ThreadStart(d.price_update));            //creating thread to make cruise1's price up and donw
            C1.Start();            //start!
            C2.Start();

            /*
             *
             * Creating the parent thread of ordering processes for each.
             * In that place,the parent thread will keep watch Semaphore all the time. Once the 
             * semaphore relase, the parent thread will create his child thread to process it.
            */
            OrderProcessing pc1 = new OrderProcessing("1");
            OrderProcessing pc2 = new OrderProcessing("2");

            Thread pt1 = new Thread(new ThreadStart(pc1.startingPoint1));
            Thread pt2 = new Thread(new ThreadStart(pc2.startingPoint2));
            pt1.Start();
            pt2.Start();

            //event drive:


            TicketAgent agent = new TicketAgent();
            int agentNum = 5;   //number of agent

            t = new Thread[agentNum];   //Creat thread
            for (int i = 0; i < agentNum; i++) //Start N retailer threads
            { 
                t[i] = new Thread(new ThreadStart(agent.AgentSleep)); //starts thread with random time
                t[i].Name = (i + 1).ToString();         //Name each agent thread : 1,2,3,4,5
                t[i].Start();   //start agent thread
            }


            /*            //Create the instances of TicketAgents and run the thread:
                        TicketAgent a1 = new TicketAgent("1", 0.3, 5032);
                        TicketAgent a2 = new TicketAgent("2", 0.1, 6321);
                        TicketAgent a3 = new TicketAgent("3", 0.2, 6132);
                        TicketAgent a4 = new TicketAgent("4", 0.22, 6700);
                        TicketAgent a5 = new TicketAgent("5", 0.21, 6100);

                        Thread t1 = new Thread(new ThreadStart(a1.AgentSleep));
                        Thread t2 = new Thread(new ThreadStart(a2.AgentSleep));
                        Thread t3 = new Thread(new ThreadStart(a3.AgentSleep));
                        Thread t4 = new Thread(new ThreadStart(a4.AgentSleep));
                        Thread t5 = new Thread(new ThreadStart(a5.AgentSleep));

                        t1.Name = a1.AgentID;
                        t2.Name = a2.AgentID;
                        t3.Name = a3.AgentID;
                        t4.Name = a4.AgentID;
                        t5.Name = a5.AgentID;
                        t1.Start(); t2.Start(); t3.Start(); t4.Start(); t5.Start();*/


            Cruise.priceCut += new priceCutEvent(agent.recvOrder);   // When a price drop event occurs, call agent method to start creating order
            OrderProcessing.orderSucceed += new orderSucceedEvent(agent.orderSucceed);  //When order is valid, notify agents to confirmation order.
        }
    }
}


