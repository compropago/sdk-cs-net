using System.Collections.Generic;
using System.Globalization;
using CompropagoSdk.Factory.Models;
using CompropagoSdk.Tools;

namespace CompropagoSdk
{
    public class Service
    {

        private readonly Client _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CompropagoSdk.Service"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public Service(Client client)
        {
            _client = client;
        }

        /// <summary>
        /// Gets the auth.
        /// </summary>
        /// <returns>The auth Dictionary.</returns>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        private Dictionary<string, string> getAuth()
        {
            return new Dictionary<string, string> { 
                { "user", _client.GetUser() }, 
                { "pass", _client.GetPass() } 
            };
        }

        /// <summary>
        /// Lists the providers available for the account.
        /// </summary>
        /// <returns>The providers.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="currency">Currency.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public Provider[] ListProviders(double limit = 0, string currency = "MXN")
        {
            string url = _client.DeployUri + "providers/";

            if (limit > 0)
            {
                url += "?order_total=" + limit;
            }

            if (limit > 0 && currency != "" && currency != "MXN")
            {
                url += "&currency=" + currency;
            }

            var response = Request.Get(url, getAuth());

            return Factory.Factory.ListProviders(response);
        }

        /// <summary>
        /// Verifies the order.
        /// </summary>
        /// <returns>The order.</returns>
        /// <param name="orderId">Order identifier.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public CpOrderInfo VerifyOrder(string orderId)
        {
            var response = Request.Get(_client.DeployUri + "charges/" + orderId + "/", getAuth());
            return Factory.Factory.CpOrderInfo(response);
        }

        /// <summary>
        /// Places the order.
        /// </summary>
        /// <returns>The order.</returns>
        /// <param name="order">Order.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public NewOrderInfo PlaceOrder(PlaceOrderInfo order)
        {
            var data = new Dictionary<string, object>
            {
                {"order_id", order.order_id},
                {"order_name", order.order_name},
                {"order_price", order.order_price.ToString(CultureInfo.InvariantCulture)},
                {"customer_name", order.customer_name},
                {"customer_email", order.customer_email},
                {"payment_type", order.payment_type},
                {"currency", order.currency},
                {"expiration_time", order.expiration_time},
                {"image_url", order.image_url},
                {"app_client_name", order.app_client_name},
                {"app_client_version", order.app_client_version}
            };


            var response = Request.Post(_client.DeployUri +"charges/", data, getAuth());
            return Factory.Factory.NewOrderInfo(response);
        }

        /// <summary>
        /// Sends the sms instructions.
        /// </summary>
        /// <returns>The sms instructions.</returns>
        /// <param name="phone">Phone.</param>
        /// <param name="orderId">Order identifier.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public SmsInfo SendSmsInstructions(string phone, string orderId)
        {
            var data = new Dictionary<string,object>
            {
                {"customer_phone", phone}
            };

            var response = Request.Post(_client.DeployUri + "charges/" + orderId + "/sms/", data, getAuth());
            return Factory.Factory.SmsInfo(response);
        }

        /// <summary>
        /// Lists the webhooks.
        /// </summary>
        /// <returns>The webhooks.</returns>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public Webhook[] ListWebhooks()
        {
            var response = Request.Get(_client.DeployUri + "webhooks/stores/", getAuth());
            return Factory.Factory.ListWebhooks(response);
        }

        /// <summary>
        /// Creates the webhook.
        /// </summary>
        /// <returns>The webhook.</returns>
        /// <param name="url">URL.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public Webhook CreateWebhook(string url)
		{
            var data = new Dictionary<string, object>
			{
				{"url", url}
			};

			var response = Request.Post(_client.DeployUri + "webhooks/stores/", data, getAuth());
			return Factory.Factory.Webhook(response);
		}

        /// <summary>
        /// Updates the webhook.
        /// </summary>
        /// <returns>The webhook.</returns>
        /// <param name="webhookId">Webhook identifier.</param>
        /// <param name="url">URL.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public Webhook UpdateWebhook(string webhookId, string url)
        {
            var data = new Dictionary<string, object>
            {
                {"url", url}
            };

            var response = Request.Put(_client.DeployUri + "webhooks/stores/" + webhookId + "/", data, getAuth());
            return Factory.Factory.Webhook(response);
        }

        public Webhook DeleteWebhook(string webhookId)
        {
            var response = Request.Delete(_client.DeployUri + "webhooks/stores/" + webhookId + "/", null, getAuth());
            return Factory.Factory.Webhook(response);
        }
    }
}