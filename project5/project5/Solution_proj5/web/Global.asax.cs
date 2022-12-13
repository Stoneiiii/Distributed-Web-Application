using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;

namespace web
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            /*            DataSet ds = new DataSet();
                        ds.ReadXml(Server.MapPath("App_Data\\Member.xml"));Username already exists!
                        Application["GlobalData"] = ds;*/
            Application["count"] = 0;   //initiatize a data set to store user's number
            

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //when session start, get user's number
            XmlDocument xmlDoc = new XmlDocument(); //access xml
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Member.xml");
            xmlDoc.Load(fLocation);
            XmlNode root = xmlDoc.SelectSingleNode("Accounts");
            XmlNodeList child = root.ChildNodes;
            Application.Lock(); //lock to avoid simultaneous registration of multiple users
            Application["count"] = child.Count; 
            Application.UnLock();   //unlock
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.UnLock();
        }
    }
}