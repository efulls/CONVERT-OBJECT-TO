using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OBJECT_TO_SOAP_API.Models
{
    public class LoginRequest
    {
        private const string i = "http://www.w3.org/2001/XMLSchema-instance";
        private const string d = "http://www.w3.org/2001/XMLSchema";
        private const string c = "http://schemas.xmlsoap.org/soap/encoding/";
        private const string v = "http://schemas.xmlsoap.org/soap/envelope/";
        private const string t = "http://tasks.ws.com/";

        [XmlElement(ElementName = "firm")]
        public string Firm { get; set; }

        [XmlElement(ElementName = "login")]
        public string Login { get; set; }

        [XmlElement(ElementName = "password")]
        public string Password { get; set; }

        [XmlElement(ElementName = "device_id")]
        public string DeviceId { get; set; }

        [XmlRoot(Namespace = v)]
        public class Envelope
        {
            public Header Header { get; set; }
            public Body Body { get; set; }

            static Envelope()
            {
                staticxmlns = new XmlSerializerNamespaces();
                staticxmlns.Add("i", i);
                staticxmlns.Add("d", d);
                staticxmlns.Add("c", c);
                staticxmlns.Add("soap", v);
            }
            private static XmlSerializerNamespaces staticxmlns;
            [XmlNamespaceDeclarations]
            public XmlSerializerNamespaces xmlns { get { return staticxmlns; } set { } }
        }

        [XmlType(Namespace = v)]
        public class Header { }

        [XmlType(Namespace = v)]
        public class Body
        {
            [XmlElement(ElementName = "login", Namespace = t)]
            public LoginRequest LoginRequest { get; set; }
        }
    }
}