using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Encryption;   //using local DLL 



namespace web
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Button for encrypting string
        //I use MD5, I can not show decrypption because MD5 encrypting is irreversible.
        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = encrypt.Encrypt(TextBox1.Text);  //using DLL to encrypt string.
            Label1.Text = "MD5:"+ a;    //show in label1.

        }
    }
}