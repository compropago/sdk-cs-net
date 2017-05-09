using System;
using System.Collections.Generic;
using NUnit.Framework;
using CompropagoSdk;
using CompropagoSdk.Factory;
using CompropagoSdk.Factory.Models;
using CompropagoSdk.Tools;

namespace UnitTest
{
    [TestFixture]
    public class Tests
    {
        private string _publicKey;
        private string _privateKey;
        private bool _mode;
        private Dictionary<string, string> _orderInfo;
        private string _phoneNumber;
        private double _limit;

        [SetUp]
        public void Init()
        {
            _publicKey = "pk_test_638e8b14112423a086";
            _privateKey = "sk_test_9c95e149614142822f";
            _mode = false;
            _orderInfo = new Dictionary<string, string>
            {
                {"order_id", "ABC"},
                {"order_name", "M4 sdk CS.NET"},
                {"order_price", "5"},
                {"customer_name", "Christian"},
                {"customer_email", "christian@compropago.com"},
                {"payment_type", "OXXO"},
                {"currency", "MXN"}
            };
            _phoneNumber = "5546541385";
            _limit = 15000;
        }

        [Test]
        public void TestCreateclient()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);
				res = client is Client;
            }
            catch (Exception e)
            {
                Console.WriteLine("====>> "+e.Message);
            }

            Assert.True(res);
        }

        [Test]
        public void TestEvalAuth()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);

                var evl = Validations.EvalAuth(client);

                res = (evl is EvalAuthInfo && evl != null);
            }
            catch (Exception e)
            {
                Console.WriteLine("====>> "+e.Message);
            }

            Assert.True(res);
        }

        [Test]
        public void TestProviders()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);

                var providers = client.Api.ListProviders();

                res = providers[0] is Provider;
            }
            catch (Exception e)
            {
                Console.WriteLine("====>> "+e.Message);
            }

            Assert.True(res);
        }

        [Test]
        public void TestProvidersLimit()
        {
            var res = true;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);

                var providers = client.Api.ListProviders(_limit);

                foreach (var provider in providers)
                {
                    if (provider.transaction_limit < _limit)
                    {
                        res = false;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("====>> "+e.Message);
                res = false;
            }

            Assert.True(res);
        }

        [Test]
        public void TestProvidersCurrency()
        {
            var res = true;
            try 
            {
                var client = new Client(_publicKey, _privateKey, _mode);

                var providers = client.Api.ListProviders(700, "USD");

                foreach (var provider in providers)
                {
                    if (provider.transaction_limit < _limit)
                    {
                        res = false;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("====>> " + e.Message);
                res = false;
            }

            Assert.True(res);
        }

        [Test]
        public void TestPlaceOrder()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);
                var order = Factory.PlaceOrderInfo(_orderInfo);
                var newOrder = client.Api.PlaceOrder(order);

                res = newOrder is NewOrderInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine("====>> "+e.Message);
            }

            Assert.True(res);
        }

		[Test]
		public void TestPlaceOrderExpdate()
		{
			var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);

                var time = DateTime.UtcNow - new DateTime(1970, 1, 1);
                var epoch = (int)time.TotalSeconds + (6 * 60 * 60);

                _orderInfo.Add("expiration_time", epoch.ToString());

                var order = Factory.PlaceOrderInfo(_orderInfo);

                var newOrder = client.Api.PlaceOrder(order);

                res = (newOrder is NewOrderInfo) && newOrder.exp_date.Equals(epoch.ToString());
            } 
            catch (Exception e) 
            {
                Console.WriteLine("====>> "+e.Message);
            }

            Assert.True(res);
		}

        [Test]
        public void TestVerifyOrder()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);
                var order = Factory.PlaceOrderInfo(_orderInfo);
                var newOrder = client.Api.PlaceOrder(order);
                var verify = client.Api.VerifyOrder(newOrder.id);

                res = verify is CpOrderInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine("====>> "+e.Message);
            }

            Assert.True(res);
        }

        [Test]
        public void TestSendSmsInstructions()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);
                var order = Factory.PlaceOrderInfo(_orderInfo);
                var newOrder = client.Api.PlaceOrder(order);
                var sms = client.Api.SendSmsInstructions(_phoneNumber, newOrder.id);

                res = sms is SmsInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine("====>> "+e.Message);
            }

            Assert.True(res);
        }

        [Test]
        public void TestListWebhooks()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);
                var webhooks = client.Api.ListWebhooks();

                res = webhooks[0] is Webhook;
            }
            catch (Exception e)
            {
                Console.WriteLine("====>> "+e.Message);
            }

            Assert.True(res);
        }

        [Test]
        public void TestCreateWebhook()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);
                var webhook = client.Api.CreateWebhook("https://misitio.com/webhook/");

                res = webhook is Webhook;
            }
            catch (Exception e)
            {
                Console.WriteLine("====>>"+e.Message);
            }

            Assert.True(res);
        }

        [Test]
        public void TestUpdateWebhook()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);
                var webhook = client.Api.CreateWebhook("https://misitio.com/webhook/");
                var update = client.Api.UpdateWebhook(webhook.id, "https://misitio.com/webhook/dos/");

                res = update is Webhook;
            }
            catch (Exception e)
            {
                Console.WriteLine("====>>"+e.Message);
            }

            Assert.True(res);
        }

        [Test]
        public void TestDeleteWebhook()
        {
            var res = false;
            try
            {
                var client = new Client(_publicKey, _privateKey, _mode);
                var webhook = client.Api.CreateWebhook("https://misitio.com/webhook/dos/");
                var delete = client.Api.DeleteWebhook(webhook.id);

                res = delete is Webhook;
            }
            catch (Exception e)
            {
                Console.WriteLine("====>>"+e.Message);
            }

            Assert.True(res);
        }
    }
}