using OBJECT_TO_SOAP_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OBJECT_TO_SOAP_API.Controllers.API
{
    public class SoapController : ApiController
    {
        [Route("~/CreateXml")]
        [HttpPost]
        public IHttpActionResult TestResukt(SOAPEnvelope sop)
        {
            //string xmlData = HttpContext.Current.Server.MapPath(@"D:/objectXmlWebApi.xml");

            //XDocument Rsp = XDocument.Load(@"D:/objectXmlWebApi.xml");


            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\StepList.xml");

            //TextReader testData = new StringReader(@"D:\soapenvelopefortest.xml");

            //string testData = @"<StepList>
            //            <Step>
            //                <Name>My Name Is Isit</Name>
            //                <Desc>Desc1</Desc>
            //            </Step>
            //            <Step>
            //                <Name>Name2</Name>
            //                <Desc>Desc2</Desc>
            //            </Step>
            //        </StepList>";

            XmlSerializer serializer = new XmlSerializer(typeof(StepList));
            using (TextReader reader = new StringReader(doc.ToString()))
            {
                StepList result = (StepList)serializer.Deserialize(reader);
                return Ok(result);
            }

           
        }

    }
}
