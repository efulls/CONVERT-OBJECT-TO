using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OBJECT_TO_XML
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
    public class CurrencyEnvelope
    {
        [XmlAttribute(AttributeName = "gesmes", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public string gesmes { get; set; }


        [XmlElement(ElementName = "subject", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public string CurrencySubject { get; set; }

        [XmlElement(ElementName = "Sender", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public CurrencySender CurrencySender { get; set; }
        [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public CurrencyCube CurrencyCube { get; set; }


        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        public CurrencyEnvelope()
        {
            xmlns.Add("gesmes", "http://www.gesmes.org/xml/2002-08-01");
        }
        public string error { get; set; }
    }

    public class CurrencySender
    {

        [XmlElement(ElementName = "name")]
        public string name { get; set; }
    }

    public class CurrencyCube
    {
        public CurrencyCurrCube Cube { get; set; }
    }

    public class CurrencyCurrCube
    {
        [XmlAttribute(AttributeName = "time")]
        public string time { get; set; }
        [XmlElement(ElementName = "Cube")]
        public List<CurrencyCubeRate> Cube { get; set; }

    }
    [XmlRoot(ElementName = "Cube")]
    public class CurrencyCubeRate
    {
        [XmlAttribute(AttributeName = "currency")]
        public string currency { get; set; }

        [XmlAttribute(AttributeName = "rate")]
        public string rate { get; set; }
    }


}
