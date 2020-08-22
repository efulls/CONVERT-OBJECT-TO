using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OBJECT_TO_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateCommunity();
            //CreateCurrency();
            var read = GetClient("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            var cvr = Deserialize<CurrencyEnvelope>(read);

            List<Currency> curr = new List<Currency>();
            foreach (var crt in cvr.CurrencyCube.Cube.Cube)
            {
                curr.Add(new Currency()
                {
                    Code = crt.currency,
                    Rate = crt.rate
                });
            }

            Console.WriteLine(curr.ToString());
            //Console.WriteLine(read);
            //Console.WriteLine(cvr);
        }

        public static void CreateCurrency()
        {
            CurrencyEnvelope currency = new CurrencyEnvelope
            {
                CurrencySubject = "Reference rates",
                CurrencySender = new CurrencySender { name= "European Central Bank" },
                CurrencyCube = new CurrencyCube 
                {
                    Cube = new CurrencyCurrCube 
                    { 
                        time= "2020-08-21",
                        Cube = new List<CurrencyCubeRate>
                        {
                            new CurrencyCubeRate
                            {
                                currency = "SGD",
                                rate = "10.0"
                            },
                            new CurrencyCubeRate
                            {
                                currency = "IDR",
                                rate = "1700.0"
                            }
                        }
                    } 
                },
            };


            XmlSerializer serializer = new XmlSerializer(typeof(CurrencyEnvelope));
            serializer.Serialize(File.Create("currency.xml"), currency);
        }
        public static void CreateCommunity()
        {
            Community community = new Community
            {
                Author = "xxx xxx",
                CommunityId = 0,
                Name = "name of community",
                Addresses = new List<Address> {
                    new RegisteredAddress {
                        AddressLine1 = "xxx",
                        AddressLine2 = "xxx",
                        AddressLine3 = "xxx",
                        City = "xx",
                        Country = "xxxx",
                        PostCode = "0000-00"
                    },
                    new TradingAddress {
                        AddressLine1 = "zz",
                        AddressLine2 = "xxx"
                    }
                }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(Community));
            serializer.Serialize(File.Create("file.xml"), community);
        }



        private static string GetClient(string uri)
        {
            try
            {

                HttpResponseMessage HttpResponseMessage = null;
                var GoResponse = "";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

                    HttpResponseMessage = httpClient.GetAsync(uri).Result;

                    GoResponse = HttpResponseMessage.Content.ReadAsStringAsync().Result;

                }
                return GoResponse;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }
        public static T Deserialize<T>(string xmlText)
        {
            using (TextReader textReader = new StringReader(xmlText))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                T result = (T)serializer.Deserialize(textReader);
                return result;
            }
        }
    }
}
