using System.Collections.Generic;
using System.Globalization;
using CompropagoSdk.Factory.Models;
using CompropagoSdk.Tools;

namespace CompropagoSdk
{
    public class Service
    {

        private readonly Client _client;

        public Service(Client client)
        {
            _client = client;
        }

        private Dictionary<string, string> getAuth()
        {
            return new Dictionary<string, string> { 
                { "user", _client.GetUser() }, 
                { "pass", _client.GetPass() } 
            };
        }

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

        public CpOrderInfo VerifyOrder(string orderId)
        {
            var response = Request.Get(_client.DeployUri + "charges/" + orderId + "/", getAuth());
            return Factory.Factory.CpOrderInfo(response);
        }

        public NewOrderInfo PlaceOrder(PlaceOrderInfo order)
        {
            var data = new Dictionary<string,string>
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

            var response = Request.Post(_client.DeployUri + "charges/", data, getAuth());
            return Factory.Factory.NewOrderInfo(response);
        }

        public SmsInfo SendSmsInstructions(string phone, string orderId)
        {
            var data = new Dictionary<string,string>
            {
                {"customer_phone", phone}
            };

            var response = Request.Post(_client.DeployUri + "charges/" + orderId + "/sms/", data, getAuth());
            return Factory.Factory.SmsInfo(response);
        }

        public Webhook[] ListWebhooks()
        {
            var response = Request.Get(_client.DeployUri + "webhooks/stores/", getAuth());
            return Factory.Factory.ListWebhooks(response);
        }

        public Webhook CreateWebhook(string url)
        {
            var data = new Dictionary<string, string>
            {
                {"url", url}
            };

            var response = Request.Post(_client.DeployUri + "webhooks/stores/", data, getAuth());
            return Factory.Factory.Webhook(response);
        }

        public Webhook UpdateWebhook(string webhookId, string url)
        {
            var data = new Dictionary<string, string>
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