using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OBJECT_TO_SOAP
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
        public PersPolicy PersPolicy { get; set; }
        [XmlElement(ElementName = "com.acegroup_DataExtensions")]
        public DataExtensions DataExtensions { get; set;}
    }
    public class InsuredOrPrincipal
    {
        public GeneralPartyInfo GeneralPartyInfo { get; set; }
    }

    public class GeneralPartyInfo
    {
        [XmlElement(ElementName = "NameInfo")]
        public List<NameInfo> NameInfo { get; set; }
        public Addr Addr { get; set; }
    }
    [XmlRoot(ElementName="NameInfo")]
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

    public class Addr
    {
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
    public class Communications
    {
        public PhoneInfo PhoneInfo { get; set; }
        public EmailInfo EmailInfo { get; set; }
    }
    public class PhoneInfo
    {
        public string PhoneTypeCd { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class EmailInfo
    {
        public string EmailAddr { get; set; }
    }

    public class PersPolicy
    {
        public string CompanyProductCd { get; set; }
        public ContractTerm ContractTerm { get; set; }

        [XmlElement(Namespace = "com.acegroup_Destination")]
        public Destionation Destionation { get; set; }

        [XmlElement(Namespace = "com.acegroup_InsuredPackage")]
        public InsuredPackage InsuredPackage { get; set; }

        [XmlElement(Namespace = "com.acegroup_Plan")]
        public Plan Plan { get; set; }
    }
    public class ContractTerm
    {
        public DateTime EffectiveDt { get; set; }
        public DateTime ExpirationDt { get; set; }

    }
    public class Destionation
    {
        public string RqUID { get; set; }
        public string DestinationDesc { get; set; }

    }

    public class InsuredPackage
    {
        public string RqUID { get; set; }
        public string InsuredPackageDesc { get; set; }

    }
    public class Plan
    {
        public string RqUID { get; set; }
        public string PlanDesc { get; set; }

    }

    public class DataExtensions
    {
        [XmlElement(ElementName = "DataItem")]
        public List<DataItem> DataItem { get; set; }
    }
    [XmlRoot(ElementName = "DataItem")]
    public class DataItem
    {

        [XmlAttribute(AttributeName = "key")]
        public string key { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string type { get; set; }

        [XmlAttribute(AttributeName = "IdRef")]
        public string IdRef { get; set; }
        public string value { get; set; }
    }
}
