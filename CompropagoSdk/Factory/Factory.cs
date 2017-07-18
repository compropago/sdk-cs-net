using System.Collections.Generic;
using CompropagoSdk.Factory.Models;
using Newtonsoft.Json;

namespace CompropagoSdk.Factory
{
    public class Factory
    {
        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.CpOrderInfo"/>.
        /// </summary>
        /// <returns>The order info.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static CpOrderInfo CpOrderInfo(string source = null)
        {
            if (source == null)
            {
                return new CpOrderInfo();
            }

            var obj = JsonConvert.DeserializeObject<CpOrderInfo>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.Customer"/>.
        /// </summary>
        /// <returns>The customer.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static Customer Customer(string source = null)
        {
            if (source == null)
            {
                return new Customer();
            }

            var obj = JsonConvert.DeserializeObject<Customer>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.EvalAuthInfo"/>.
        /// </summary>
        /// <returns>The auth info.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static EvalAuthInfo EvalAuthInfo(string source = null)
        {
            if (source == null)
            {
                return new EvalAuthInfo();
            }

            var obj = JsonConvert.DeserializeObject<EvalAuthInfo>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.FeeDetails"/>.
        /// </summary>
        /// <returns>The details.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static FeeDetails FeeDetails(string source = null)
        {
            if (source == null)
            {
                return new FeeDetails();
            }

            var obj = JsonConvert.DeserializeObject<FeeDetails>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.InstructionDetails"/>
        /// </summary>
        /// <returns>The details.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static InstructionDetails InstructionDetails(string source = null)
        {
            if (source == null)
            {
                return new InstructionDetails();
            }

            var obj = JsonConvert.DeserializeObject<InstructionDetails>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.Instructions"/>
        /// </summary>
        /// <returns>The instructions.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static Instructions Instructions(string source = null)
        {
            if (source == null)
            {
                return new Instructions();
            }

            var obj = JsonConvert.DeserializeObject<Instructions>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.NewOrderInfo"/>
        /// </summary>
        /// <returns>The order info.</returns>
        /// <param name="source">Source.</param>
        public static NewOrderInfo NewOrderInfo(string source = null)
        {
            if (source == null)
            {
                return new NewOrderInfo();
            }

            var obj = JsonConvert.DeserializeObject<NewOrderInfo>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.OrderInfo"/>
        /// </summary>
        /// <returns>The info.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static OrderInfo OrderInfo(string source = null)
        {
            if (source == null)
            {
                return new OrderInfo();
            }

            var obj = JsonConvert.DeserializeObject<OrderInfo>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.PlaceOrderInfo"/>
        /// </summary>
        /// <returns>The order info.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
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

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.Provider"/>
        /// </summary>
        /// <returns>The provider.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static Provider Provider(string source = null)
        {
            if (source == null)
            {
                return new Provider();
            }

            var obj = JsonConvert.DeserializeObject<Provider>(source);

            return obj;
        }

        /// <summary>
        /// Return array of <see cref="T:CompropagoSdk.Factory.Models.Provider"/>
        /// </summary>
        /// <returns>The providers.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static Provider[] ListProviders(string source = null)
        {
            if (source == null)
            {
                return null;
            }

            var obj = JsonConvert.DeserializeObject<Provider[]>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.SmsData"/>
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static SmsData SmsData(string source = null)
        {
            if (source == null)
            {
                return new SmsData();
            }

            var obj = JsonConvert.DeserializeObject<SmsData>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.SmsInfo"/>
        /// </summary>
        /// <returns>The info.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static SmsInfo SmsInfo(string source = null)
        {
            if (source == null)
            {
                return new SmsInfo();
            }

            var obj = JsonConvert.DeserializeObject<SmsInfo>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.SmsObject"/>
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static SmsObject SmsObject(string source = null)
        {
            if (source == null)
            {
                return new SmsObject();
            }

            var obj = JsonConvert.DeserializeObject<SmsObject>(source);

            return obj;
        }

        /// <summary>
        /// Return instance of <see cref="T:CompropagoSdk.Factory.Models.Webhook"/>
        /// </summary>
        /// <returns>The webhook.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static Webhook Webhook(string source = null)
        {
            if (source == null)
            {
                return new Webhook();
            }

            var obj = JsonConvert.DeserializeObject<Webhook>(source);

            return obj;
        }

        /// <summary>
        /// Return array of <see cref="T:CompropagoSdk.Factory.Models.Webhook"/>
        /// </summary>
        /// <returns>The webhooks.</returns>
        /// <param name="source">Source.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
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