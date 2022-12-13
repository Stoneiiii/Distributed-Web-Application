using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public string sort(string s)
    {
        string [] str_arr = s.Split(',');    //Creat string arrays separated by commas. 
        long[] int_arr = Array.ConvertAll<string, long>(str_arr, z => long.Parse(z)); //string arrays => integral numeric arrays
        Array.Sort(int_arr);    //sort number
        string str_sorted = string.Join(",", int_arr);  //sorted integral numeric arrays => comma-separated string
        return str_sorted;  
    }
}
