using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2_Sort
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SortNum.ServiceClient myproxy = new SortNum.ServiceClient();
            try
            {
                string s = TextBox1.Text;
                string res = myproxy.sort(s);
                Label1.Text = res;
            }
            catch (Exception ec) { Label1.Text = ec.Message.ToString(); }
            myproxy.Close();
        }
    }
}