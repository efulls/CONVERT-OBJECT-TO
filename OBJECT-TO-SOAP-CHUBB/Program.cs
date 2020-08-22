using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OBJECT_TO_SOAP_CHUBB
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginRequest();
        }

        public static void Operation()
        {
            var env = new TravelPolicy.Envelope
            {
                Body = new TravelPolicy.Body()
                {
                    TravelPolicy = new TravelPolicy
                    {

                    }
                }
            };

            var serializer = new XmlSerializer(typeof(TravelPolicy.Envelope));
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = true,
            };
            var builder = new StringBuilder();
            using (var writer = XmlWriter.Create(builder, settings))
            {
                serializer.Serialize(writer, env, env.xmlns);
            }
            Console.WriteLine(builder.ToString());
        }

        public static void LoginRequest()
        {
            var env = new LoginRequest.Envelope
            {
                Body = new LoginRequest.Body()
                {
                    LoginRequest = new LoginRequest
                    {
                        //   Id = "o0",
                        //   Root = 1,
                        DeviceId = "***",
                        Firm = "***",
                        Login = "***",
                        Password = "***"
                    },
                },
            };
            var serializer = new XmlSerializer(typeof(LoginRequest.Envelope));
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = true,
            };
            var builder = new StringBuilder();
            using (var writer = XmlWriter.Create(builder, settings))
            {
                serializer.Serialize(writer, env, env.xmlns);
            }
            Console.WriteLine(builder.ToString());
        }



    }
}
