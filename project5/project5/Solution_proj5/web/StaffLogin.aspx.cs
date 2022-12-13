using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Encryption;
using System.Xml;

namespace web
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //button for login. Determine if the user account password is correct as usually 
        //omitting some commments because it is same as login page.
        protected void Button1_Click(object sender, EventArgs e)
        {
            //access xml and omits comments
            XmlDocument xmlDoc = new XmlDocument();
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Staff.xml");
            xmlDoc.Load(fLocation);
            XmlNode root = xmlDoc.SelectSingleNode("Accounts");

            XmlNodeList child = root.ChildNodes;
            List<String> list = new List<String>();
            for (int i = 0; i < child.Count; i++)
            {
                if (child[i].ChildNodes[0].InnerText == TextBox1.Text)
                {
                    if (child[i].ChildNodes[1].InnerText == encrypt.Encrypt(TextBox2.Text))
                    {

                        FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, Persistent.Checked);
                        return;
                    }
                    else
                    {
                        Label1.Text = "Password is wrong!";
                        return;
                    }

                }

            }

            Label1.Text = "Username is not exist!";
            return;
        }
    }
}