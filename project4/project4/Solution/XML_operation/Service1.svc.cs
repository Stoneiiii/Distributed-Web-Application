using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Schema;
using System.Xml;
using System.Xml.XPath;

namespace XML_operation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //operation1: verify XML.
        //main function to verify XML;
        public String[] xml_verify(string xml_url, string xsd_url)
        {
            List<string> results = new List<string>();//initialize array of sting to store input error information.
            //if input is empty or wrong, notice.
            if (xml_url == null || !xml_url.Contains(".xml"))
            {
                results.Add("The URL of XML document is wrong");
                return results.ToArray();
            }
            if (xsd_url == null || !xsd_url.Contains(".xsd"))
            {
                results.Add("The URL of XSD document is wrong");
                return results.ToArray();
            }

            string[] res;    //store result information
            res = VerifyXML(xml_url, xsd_url);  //call method.
            results = res.ToList();
            if (results.Count == 0)
            {
                results.Add("No Error");  
            }
                
            return results.ToArray();
        }

        //method to verify xml;
        private static string[] VerifyXML(string xmlFile, string xsdFile)
        {
            //string error = "";  //initialize error sting to store information.
            List<string> results = new List<string>();//initialize array of sting to store error information.
            /*            xmlFile = "C:\\Users\\stone\\Desktop\\445_project4\\XML\\Cruises_error.xml";
                        xsdFile = "C:\\Users\\stone\\Desktop\\445_project4\\XML\\Cruises.xsd";*/

            XmlDocument xmlDocument = new XmlDocument();    //new XmlDocument to read XML
            xmlDocument.Load(xmlFile);  //read xml
            XmlSchemaSet schemas = new XmlSchemaSet();  //new XmlSchemaSet to read xsd
            schemas.Add("", XmlReader.Create(xsdFile)); //read xsd


            //creat a event handlder to be called when the xml is not verified by xsd.
            ValidationEventHandler eventHandler = new ValidationEventHandler(delegate (object sender, ValidationEventArgs e) {
                switch (e.Severity)
                {
                    case XmlSeverityType.Error:
                        //error += e.Message;
                        results.Add(e.Message);
                        break;
                    case XmlSeverityType.Warning:
                        break;
                }
            });
            xmlDocument.Schemas = schemas;  //add xsd
            xmlDocument.Validate(eventHandler); //verify xml. if error 
            return results.ToArray();
        }


        //operation2: serach through xpath.
        public String[] xpthserach(string xml_url, string xpath)
        {
            String[] res;   //store result 
            List<string> list = new List<string>(); //creat list to store result and than convert to array of string 
            //if input is empty or wrong, notice.
            if (xml_url == null || !xml_url.Contains(".xml"))
            {
                list.Add("The URL of XML document is wrong");
                return list.ToArray();
            }
            XPathDocument dx = new XPathDocument(xml_url);  //access XML
            XPathNavigator nav = dx.CreateNavigator();  // Create a navigator
            XPathNodeIterator iterator = nav.Select(xpath); //Creat the iterator to store result.
            while (iterator.MoveNext())
            {
                list.Add((string)iterator.Current.Value);   //put result to list.
            }
            return list.ToArray();  //convert list to array of string.
        }

    }
}
