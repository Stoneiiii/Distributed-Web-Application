using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace TryIt_wordfilter
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //Show user input in Label2
            Label2.Text = TextBox1.Text;

            //Calling Wordfilter Restful Service
            string url = "http://webstrar86.fulton.asu.edu/page0/api/wordfilter?str=";
            using (WebClient wc = new WebClient())
            {
                string res = wc.DownloadString(url + TextBox1.Text);    //recieve data
                Label1.Text = res;  //show result in Label1
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            client_top10.Service1Client myproxy= new client_top10.Service1Client();

            string str = TextBox2.Text;
            List<string> res = new List<string>(myproxy.GetTop10(str));
            for(int i = 0; i < res.Count; i++)
            {
                res[i] = (i+1).ToString() + ". " + res[i];
            }

            Label3.Text = String.Join(" ", res);


        }
    }
}