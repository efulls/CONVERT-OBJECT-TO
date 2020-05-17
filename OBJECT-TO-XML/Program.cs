using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OBJECT_TO_XML
{
    class Program
    {
        static void Main(string[] args)
        {

            var json = "{\"com\":{\"categories\":[\"gTLD\",\"Popular\"],\"addons\":{\"dns\":true,\"email\":true,\"idprotect\":true},\"group\":\"hot\",\"register\":{\"1\":\"11.99\",\"2\":\"23.98\",\"3\":\"35.97\",\"4\":\"47.96\",\"5\":\"59.95\",\"6\":\"71.94\",\"7\":\"83.93\",\"8\":\"95.92\",\"9\":\"107.91\",\"10\":\"119.90\"},\"transfer\":{\"1\":\"11.99\",\"2\":\"23.98\",\"3\":\"35.97\",\"4\":\"47.96\",\"5\":\"59.95\",\"6\":\"71.94\",\"7\":\"83.93\",\"8\":\"95.92\",\"9\":\"107.91\",\"10\":\"119.90\"},\"renew\":{\"1\":\"11.99\",\"2\":\"23.98\",\"3\":\"35.97\",\"4\":\"47.96\",\"5\":\"59.95\",\"6\":\"71.94\",\"7\":\"83.93\",\"8\":\"95.92\",\"9\":\"107.91\",\"10\":\"119.90\"},\"grace_period\":{\"days\":30,\"price\":\"\u00a30.00\"},\"redemption_period\":null}}";

            var result = JsonConvert.DeserializeObject<RootObject>(json);

            Console.WriteLine(json);

        }
    }
}
