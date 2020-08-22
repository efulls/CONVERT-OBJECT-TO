using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OBJECT_TO_SOAP_CHUBB
{
    [XmlType(Namespace = TravelPolicy.soap, IncludeInSchema = true)]
    public class TravelPolicy
    {
        private const string xsi = "http://www.w3.org/2001/XMLSchema-instance";
        private const string xsd = "http://www.w3.org/2001/XMLSchema-instance";
        private const string soap = "http://www.w3.org/2001/XMLSchema-instance";
        private const string policy = "http://ACE.Global.Travel.CRS.Schemas.ACORD.WS/";
        private const string accord = "http://ACE.Global.Travel.CRS.Schemas.ACORD_PolicyReq";

        [XmlRoot(Namespace = soap)]
        public class Envelope
        {
            public Body Body { get; set; }
            static Envelope()
            {
                staticxmlns = new XmlSerializerNamespaces();
                staticxmlns.Add("xsd", xsd);
                staticxmlns.Add("xsi", xsi);
                staticxmlns.Add("soap", soap);
            }
            private static XmlSerializerNamespaces staticxmlns;
            [XmlNamespaceDeclarations]
            public XmlSerializerNamespaces xmlns { get { return staticxmlns; } set { } }
        }

        [XmlType(Namespace = soap)]
        public class Body
        {
            [XmlElement(ElementName = "loginss", Namespace = soap)]
            public TravelPolicy TravelPolicy { get; set; }
        }
    }
}
