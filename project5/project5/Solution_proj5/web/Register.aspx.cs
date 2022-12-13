using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Encryption;   //using local DLL 

namespace web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//waiting button return info and show captcha
            {
                Image1.Visible = true;  //Image is invisible by default
                ImageService.ServiceClient client = new ImageService.ServiceClient();
                string captcha = client.GetVerifierString("4"); //default string length is 4.
                                                                // get image url by calling restful service
                //if captcha contains characters other than letters and numbers, update captcha.
                Regex regex = new Regex(@"^[A-Za-z0-9]+$");
                while (!regex.IsMatch(captcha))
                {
                    captcha = client.GetVerifierString("4");
                }
                string url = "http://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + captcha;
                Image1.ImageUrl = url;  //show image.
                Label4.Text = "Current number of members: " + this.Application["count"].ToString() + ", come and join us!";
            }



        }


        //button for register
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Determine if all required fields have been inputted
            if (TextBox1.Text =="" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "")
            {
                Label3.Text = "Please input all required fields";
                return;
            }
            //Determine if the twice inputs are the same
            if (TextBox2.Text != TextBox3.Text)
            {
                Label2.Text = "Two times the password input does not match. Please check.";
                return;
            }

            //Get the user name and password information 
            string user_name = TextBox1.Text;
            string password = encrypt.Encrypt(TextBox2.Text);   //calling local dll to encrypt
            string longitude = TextBox4.Text;
            string latitude = TextBox5.Text;


            //access xml as alway and omit commments
            XmlDocument xmlDoc = new XmlDocument();
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Member.xml");
            xmlDoc.Load(fLocation);
            XmlNode root = xmlDoc.SelectSingleNode("Accounts");

            XmlNodeList child = root.ChildNodes;
            List<String> list = new List<String>();//store all user's name in list and find out if username input  already exist or not
            for(int i = 0; i < child.Count; i++)
            {
                list.Add(child[i].ChildNodes[0].InnerText);
            }

            if (list.Contains(user_name))   //User already exists
            {
                Label1.Text = "Username already exists!";
                return;
            }

            //Capcha
            //captcha is not get yet
            //I do not know why there are times when the captcha does not show up.
            //I guess it's because of the special characters in the first char.
            if (Image1.ImageUrl == "")
            {
                Label3.Text = "Please get captcha first.";
                return;
            }
            string captcha = Image1.ImageUrl.Substring(Image1.ImageUrl.Length - 4); //Get right captcha;

            //Captcha Wrong
            if (captcha != TextBox6.Text)
            {
                Label3.Text = "Captcha Wrong!";
                return;
            }


            XmlElement ac = xmlDoc.CreateElement("Account");//Create a <Account> node
            XmlElement ele1 = xmlDoc.CreateElement("User");//Create a <User> node
            ele1.InnerText = user_name;//set <User> node's value
            ac.AppendChild(ele1);   //add <User> node in <Account> node as child

            XmlElement ele2 = xmlDoc.CreateElement("Password");//same as above
            ele2.InnerText = password;
            ac.AppendChild(ele2);

            XmlElement ele3 = xmlDoc.CreateElement("longitude");//same as above
            ele3.InnerText = longitude;
            ac.AppendChild(ele3);

            XmlElement ele4 = xmlDoc.CreateElement("latitude");//same as above
            ele4.InnerText = latitude;
            ac.AppendChild(ele4);

            XmlElement ele5 = xmlDoc.CreateElement("shops");//same as above but don't have child yet
/*            XmlElement shop = xmlDoc.CreateElement("shop");
            ele5.AppendChild(shop);*/
            ac.AppendChild(ele5);   // //same as above

            root.AppendChild(ac);//add <Account> node in <Accounts> node as child
            xmlDoc.Save(fLocation);//save xml

            //show message box and go to login page.
            Response.Write("<script>alert('Register successfully！');window.location='Login.aspx';</script>");

        }

        //button for reload captcha image.
        protected void Button2_Click(object sender, EventArgs e)
        {
            Image1.Visible = true;  //Image is invisible by default
            ImageService.ServiceClient client = new ImageService.ServiceClient();
            string captcha = client.GetVerifierString("4"); //default string length is 4.
            //if captcha contains characters other than letters and numbers, update captcha.
            Regex regex = new Regex(@"^[A-Za-z0-9]+$");
            while (!regex.IsMatch(captcha))
            {
                captcha = client.GetVerifierString("4");
            }
            // get image url by calling restful service
            // sometime captcha is not show as a image may because the captcha have special characters in the first char.
            string url = "http://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + captcha;
            Image1.ImageUrl = url;  //show image.
        }
    }
}