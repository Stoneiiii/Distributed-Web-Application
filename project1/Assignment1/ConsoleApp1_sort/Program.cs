using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceRef1.ServiceClient myProxy = new ServiceRef1.ServiceClient();    //creat new method by calling servive
            string str = "5235252,3633,2,3,1,99";   
            string str_sorted = myProxy.sort(str);  //call sort method in service
            Console.WriteLine("{0} sort in ascending order is {1}", str, str_sorted);
            myProxy.Close();    //always close~
        }
    }
}
