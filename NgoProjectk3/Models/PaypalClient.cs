using PayPalCheckoutSdk.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using BraintreeHttp;

namespace NgoProjectk3.Models
{
    public class PaypalClient
    {
        /**
            Set up PayPal environment with sandbox credentials.
            In production, use ProductionEnvironment.
         */
        public static PayPalEnvironment environment()
        {
            return new SandboxEnvironment("AcigcYMYURz24hIUQyQFMlO-mG93g4KpO-P1l2SZOYW3ZIH2CV-Hy20QjJz0YkLedaqO9VHL2ylh8p8Y", "ECBwMwy6PMS9njelhXRAp2_ExRHDEJ0dr6qTMIrA43QCz1l3MpvDI20ZYWkf1Cz32Vl3-gidqf5e4jDk");
        }

        /**
            Returns PayPalHttpClient instance to invoke PayPal APIs.
         */
        public static HttpClient client()
        {
            return new PayPalHttpClient(environment());
        }

        public static HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }

        /**
            Use this method to serialize Object to a JSON string.
        */
        //public static String ObjectToJSONString(Object serializableObject)
        //{
        //    //MemoryStream memoryStream = new MemoryStream();
        //    //var writer = JsonReaderWriterFactory.CreateJsonWriter(
        //    //    memoryStream, Encoding.UTF8, true, true, "  ");
        //    //DataContractJsonSerializer ser = new DataContractJsonSerializer(serializableObject.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
        //    //ser.WriteObject(writer, serializableObject);
        //    //memoryStream.Position = 0;
        //    //StreamReader sr = new StreamReader(memoryStream);
        //    //return sr.ReadToEnd();
        //}
    }
}