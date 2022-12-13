using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TryIt.XML_Ref;

namespace TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XML_Ref.Service1Client myproxy = new XML_Ref.Service1Client();
            string XML_Url = TextBox1.Text;
            string XSD_Url = TextBox2.Text;
            string[] res = myproxy.xml_verify(XML_Url, XSD_Url);
            Label1.Text = string.Join("<br/>", res);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            XML_Ref.Service1Client myproxy = new XML_Ref.Service1Client();
            string XML_Url = TextBox3.Text;
            string xpath = TextBox4.Text;
            string[] res = myproxy.xpthserach(XML_Url, xpath);
            Label2.Text = string.Join("<br/>", res);
        }
    }
}