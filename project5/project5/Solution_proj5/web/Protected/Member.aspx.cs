using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

namespace web.Protected
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //decide whether user is a staff, if so, jump to the staff page
            XmlDocument xmlDoc2 = new XmlDocument();    //Creat XmlDocument instance
            string fLocation2 = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Staff.xml");
            xmlDoc2.Load(fLocation2);
            XmlNode root2 = xmlDoc2.SelectSingleNode("Accounts");   //find node
            XmlNodeList child2 = root2.ChildNodes;  //return childe node as a list
            for (int i = 0; i < child2.Count; i++)  //traverse all node, if user is in staff.xml, go to staff page
            {
                if (Context.User.Identity.Name == child2[i].ChildNodes[0].InnerText)
                {
                    Response.Redirect("Staff.aspx");//go to staff page
                }
            }

            if (!IsPostBack) //Determine if a form is a return
            { 
                XmlDocument xmlDoc = new XmlDocument();//Creat XmlDocument instance
                string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Member.xml");
                xmlDoc.Load(fLocation);
                XmlNode root = xmlDoc.SelectSingleNode("Accounts");//find node

                XmlNodeList child = root.ChildNodes;//return childe node as a list
                List<String> list = new List<String>();//store all user favorites shop in list and than show in a listbox
                for (int i = 0; i < child.Count; i++)
                {
                    if (child[i].ChildNodes[0].InnerText == Context.User.Identity.Name) //find user node
                    {
                        XmlNodeList shops = child[i].ChildNodes[4].ChildNodes;  //return shop node as a list
                        for (int j = 0; j< shops.Count; j++)    //traverse all favorites shop
                        {
                            list.Add(shops[j].InnerText);
                        }
                    }
                }
                ListBox1.DataSource = list; //show in listbox
                ListBox1.DataBind();    //bind to listbox
            }



        }

        //button for signing out function
        //1. clear all cookies
        //2. clear all Authentication
        protected void Button1_Click(object sender, EventArgs e)
        {
            //clear all cookies
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

            //clear all Authentication
            FormsAuthentication.SignOut();
            //Server.Transfer("~/Default.aspx");    //don't know why url is not refresh when page to go default.
            Response.Redirect("~/Default.aspx");    // sigh out and go to default page


        }

        //button for going to home page
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

       
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //button for show user favorites shop's information
        protected void Button3_Click(object sender, EventArgs e)
        {
            //if user don't select any shop in listbox.
            if(ListBox1.SelectedValue.ToString() == "")
            {
                Label1.Text = "Please select one shop!";
                return;
            }
           

            //calling severse to show shop's information.
            //creat a proxy to call service
            Shopinfo.Service1Client myproxy = new Shopinfo.Service1Client();
            string shopname = ListBox1.SelectedValue.ToString();    //user selected shopname
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

        }


    }
}