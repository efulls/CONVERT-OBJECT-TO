using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OBJECT_TO_SOAP_API.Models
{
    [XmlType(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SOAPEnvelope
    {
        [XmlAttribute(AttributeName = "soap", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string soapenva { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string xsd { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string xsi { get; set; }
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public ResponseBody<GetTravelPolicy> body { get; set; }
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        public SOAPEnvelope()
        {
            xmlns.Add("soap", "http://schemas.xmlsoap.org/soap/envelope/");
        }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class ResponseBody<T>
    {
        [XmlElement(Namespace = "http://ACE.Global.Travel.CRS.Schemas.ACORD.WS/")]
        public T GetTravelPolicy { get; set; }
    }

    public class GetTravelPolicy
    {
        [XmlElement(Namespace = "http://ACE.Global.Travel.CRS.Schemas.ACORD_PolicyReq")]
        public ACORD ACORD { get; set; }
    }

    public class ACORD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SignonRq SignonRq { get; set; }
        public InsuranceSvcRq InsuranceSvcRq { get; set; }

    }

    public class SignonRq
    {
        public SignonPswd SignonPswd { get; set; }
        public DateTime ClientDt { get; set; }
        public string CustLangPref { get; set; }
        public ClientApp ClientApp { get; set; }
    }
    public class SignonPswd
    {
        public CustId CustId { get; set; }
        public CustPswd CustPswd { get; set; }
    }
    public class CustId
    {
        public string SPName { get; set; }
        public string CustLoginId { get; set; }
    }
    public class CustPswd
    {
        public string EncryptionTypeCd { get; set; }
        public string Pswd { get; set; }
    }
    public class ClientApp
    {
        public string Org { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
    }
    public class InsuranceSvcRq
    {
        public string RqUID { get; set; }
        public PersPkgPolicyAddRq PersPkgPolicyAddRq { get; set; }
    }
    public class PersPkgPolicyAddRq
    {
        public DateTime TransactionRequestDt { get; set; }
        public InsuredOrPrincipal InsuredOrPrincipal { get; set; }
    }
    public class InsuredOrPrincipal
    {
        public GeneralPartyInfo GeneralPartyInfo { get; set; }
    }

    public class GeneralPartyInfo
    {
        [XmlElement("NameInfo")]
        public List<NameInfo> NameInfo { get; set; }
    }
    [XmlRoot("NameInfo")]
    public class NameInfo
    {
        [XmlAttribute(AttributeName = "id")]
        public int id { get; set; }
        public PersonName PersonName { get; set; }
        public DateTime BirthDt { get; set; }
        public string IdNumberTypeCd { get; set; }
        public string IdNumber { get; set; }

    }
    public class PersonName
    {
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string TitlePrefix { get; set; }
    }
}