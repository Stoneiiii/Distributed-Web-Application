using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace web
{
    public partial class _Default : Page
    {
        public string ip;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get user IP, but we conncect WebStart Server through VPN, So It dosen't work.
            HttpRequest request = HttpContext.Current.Request;
            string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result)) { result = request.ServerVariables["REMOTE_ADDR"]; }
            if (string.IsNullOrEmpty(result)) { result = request.UserHostAddress; }
            if (string.IsNullOrEmpty(result)) { result = "0.0.0.0"; }
            ip = result;// store user Ip



            //Session 
            //Get session by you IP. It may be wrong, becasuse you are access service through VPN. But I and my parnter test successfully.
            if (Session[ip] != null)
            {
                Label3.Text = String.Join(", ",(List<string>)Session[ip]);   //show history input by Session
            }


            //COOKISE
            //access cookies, if cookise exist, show in label1.
            HttpCookie myCookies = Request.Cookies["myCookieId"];   //Creat cookies instance

            //If the user is already logged in, don't show log in button and show log out button and show welcome label
            if ((myCookies != null) && (myCookies["Name"] != ""))
            {
                Button3.Visible = false;    //don't show log in button 
                Button4.Visible = true;     //show log out button 
                Label2.Text = "Welcome " + myCookies["Name"] + " !";    //show welcome label 
            }
            else
            {
                Button3.Visible = true;     //same as above
                Button4.Visible = false;
            }


        }

        //button for show shop info.
        protected void Button1_Click(object sender, EventArgs e)
        {
            //creat a proxy to call service
            Shopinfo.Service1Client myproxy = new Shopinfo.Service1Client();
            string shopname = TextBox1.Text;    //user input shopname
            Dictionary<string, string> res = new Dictionary<string, string>();  //creat a dictionary to receive data
            res = myproxy.GetBaseInfo(shopname);    // call WCF service to get shop info.
            List<string> list = new List<string>();
            list.Add("Restaurant:" + shopname); // add shop name
            foreach (var entry in res)  //traversing all dictionary and store data in list 
            {
                list.Add(entry.Key + ":" + entry.Value);
            }
            string show = string.Join("<br/>", list.ToArray()); //convert to string and show in label
            Label1.Text = show;

            //put user input in session as input history.
            List<string> history = new List<string>(); //Creat a list to store session info.
            
            //if seesion is exist, add new history in session.
            if(Session[ip] != null)
            {
                history = (List<string>)Session[ip];    // get input history in session          
            }
 
            if (!history.Contains(shopname))
            {
                history.Add(shopname); //store new input history in session
            }     
            Session[ip] = history;

        }

        //button for going to login page
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //button for logging out
        //1. clear all cookies
        //2. clear all Authentication
        protected void Button4_Click(object sender, EventArgs e)
        {
            //clear cookies
            if (HttpContext.Current != null)
            {
                int cookieCount = HttpContext.Current.Request.Cookies.Count;
                for (var i = 0; i < cookieCount; i++)
                {
                    var cookie = HttpContext.Current.Request.Cookies[i];
                    if (cookie != null)
                    {
                        var expiredCookie = new HttpCookie(cookie.Name)
                        {
                            Expires = DateTime.Now.AddDays(-1),
                            Domain = cookie.Domain
                        };
                        HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                    }
                }

                // clear cookies server side
                HttpContext.Current.Request.Cookies.Clear();
            }

            Label2.Text = "";//don't show welcome label 
            Button3.Visible = true; //show log in button
            Button4.Visible = false;//don't show log out button 
            FormsAuthentication.SignOut();  //clear all Authentication
            Response.Redirect(Request.Url.ToString());// refresh page
        }

        //button for add shop to favorites
        protected void Button2_Click(object sender, EventArgs e)
        {
            //if TextBox1.Text is null return
            if (TextBox1.Text == "")
            {
                Label4.Text = "Please input restaurant name first!";
                return;
            }
            //COOKISE
            //access cookies, if cookise don't exist, go to login page. 
            HttpCookie myCookies = Request.Cookies["myCookieId"];   //Creat cookies instance
            if ((myCookies != null) && (myCookies["Name"] != ""))
            {
                //access xml as usually
                XmlDocument xmlDoc = new XmlDocument();
                string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Member.xml");
                xmlDoc.Load(fLocation);
                XmlNode root = xmlDoc.SelectSingleNode("Accounts");

                XmlNodeList child = root.ChildNodes;
                for (int i = 0; i < child.Count; i++)//traver xml to find user node 
                {
                    if (child[i].ChildNodes[0].InnerText == myCookies["Name"].ToString())   //find user node
                    {
                        XmlNodeList shops = child[i].ChildNodes[4].ChildNodes;  //put user's shop node as list
                        for (int j = 0; j < shops.Count; j++)   //traverse shop's node and find whether this shop is already in user's favorites
                        {
                            if (shops[j].InnerText == TextBox1.Text)    //shop is already in user's favorites
                            {
                                Label4.Text = TextBox1.Text + " is already in your favorites!";
                                return;
                            }
                        }
                        //if not, add to user's favorites
                        XmlElement ele1 = xmlDoc.CreateElement("shop"); //creat node 
                        ele1.InnerText = TextBox1.Text; //set node value
                        child[i].ChildNodes[4].AppendChild(ele1);   //add node to its child
                        xmlDoc.Save(fLocation); //save
                        Label4.Text = "Successfully adding " + TextBox1.Text + " to your favorites!";//label show adding Successfully
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");//go to login page. 
            }
        }

        //button for staff login
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffLogin.aspx");
        }
    }
}