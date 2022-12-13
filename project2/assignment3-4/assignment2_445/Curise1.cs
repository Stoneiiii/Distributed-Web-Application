using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_445
{
    //todo Curise1 继承Curise 重写price_update 方法。
    // One generates a discount table based on the month: off-peak season, and the time of the ticket purchase: weekday or day off time.
    // Another generates a price dynamically based on the number of tickets remaining, and the time, optionally: the minimum number of tickets required to be purchased (difficult, need to update the number of tickets remaining after receiving an order confirmation request.)
    public class Cruise1 : Cruise
    {
        public static new double price = 100;    //price for son class Cruise1
        public static double price_init = 100;    //Each cruise has its own initial price setting
        public static new int ticket_num = 120; //number of tickets for son class Cruise1

        public static double price_new;     //store new price

        

        public Cruise1(string cruise_Name) : base(cruise_Name)  //Initialize son class
        {
            this.Cruise_Name = cruise_Name;
        }


        //Rewrite the price model, price_new=price*weekly discount*weight 0.5 + price*monthly discount*weight 0.5
        public override void price_update()
        {
            

            for (int i = 0; i < 60; i++)
            {
                Thread.Sleep(500); 
                Random r = new Random();    //
                int day = r.Next(1, 356);   //Number of random days added + initial date = random date
                DateTime d = new DateTime(2022, 1, 1, 0, 0, 0); //Initialize Start Date
                DateTime d2 = d.AddDays(day);   //d2: Random dates
                //Console.WriteLine(d2);
                int week = (int)DateTime.Parse(d2.ToString()).DayOfWeek;   //get week
                int month = (int)DateTime.Parse(d2.ToString()).Month;   //get month


                double price_new = (price_init * day_dis(week) *0.5 + price_init * month_dis(month) * 0.5); //price model
                //Console.WriteLine("Cruise{4} current price：{0} ,{2}month,Week{3},discount before：{1},discount after：{5}", price, (day_dis(week) + month_dis(month))*0.5, month, week, showID(), price_new);
                price_change(price, price_new); //calling father method to tigger pricecut
                price = price_new;
            }
            Console.WriteLine("Cruise 1 price reduction is finished!!!!");       


        }

        //According to the month to determine the discount, off-season 1-6, 10; peak season 7-9, November-December
        // input:int month
        // output:double discount
        public double month_dis(int month)
        {
            if (month > 12 || month < 0) return 1;    // month error, treated as non-discounted
            switch (month)
            {
                case 1: return 0.8;
                case 2: return 0.8;
                case 3: return 0.75;
                case 4: return 0.7;
                case 5: return 0.75;
                case 6: return 0.8;
                case 7: return 1; 
                case 8: return 1.3;
                case 9: return 1.2;
                case 10: return 1.3;
                case 11: return 1.3;
                case 12: return 1.2;
                default: return 1;
            }
        }

        //determine the discount according to the days of the week, 31 days a month.
        //Input:int days
        //output:double discount
        public double day_dis(int time)
        {
            if (time < 0 || time > 31) return 1;
            time = time % 7;    //get day of the week
            switch (time)
            {
                case 1: return 1;
                case 2: return 0.8;
                case 3: return 0.75;
                case 4: return 0.7;
                case 5: return 1;
                case 6: return 1.2;
                case 0: return 1.2;
                default: return 1;
            }
        }




    }
}
