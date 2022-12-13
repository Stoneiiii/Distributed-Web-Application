using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Top10ContentWords
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Dictionary<string, int> CountWord(string str);  //Count frequency of each word in the string.

        [OperationContract]
        List<string> Top10word(Dictionary<string, int> dic);    //return top10 word frequency according method CountWord

        [OperationContract]
        List<string> GetTop10(string str); //Integrate the above 2 methods to return top10 word
        
    }


    

}
