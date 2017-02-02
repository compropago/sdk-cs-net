using System.Collections.Generic;
using CompropagoSdk.Factory.Models;
using Newtonsoft.Json;

namespace CompropagoSdk.Factory
{
    public class Factory
    {
        public static CpOrderInfo CpOrderInfo(string source = null)
        {
            if (source == null)
            {
                return new CpOrderInfo();
            }

            var obj = JsonConvert.DeserializeObject<CpOrderInfo>(source);

            return obj;
        }

        public static Customer Customer(string source = null)
        {
            if (source == null)
            {
                return new Customer();
            }

            var obj = JsonConvert.DeserializeObject<Customer>(source);

            return obj;
        }

        public static EvalAuthInfo EvalAuthInfo(string source = null)
        {
            if (source == null)
            {
                return new EvalAuthInfo();
            }

            var obj = JsonConvert.DeserializeObject<EvalAuthInfo>(source);

            return obj;
        }

        public static FeeDetails FeeDetails(string source = null)
        {
            if (source == null)
            {
                return new FeeDetails();
            }

            var obj = JsonConvert.DeserializeObject<FeeDetails>(source);

            return obj;
        }

        public static InstructionDetails InstructionDetails(string source = null)
        {
            if (source == null)
            {
                return new InstructionDetails();
            }

            var obj = JsonConvert.DeserializeObject<InstructionDetails>(source);

            return obj;
        }

        public static Instructions Instructions(string source = null)
        {
            if (source == null)
            {
                return new Instructions();
            }

            var obj = JsonConvert.DeserializeObject<Instructions>(source);

            return obj;
        }

        public static NewOrderInfo NewOrderInfo(string source = null)
        {
            if (source == null)
            {
                return new NewOrderInfo();
            }

            var obj = JsonConvert.DeserializeObject<NewOrderInfo>(source);

            return obj;
        }

        public static OrderInfo OrderInfo(string source = null)
        {
            if (source == null)
            {
                return new OrderInfo();
            }

            var obj = JsonConvert.DeserializeObject<OrderInfo>(source);

            return obj;
        }

        public static PlaceOrderInfo PlaceOrderInfo(Dictionary<string,string> source = null)
        {
            if (source == null)
            {
                return new PlaceOrderInfo(null, null, 0, null, null);
            }

            if (!source.ContainsKey("payment_type"))
            {
                source.Add("payment_type", "OXXO");
            }

            if (!source.ContainsKey("currency"))
            {
                source.Add("currency", "MXN");
            }

			if (!source.ContainsKey("expiration_time"))
			{
				source.Add("expiration_time", null);
			}

            if (!source.ContainsKey("image_url"))
            {
                source.Add("image_url", "");
            }

            if (!source.ContainsKey("app_client_name"))
            {
                source.Add("app_client_name", "sdk-cs");
            }

            if (!source.ContainsKey("app_client_version"))
            {
                source.Add("app_client_version", Client.Version);
            }

            var json = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<PlaceOrderInfo>(json);
        }

        public static Provider Provider(string source = null)
        {
            if (source == null)
            {
                return new Provider();
            }

            var obj = JsonConvert.DeserializeObject<Provider>(source);

            return obj;
        }

        public static Provider[] ListProviders(string source = null)
        {
            if (source == null)
            {
                return null;
            }

            var obj = JsonConvert.DeserializeObject<Provider[]>(source);

            return obj;
        }

        public static SmsData SmsData(string source = null)
        {
            if (source == null)
            {
                return new SmsData();
            }

            var obj = JsonConvert.DeserializeObject<SmsData>(source);

            return obj;
        }

        public static SmsInfo SmsInfo(string source = null)
        {
            if (source == null)
            {
                return new SmsInfo();
            }

            var obj = JsonConvert.DeserializeObject<SmsInfo>(source);

            return obj;
        }

        public static SmsObject SmsObject(string source = null)
        {
            if (source == null)
            {
                return new SmsObject();
            }

            var obj = JsonConvert.DeserializeObject<SmsObject>(source);

            return obj;
        }

        public static Webhook Webhook(string source = null)
        {
            if (source == null)
            {
                return new Webhook();
            }

            var obj = JsonConvert.DeserializeObject<Webhook>(source);

            return obj;
        }

        public static Webhook[] ListWebhooks(string source = null)
        {
            if (source == null)
            {
                return null;
            }

            var obj = JsonConvert.DeserializeObject<Webhook[]>(source);

            return obj;
        }
    }
}