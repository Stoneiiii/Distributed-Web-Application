using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_445
{
    
    public class Cruise2 : Cruise
    {
        public static new double price = 100;      //price for son class Cruise2 
        public static double price_init = 100; //Each cruise has its own initial price setting
        public static int ticket_num_new = 100; //latest number of the tickets (when an order appears, refresh this value)
        public static int ticket_num_old = 100; //previous number of previous tickets (the number before the order appeared)
        public static new int ticket_num = 100; //number of tickets for son class Cruise2

        public Cruise2(string cruise_Name) : base(cruise_Name)  //Initialize son class
        {
            this.Cruise_Name = cruise_Name;
        }




        //price_new = Own price*（1-（Own price-Cruise1's price）/Cruise1's price）if Cruise1's price is high than myself, Raise the price, and conversely decrease the price
        //If an order is generated, ignoring the above formula, the ticket price is changed as follows:
        ///price_new = price + （1-ticket_num_old/ticket_num）*ticket_num   Fewer remaining tickets, price increase~
        public override void price_update()
        {
            for (int i = 0; i < 60; i++)
            {
                Thread.Sleep(500);
                double price_new;
                if (ticket_num_new != ticket_num_old)       // price changed, when ticket number changed
                {
                    price_new = price + (1 - (double)ticket_num_new / (double)ticket_num) * (double)price_init;
                }
                else     //price changed by cruise1's price
                {
                    double Cruise1_price = Cruise1.price;
                    //int Cruise1_price = Cruise1.getprice();
                    price_new = price * (1 - (((double)price - (double)Cruise1_price) / (double)Cruise1_price));
                }
                //Console.WriteLine("Cruise{1}号先前的价格是：{2}，当前价格是：{0}  ", price_new, showID(), price);
                price_change(price, price_new);
                price = price_new;
            }
            Console.WriteLine("Cruise 2's price reduction is over!!");
        }
    }
}
