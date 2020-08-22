using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OBJECT_TO_SOAP
{
    public class Program
    {
        public static object HttpContext { get; private set; }

        public static void Main()
        {
            #region login request
            //var env = new LoginRequest.Envelope
            //{

            //    Header = new LoginRequest.Header(),
            //    Body = new LoginRequest.Body()
            //    {
            //        LoginRequest = new LoginRequest
            //        {
            //            //   Id = "o0",
            //            //   Root = 1,
            //            DeviceId = "***",
            //            Firm = "***",
            //            Login = "***",
            //            Password = "***"
            //        },
            //    },
            //    BodyDua = new LoginRequest.BodyDua()
            //    {
            //        GetTravelPolicy = new LoginRequest.GetTravelPolicy()
            //        {
            //            LoginRequest = new LoginRequest
            //            {
            //                DeviceId = "***",
            //                Firm = "***",
            //                Login = "***",
            //                Password = "***"

            //            }
            //        }
            //    }
            //};
            //var serializer = new XmlSerializer(typeof(LoginRequest.Envelope));
            //var settings = new XmlWriterSettings
            //{
            //    Encoding = Encoding.UTF8,
            //    Indent = true,
            //    OmitXmlDeclaration = true,
            //};
            //var builder = new StringBuilder();
            //using (var writer = XmlWriter.Create(builder, settings))
            //{
            //    serializer.Serialize(writer, env, env.xmlns);
            //}
            //Console.WriteLine(builder.ToString());

            #endregion

            #region Oneshot

            //var one = new OneShot
            //{
            //    FormNamespace = "Lah Ini",
            //    Days = 3,
            //    LeaveType = "No Leave Leave"
            //};

            //var serializer2 = new XmlSerializer(typeof(OneShot));
            //var settings2 = new XmlWriterSettings
            //{
            //    Encoding = Encoding.UTF8,
            //    Indent = true,
            //    OmitXmlDeclaration = true,
            //};
            //var builder2 = new StringBuilder();
            //using (var writer2 = XmlWriter.Create(builder2, settings2))
            //{
            //    serializer2.Serialize(writer2, one);
            //}
            //Console.WriteLine(builder2.ToString());
            #endregion

            var signonRq = new SignonRq
            {
                SignonPswd = new SignonPswd
                {
                    CustId = new CustId
                    {
                        SPName = "Salestock Dot Com",
                        CustLoginId = "VPR7K-GPY8G"
                    },
                    CustPswd = new CustPswd
                    {
                        EncryptionTypeCd = "HASH",
                        Pswd = "INDIODE"
                    }
                }
            };

            var insuranceSvcRq = new InsuranceSvcRq
            {
                RqUID = "RQUID-9349",
                PersPkgPolicyAddRq = new PersPkgPolicyAddRq
                {
                    TransactionRequestDt = DateTime.Now,
                    InsuredOrPrincipal = new InsuredOrPrincipal
                    {
                        GeneralPartyInfo = new GeneralPartyInfo
                        {
                            NameInfo = new List<NameInfo>
                            {
                                new NameInfo
                                {
                                    id = 1,
                                    PersonName = new PersonName
                                    {
                                        Surname = "My Surname",
                                        GivenName = "My Given Name",
                                        TitlePrefix = "Mr",
                                    }
                                },
                                new NameInfo
                                {
                                    id = 1,
                                    PersonName = new PersonName
                                    {
                                        Surname = "My Surname Jr",
                                        GivenName = "My Given Name Junior",
                                        TitlePrefix = "Mss",
                                    }
                                }
                            }
                        }
                    },
                    DataExtensions = new DataExtensions
                    {
                        DataItem = new List<DataItem>
                        {
                            new DataItem
                            {
                                key = "DepartureCity",
                                type = "System.String",
                                value = "Thailand"
                            },
                            new DataItem
                            {
                                key = "ArrivalCity",
                                type = "System.String",
                                value = "Brussels"
                            },
                            new DataItem
                            {
                                key = "PaymentMethod",
                                type = "System.String",
                                IdRef = "",
                                value = "CT"
                            }
                        }
                    },
                    PersPolicy = new PersPolicy
                    {
                        CompanyProductCd = "BLAA-BLAA-BLAA",
                        ContractTerm = new ContractTerm
                        {
                            EffectiveDt = DateTime.Now,
                            ExpirationDt = DateTime.Now
                        },
                        Destionation = new Destionation
                        {
                            RqUID = "BLAA-BLAA-INDDI",
                            DestinationDesc = "Domestic"
                        },
                        InsuredPackage = new InsuredPackage
                        {
                            RqUID = "BLAA-BLAA-INDDI",
                            InsuredPackageDesc = "INDIVIDUAL"
                        },
                        Plan = new Plan
                        {
                            RqUID = "BLAA-BLAA-INDDI",
                            PlanDesc = "DELUXE"
                        }
                    }
                }
                
            };

            

            var acord = new ACORD
            {
                SignonRq = signonRq,
                InsuranceSvcRq = insuranceSvcRq
            };

            var product = new GetTravelPolicy
            {
                ACORD = acord
            };
            var se = new SOAPEnvelope
            {
                body = new ResponseBody<GetTravelPolicy>
                {
                    GetTravelPolicy = product
                }
            };

            //var soapserializer = new XmlSerializer(typeof(SOAPEnvelope));
            ////TextWriter soapwriter = new StreamWriter(@"D:\soapenvelopefortest.xml");
            ////soapserializer.Serialize(soapwriter, se);
            ////soapwriter.Close();

            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"D:\soapenvelopefortest.xml");

            //TextReader soapreader = new StringReader(@"D:\soapenvelopefortest.xml");
            ////var xml = soapserializer.Deserialize(soapreader);
            //Console.WriteLine(doc);

            string testData = @"<StepList>
                        <Step>
                            <Name>Name1</Name>
                            <Desc>Desc1</Desc>
                        </Step>
                        <Step>
                            <Name>Name2</Name>
                            <Desc>Desc2</Desc>
                        </Step>
                    </StepList>";

            XmlSerializer serializer = new XmlSerializer(typeof(StepList));
            using (TextReader reader = new StringReader(testData))
            {
                StepList result = (StepList)serializer.Deserialize(reader);
                Console.WriteLine(result);
            }
            


        }
    }

    [XmlType(Namespace = t, IncludeInSchema = true)]
    public class LoginRequest
    {
        private const string xsi = "http://www.w3.org/2001/XMLSchema-instance";
        private const string xsd = "http://www.w3.org/2001/XMLSchema";
        private const string soap = "http://schemas.xmlsoap.org/soap/envelope/";

        private const string c = "http://schemas.xmlsoap.org/soap/encoding/";
        private const string t = "http://tasks.ws.com/";

        [XmlElement(ElementName = "firm")]
        public string Firm { get; set; }

        [XmlElement(ElementName = "login")]
        public string Login { get; set; }

        [XmlElement(ElementName = "password")]
        public string Password { get; set; }

        [XmlElement(ElementName = "device_id")]
        public string DeviceId { get; set; }

        [XmlRoot(Namespace = soap)]
        public class Envelope
        {
            public Header Header { get; set; }
            public Body Body { get; set; }

            static Envelope()
            {
                staticxmlns = new XmlSerializerNamespaces();
                staticxmlns.Add("xsi", xsi);
                staticxmlns.Add("xsd", xsd);
                staticxmlns.Add("soap", soap);
            }
            private static XmlSerializerNamespaces staticxmlns;
            [XmlNamespaceDeclarations]
            public XmlSerializerNamespaces xmlns { get { return staticxmlns; } set { } }


            public BodyDua BodyDua { get; set; }
        }

        [XmlType(Namespace = soap)]
        public class Header { }

        [XmlType(Namespace = soap)]
        public class Body
        {
            [XmlElement(ElementName = "login", Namespace = t)]
            public LoginRequest LoginRequest { get; set; }
        }


        [XmlType(Namespace = soap)]
        public class BodyDua
        {
            public GetTravelPolicy GetTravelPolicy { get; set; }
        }


        [XmlType(Namespace = soap)]
        public class GetTravelPolicy
        {
            [XmlElement(ElementName = "login", Namespace = t)]
            public LoginRequest LoginRequest { get; set; }
        }

    }
}
