using CompropagoSdk.Models;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using CompropagoSdk.Factory.Abs;
using CompropagoSdk.Factory.V10;
using CompropagoSdk.Factory.V11;

namespace CompropagoSdk.Factory
{
    class Factory
    {
        public static bool verifierVersion(string source, JavaScriptSerializer serializer)
        {
            VerifierVersion obj = serializer.Deserialize<VerifierVersion>(source);
            return (obj.api_version != null);
        }

        public static EvalAuthInfo evalAuthInfo(string source)
        {
            var serializer = new JavaScriptSerializer();
            EvalAuthInfo obj = serializer.Deserialize<EvalAuthInfo>(source);

            return obj;
        }

        public static List<Provider> listProviders(string source)
        {
            var serializer = new JavaScriptSerializer();
            List<Provider> obj = serializer.Deserialize<List<Provider>>(source);

            return obj;
        }

        public static NewOrderInfo newOrderInfo(string source)
        {
            var serializer = new JavaScriptSerializer();
            NewOrderInfo obj = null;

            if (verifierVersion(source, serializer))
            {
                obj = serializer.Deserialize<NewOrderInfo11>(source);
            }
            else
            {
                obj = serializer.Deserialize<NewOrderInfo10>(source);
            }

            return obj;
                
        }

        public static CpOrderInfo cpOrderInfo(string source)
        {
            var serializer = new JavaScriptSerializer();
            CpOrderInfo obj = null;

            if (verifierVersion(source, serializer))
            {
                obj = serializer.Deserialize<CpOrderInfo11>(source);
            }
            else
            {
                obj = serializer.Deserialize<CpOrderInfo10>(source);
            }

            return obj;
        }

        public static SmsInfo smsInfo(string source)
        {
            var serializer = new JavaScriptSerializer();
            SmsInfo obj = null;

            if (verifierVersion(source, serializer))
            {
                obj = serializer.Deserialize<SmsInfo11>(source);
            }
            else
            {
                obj = serializer.Deserialize<SmsInfo10>(source);
            }

            return obj;
        }

        public static Webhook webhook(string source)
        {
            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Webhook>(source);
            return obj;
        }

        public static List<Webhook> listWebhooks(string source)
        {
            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<List<Webhook>>(source);
            return obj;
        }
    }
}
