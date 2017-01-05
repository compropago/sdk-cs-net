using System;
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

        public List<Provider> ListProviders(bool auth = false, double limit = 0, string currency = "MXN")
        {
            string url;
            Dictionary<string, string> keys;

            if (auth)
            {
                url = _client.DeployUri + "providers/";
                keys = new Dictionary<string,string> { {"user", _client.GetUser()}, {"pass", _client.GetPass()} };
            }
            else
            {
                url = _client.DeployUri + "providers/true/";
                keys = null;
            }

            if (limit > 0)
            {
                url += "?order_total=" + limit;
            }

            if (limit > 0 && currency != "" && currency != "MXN")
            {
                url += "&currency=" + currency;
            }

            Console.WriteLine(url);

            var response = Request.Get(url, keys);

            return Factory.Factory.ListProviders(response);
        }

        public CpOrderInfo VerifyOrder(string orderId)
        {
            var response = Request.Get(
                _client.DeployUri + "charges/" + orderId + "/",
                new Dictionary<string,string> { {"user", _client.GetUser()}, {"pass", _client.GetPass()} }
            );

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
                {"image_url", order.image_url},
                {"app_client_name", order.app_client_name},
                {"app_client_version", order.app_client_version}
            };

            var response = Request.Post(
                _client.DeployUri + "charges/",
                data,
                new Dictionary<string,string> { {"user", _client.GetUser()}, {"pass", _client.GetPass()} }
            );

            return Factory.Factory.NewOrderInfo(response);
        }

        public SmsInfo SendSmsInstructions(string phone, string orderId)
        {
            var data = new Dictionary<string,string>
            {
                {"customer_phone", phone}
            };

            var response = Request.Post(
                _client.DeployUri + "charges/" + orderId + "/sms/",
                data,
                new Dictionary<string,string> { {"user", _client.GetUser()}, {"pass", _client.GetPass()} }
            );

            return Factory.Factory.SmsInfo(response);
        }

        public List<Webhook> ListWebhooks()
        {
            var response = Request.Get(
                _client.DeployUri + "webhooks/stores/",
                new Dictionary<string,string> { {"user", _client.GetUser()}, {"pass", _client.GetPass()} }
            );

            return Factory.Factory.ListWebhooks(response);
        }

        public Webhook CreateWebhook(string url)
        {
            var data = new Dictionary<string, string>
            {
                {"url", url}
            };

            var response = Request.Post(
                _client.DeployUri + "webhooks/stores/",
                data,
                new Dictionary<string, string> { {"user", _client.GetUser()}, {"pass", _client.GetPass()} }
            );

            return Factory.Factory.Webhook(response);
        }

        public Webhook UpdateWebhook(string webhookId, string url)
        {
            var data = new Dictionary<string, string>
            {
                {"url", url}
            };

            var response = Request.Put(
                _client.DeployUri + "webhooks/stores/" + webhookId + "/",
                data,
                new Dictionary<string, string> { {"user", _client.GetUser()}, {"pass", _client.GetPass()} }
            );

            return Factory.Factory.Webhook(response);
        }

        public Webhook DeleteWebhook(string webhookId)
        {
            var response = Request.Delete(
                _client.DeployUri + "webhooks/stores/" + webhookId + "/",
                null,
                new Dictionary<string, string> { {"user", _client.GetUser()}, {"pass", _client.GetPass()} }
            );

            return Factory.Factory.Webhook(response);
        }
    }
}