using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OBJECT_TO_SOAP
{
    [Serializable]
    [XmlRoot("Envelope")]
    public class OneShot
    {
        [XmlElement("form_namespace", Namespace = "http://mobileforms.foo.com/xforms")]
        public string FormNamespace { get; set; }
        [XmlElement("Days")]
        public int Days { get; set; }
        [XmlElement("Leave_Type")]
        public string LeaveType { get; set; }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        public OneShot()
        {
            xmlns.Add("soap", "http://schemas.xmlsoap.org/soap/envelope/");
        }
    }
}
