using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_445
{
    //Cruise is responsible for doing the price calculate, and triger the submitting orders from ticketAgents
    public class Cruise
    {
        public static event priceCutEvent priceCut; // Declaring delegate event to link pricecut
        public static double price = 100;    //Starting price
        public int cut_Max = 20;    //Maximum number of price reductions(20 times as required) 
        public int cut_count = 1;    //Initial Price Reduction Calculation
        public static int ticket_num = 100;  //The number of initialized tickets is limited to a maximum of 100


        //public static event priceCutEvent priceCut; //绑定priceCutEvent event事件

        public string Cruise_Name { get; set; }
        public Cruise(string cruise_Name)
        {
            this.Cruise_Name = cruise_Name;
        }

        //returns the ID of Curise
        //type: string
        public String showID()  
        {
            //Console.WriteLine("My Cruse ID is {0}", Cruise_Name);
            return Cruise_Name;
        }


        /*        //返回票价
                //类型：int
                public static int getprice()
                {
                    return price;
                }

        */
        //returns the number of tickets
        //type: int
        public static int getticketnum()
        {
            return ticket_num;
        }






        //price change
        //1. Price drop: add +1 to the price drop counter, trigger a price drop event, update the fare
        //2. Price increase, update ticket price
        public void price_change(double price_old, double price_new)
        {
            Random r = new Random();     // Generate random numbers
            int id = r.Next(0, 5);       // Random notification of price drop events to an agent
            if (cut_count <= cut_Max && price_new < price_old)   // The price was lowered, and the number of times it was lowered was not reached, triggering a price drop event
            {

                priceCut(price_old, price_new, Program.t[id].Name, showID());    // Trigger price reduction event
                //Console.WriteLine("\r\nCruise{3}号降价发生次数： {0} 之前价格是：{1},降价后：{2}\r\n", cut_count, price_old, price_new, showID());
                cut_count++;    //Number of reductions +1 
            }
            if (cut_count > cut_Max)    //pricecuts event are done, prepare to stop program.
            {
                Console.WriteLine("The price reduction event is over!!! Stop submitting orders.");
                Console.WriteLine("The program will be terminated after 5 seconds");
                Thread.Sleep(5000);
                System.Environment.Exit(0);         //pricecut events are done stop all threads and quit
            }
            //price = price_new;   //更新票价

        }


        //son class will rewritte this method by using different price model价格改变方法，下面子类要重写此方法
        public virtual void price_update()
        {

            Random r = new Random();   
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(500);
                double price_new = r.Next(40, 200);
                Console.WriteLine("The current price is：{0}", price_new);
                price_change(price, price_new);
                price = price_new;
            }
        }
    }
}
