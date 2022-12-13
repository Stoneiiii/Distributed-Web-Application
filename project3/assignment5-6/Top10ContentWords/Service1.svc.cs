using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace Top10ContentWords
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Dictionary<string, int> CountWord(string str)
        {
            //remove XML tags and attributes and HTML tags
            string pattern = "\\<.[^<>]*\\>";   //This is a Regular Expression to all something like <...>
            str = Regex.Replace(str, pattern, " "); //Using Regular Expression to replace <...> by blank, 'cause XML or HTML file may don't have blank.


            Dictionary<string, int> word_dic = new Dictionary<string, int>();   //Creat dictionary to store word and word frequency
            string[] words = Regex.Split(str, @"\W+");  //Using Regular Expression, split the string into each word, and remove punctuation.

            foreach (var word in words) //count word frequency
            {
                if (word == "")
                    continue;
                
                if (word_dic.ContainsKey(word))
                {

                    word_dic[word]++;
                }
                else
                {
                    word_dic[word] = 1;
                }
            }

            return word_dic;
        }


        //List<String>
        public List<string> Top10word(Dictionary<string, int> dic)
        {
            //Dictionary<string, int> test = new Dictionary<string, int>();

            List<string> top10word = new List<string>();    //Creat a list to store top 10 words
            //sort word dictionary by value
            Dictionary<string, int> sorted_word_dic = dic.OrderByDescending(r => r.Value).ToDictionary(r => r.Key, r => r.Value);   
            //Store Top 10 word in list
            foreach (KeyValuePair<string, int> kvp in sorted_word_dic.Take(10))
            {
                top10word.Add(kvp.Key);
                //test.Add(kvp.Key, kvp.Value); 
            }
            

            return top10word;
        }

        //Integrate 2 methods
        public List<string> GetTop10(string str)
        {
            return Top10word(CountWord(str));
        }

    }
}
