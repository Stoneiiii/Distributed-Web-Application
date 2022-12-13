using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TempConver.ServiceClient myproxy = new TempConver.ServiceClient();
            try
            {
                int c = Convert.ToInt32(TextBox1.Text);
            
                string f = Convert.ToString(myproxy.c2f(c));
                Label1.Text = f; 
            }
            catch (Exception ec) { Label1.Text = ec.Message.ToString(); }
            myproxy.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TempConver.ServiceClient myproxy = new TempConver.ServiceClient();
            try
            {
                int f = Convert.ToInt32(TextBox2.Text);
            
                string c = Convert.ToString(myproxy.f2c(f));
                Label2.Text = c; 
            }
            catch (Exception ec) { Label2.Text = ec.Message.ToString(); }
            myproxy.Close();
        }


    }
}