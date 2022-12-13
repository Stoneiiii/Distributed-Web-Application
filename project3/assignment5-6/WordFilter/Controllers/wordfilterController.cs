using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Xml.Linq;

namespace WordFilter.Controllers
{
    public class wordfilterController : ApiController
    {
        public string Get(string str)
        {
            //remove XML tags and attributes
            string pattern = "\\<.[^<>]*\\>";   //This is a Regular Expression to match XML tags and attribute names
            str = Regex.Replace(str, pattern, " "); //Using Regular Expression to replace XML tag and attribute names by blank, cause XML file may don't have blank.

            //Convert the input string to a list
            List<string> strlist = new List<string>(str.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries));

            //Read the English Stop Words from the local TXT document and store them in the list
            List<string> stopwords = new List<string>();
            try
            {
                string dir = AppDomain.CurrentDomain.BaseDirectory + "stop_words_english.txt";  //Get local project directory
                string[] lines = File.ReadAllLines(dir);    //Read txt

                foreach (string line in lines)
                {
                    stopwords.Add(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ "stop_words_english.txt can't found");
            }

            //Remove stop word
            List<string> res = strlist.Except(stopwords).ToList();
            str = String.Join(" ", res);    //Convert List to String

            return str;
        }
    }
}
