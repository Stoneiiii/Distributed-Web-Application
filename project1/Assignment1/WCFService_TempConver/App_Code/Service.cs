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
    //Celsius to Fahrenheit
    public int c2f(int c)
    {
        double f = (double)9 * c / 5 + 32;  //use doule type for rounding 
        int res = Convert.ToInt32(Math.Round(f, 0, MidpointRounding.AwayFromZero)); //rounding
        return res;
    }

    //Fahrenheit to Celsius
    public int f2c(int f)
    {
        double c = (double)5 * (f - 32) / 9;
        int res = Convert.ToInt32(Math.Round(c, 0, MidpointRounding.AwayFromZero));
        return res;
    }
}
