using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OBJECT_TO_SOAP_API.Models
{
    [XmlRoot("StepList")]
    public class StepList
    {
        [XmlElement("Step")]
        public List<Step> Steps { get; set; }
    }

    public class Step
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Desc")]
        public string Desc { get; set; }
    }
}