using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace Xml_verify
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //operation1: verify XML
        //main function to verify XML;
        public String xml_verify(string xml_url, string xsd_url)
        {
            if (xml_url == null || !xml_url.Contains(".xml"))
                return "The URL of XML document is wrong";
            if (xsd_url == null || !xsd_url.Contains(".xsd"))
                return "The URL of XSD document is wrong";

            string res = "";
            res = VerifyXML(xml_url, xsd_url);
            if (res == "")
                return "No Error";
            return res;
        }

        //method to verify xml;
        private static string VerifyXML(string xmlFile, string xsdFile)
        {
            string error = "";
/*            xmlFile = "C:\\Users\\stone\\Desktop\\445_project4\\XML\\Cruises_error.xml";
            xsdFile = "C:\\Users\\stone\\Desktop\\445_project4\\XML\\Cruises.xsd";*/

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlFile);
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(xsdFile));


            
            ValidationEventHandler eventHandler = new ValidationEventHandler(delegate (object sender, ValidationEventArgs e) {
                switch (e.Severity)

                {
                    case XmlSeverityType.Error:

                        error += e.Message;

                        break;

                    case XmlSeverityType.Warning:

                        break;

                }

            });
            xmlDocument.Schemas = schemas;
            xmlDocument.Validate(eventHandler);
            return error;
        }

        //operation2: serach through xpath.
        public String[] xpthserach(string xml_url, string xpath)
        {
            String[] res;
            List<string> list = new List<string>();
            XPathDocument dx = new XPathDocument("Courses.xml");
            XPathNavigator nav = dx.CreateNavigator();
            XPathNodeIterator iterator = nav.Select("/Courses/Course");
            while (iterator.MoveNext())
            {
                list.Add((string)iterator.Current.Value);
            }
            return list.ToArray();
        }
    }
}
