using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using Encryption;   //using local DLL 
using Microsoft.Ajax.Utilities;

namespace web.Protected
{
    public partial class Staff : System.Web.UI.Page
    {
        //1. if user is not staff(member user can be authenticated to this page). Forced to go to member page.
        //2. return number if member and show in a label.
        //3. show member's user name in listbox
        //4. show staff's user name in listbox
        protected void Page_Load(object sender, EventArgs e)
        {

            //access member.xml
            XmlDocument xmlDoc = new XmlDocument();//Creat XmlDocument instance
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Member.xml");
            xmlDoc.Load(fLocation);
            XmlNode root = xmlDoc.SelectSingleNode("Accounts");//find node
            XmlNodeList child = root.ChildNodes;//return childe node as a list
            Label1.Text = child.Count.ToString();   //show how much member users now.

           


            //get info from rember.xml and show in listbox
            if (!IsPostBack)
            {
                List<String> list = new List<String>();//store use name
                for (int i = 0; i < child.Count; i++) //traverse all user name and add in a list
                {
                    list.Add(child[i].ChildNodes[0].InnerText);
                }
                ListBox1.DataSource = list;//show in listbox
                ListBox1.DataBind();//bind to listbox
            }

            //access staff.xml
            XmlDocument xmlDoc2 = new XmlDocument();//Creat XmlDocument instance
            string fLocation2 = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Staff.xml");
            xmlDoc2.Load(fLocation2);
            XmlNode root2 = xmlDoc2.SelectSingleNode("Accounts");//find node
            XmlNodeList child2 = root2.ChildNodes;//return childe node as a list

            //if user is not staff, go to member page.
            int flag = 0; //flag = 0 indicates it is not staff user
            for (int i = 0; i < child2.Count; i++)
            {
                if(Context.User.Identity.Name == child2[i].ChildNodes[0].InnerText)
                {
                    flag = 1;  //indicates it is not staff user 
                }
            }
            if (flag == 0)  //not staff . go to member page
            {
                Response.Write("<script>alert('You are not an administrator!');window.location='Member.aspx';</script>");
                //Response.Redirect("~/Protected/Member.aspx");
            }

            if (!IsPostBack) //get info from staff.xml and show in listbox
            {
                List<String> list2 = new List<String>();//store use name
                for (int i = 0; i < child2.Count; i++)// traverse all user name and add in a list
                {
                    list2.Add(child2[i].ChildNodes[0].InnerText);
                }
                ListBox2.DataSource = list2;//show in listbox
                ListBox2.DataBind();//bind to listbox
            }
        }

        
        //button for signout and go to default page
        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            //Server.Transfer("~/Default.aspx");
            Response.Redirect("~/Default.aspx");
        }

        //button for deleting one member user.
        protected void Button2_Click(object sender, EventArgs e)
        {
            //access member.xml as always
            XmlDocument xmlDoc = new XmlDocument();//Creat XmlDocument instance
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Member.xml");
            xmlDoc.Load(fLocation);
            XmlNode root = xmlDoc.SelectSingleNode("Accounts");
            XmlNodeList child = root.ChildNodes;

            //traverse all node and find the node we want to delete
            for (int i = 0; i < child.Count; i++)
            {
                if(child[i].ChildNodes[0].InnerText == ListBox1.SelectedValue.ToString())
                {
                    root.RemoveChild(child[i]);//delete that node and their all child
                    //Label2.Text = "Delete successfully";  //cannot show in the label because listbox have not refresh yet.
                    xmlDoc.Save(fLocation); //save xml

                    Response.Redirect(Request.Url.ToString());  //refresh page and reload user in listbox.
                    return;
                }
                
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //access staff.xml as always
            XmlDocument xmlDoc = new XmlDocument();//Creat XmlDocument instance
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Staff.xml");
            xmlDoc.Load(fLocation);
            XmlNode root = xmlDoc.SelectSingleNode("Accounts");
            XmlNodeList child = root.ChildNodes;

            //traverse all node and find the node we want to delete
            for (int i = 0; i < child.Count; i++)
            {
                if (child[i].ChildNodes[0].InnerText == ListBox2.SelectedValue.ToString())//find node
                {
                    root.RemoveChild(child[i]);//delete that node and their all child
                    //Label2.Text = "Delete successfully";
                    xmlDoc.Save(fLocation);//save xml

                    Response.Redirect(Request.Url.ToString());//refresh page and reload user in listbox.
                    return;
                }

            }
        }

        //button for adding a staff user.
        protected void Button3_Click(object sender, EventArgs e)
        {
            //access staff.xml as always and omit comments~
            XmlDocument xmlDoc = new XmlDocument();//access staff.xml as always
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Staff.xml");
            xmlDoc.Load(fLocation);
            XmlNode root = xmlDoc.SelectSingleNode("Accounts");

            XmlElement ac = xmlDoc.CreateElement("Account");//create a node 
            XmlElement ele1 = xmlDoc.CreateElement("User");//create a node
            ele1.InnerText = TextBox1.Text;//set node's value
            ac.AppendChild(ele1);   //add this node to others as its child

            XmlElement ele2 = xmlDoc.CreateElement("Password");// same as above
            ele2.InnerText = encrypt.Encrypt(TextBox2.Text);// same as above but set value after encryption by calling local dll
            ac.AppendChild(ele2);// same as above

            root.AppendChild(ac);//add this node to others as its child
            xmlDoc.Save(fLocation);//save
            Response.Redirect(Request.Url.ToString());  //refresh page and reload user in listbox.
        }
    }
}