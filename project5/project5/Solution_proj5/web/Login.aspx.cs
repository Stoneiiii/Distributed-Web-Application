using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Encryption;   //using local DLL 

namespace web
{
    public partial class Login : System.Web.UI.Page
    {
        //1 if user have already log in, go to member page directly
        //2 show captcha at first
        //3 get user's ip, but we conncect WebStart Server through VPN, So It dosen't work.
        protected void Page_Load(object sender, EventArgs e)
        {
            //show captcha at first
            if (!IsPostBack)
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
            }


            //Get user IP
            //but we conncect WebStart Server through VPN, So It dosen't work.
            HttpRequest request = HttpContext.Current.Request;
            string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result)) { result = request.ServerVariables["REMOTE_ADDR"]; }
            if (string.IsNullOrEmpty(result)) { result = request.UserHostAddress; }
            if (string.IsNullOrEmpty(result)) { result = "0.0.0.0"; }


            //access cookies, if cookise exist, go to member page
            HttpCookie myCookies = Request.Cookies["myCookieId"];   //Creat cookies instance
            if ((myCookies != null) && (myCookies["Name"] != ""))
            {
                FormsAuthentication.RedirectFromLoginPage(myCookies["Name"], Persistent.Checked);
            }

        }

        //Button for logging in.
        protected void Button1_Click(object sender, EventArgs e)
        {


            //captcha is not get yet
            if (Image1.ImageUrl == "")
            {
                Label1.Text = "Please get captcha first.";
                return;
            }
            string captcha = Image1.ImageUrl.Substring(Image1.ImageUrl.Length - 4); //Get right captcha;

            //if captcha is right, user log in and label1 show user name
            if (TextBox3.Text != captcha)
            {
                Label1.Text = "Captcha Error!";
                return;
            }
    
            //access xml to find out user inputs is vaild or not.
            XmlDocument xmlDoc = new XmlDocument();
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Member.xml");
            xmlDoc.Load(fLocation);
            XmlNode root = xmlDoc.SelectSingleNode("Accounts");

            XmlNodeList child = root.ChildNodes;
            List<String> list = new List<String>();
            for (int i = 0; i < child.Count; i++)   //traverse all node
            {
                if(child[i].ChildNodes[0].InnerText  == TextBox1.Text)  //find user name
                {
                    if(child[i].ChildNodes[1].InnerText == encrypt.Encrypt(TextBox2.Text))  //find user password
                    {
                        Label1.Text = "Welcome " + child[i].ChildNodes[0].InnerText;
                        
                        //user name and password is valid, and then set Cookies.
                        HttpCookie myCookies = new HttpCookie("myCookieId");    //Creat cookies instance
                        myCookies["Name"] = TextBox1.Text;      //store cookies content
                        myCookies["Password"] = TextBox2.Text;
                        myCookies.Expires = DateTime.Now.AddDays(2);  //expire time
                        Response.Cookies.Add(myCookies);    //add cookies
                        //Authentication and go to member page.
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
            //Username is not exist
            Label1.Text = "Username is not exist!";
            return;




        }

        //Button for getting captcha image.
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
            string url = "http://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + captcha;
            Image1.ImageUrl = url;  //show image.
        }

        //button for going to register.
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }


        

    }
}