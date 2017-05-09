using System;
using System.Collections.Generic;
using CompropagoSdk;
using CompropagoSdk.Factory;
using CompropagoSdk.Factory.Models;
using CompropagoSdk.Tools;


namespace ExtraTest
{

    public class Program
    {
        static string publicKey;
        static string privateKey;
        static bool mode;
        //static Dictionary<string, string> _orderInfo;
		//private string _phoneNumber;
		//private double _limit;

		[STAThread]
        static int Main(string[] args)
		{
            publicKey = "pk_test_638e8b14112423a086";
            privateKey = "sk_test_9c95e149614142822f";
            mode = false;
            //_phoneNumber = "5546541385";
            //_limit = 15000;
            mode = false;

            var client = new Client(
            publicKey,  // publickey
            privateKey,  // privatekey
			 mode                         // live
             );

            var providers = client.Api.ListProviders(1000, "MXN");
			foreach (var provider in providers)
			{
				Console.WriteLine(provider.name);
			}


			var order_info = new Dictionary<string, string>
			{
				{"order_id", "123"},
				{"order_name", "M4 sdk CS.NET"},
				{"order_price", "123.45"},
				{"customer_name", "Eduardo"},
				{"customer_email", "eduardo.aguilar@compropago.com"},
				{"payment_type", "SEVEN_ELEVEN"},
				{"currency", "USD"}
			};

			var order = Factory.PlaceOrderInfo(order_info);

			/**
			 * Llamada al metodo 'PlaceOrder' del API para generar la orden
			 */
			var newOrder = client.Api.PlaceOrder(order);
            Console.WriteLine(newOrder);


            return 0;
        }
    }
}

