using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            ServiceRef1.ServiceClient myProxy = new ServiceRef1.ServiceClient();    //creat new method by calling servive
            int f = 11;
            int c = 11;
            int f2c = myProxy.f2c(f);   //call Fahrenheit to Celsius method
            int c2f = myProxy.c2f(c);   //call Celsius to Fahrenheit method
            Console.WriteLine("{0}F is {2}C \n{1}C is {3}F", f, c, f2c, c2f); 
            myProxy.Close();

        }
    }
}
