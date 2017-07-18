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
        static string publickey;
        static string privatekey;
        static bool mode;
        //static Dictionary<string, string> _orderInfo;
		//private string _phoneNumber;
		//private double _limit;

		[STAThread]
        static int Main(string[] args)
		{
            publickey = "pk_test_638e8b14112423a086";
            privatekey = "sk_test_9c95e149614142822f";
            mode = false;

            var client = new Client(publickey, privatekey, mode);

			var order_info = new Dictionary<string, string>
            {
                {"order_id", "ComProPago"},
			    {"order_name", "0268229"},
			    {"order_price", "259.0"},
			    {"customer_name", "herbax"},
			    {"customer_email", "zaaxa@xsxf.com"},
                {"payment_type",   "OXXO"},
	            {"currency", "MXN"}
			};

			var order = Factory.PlaceOrderInfo(order_info);

			/**
			 * Llamada al metodo 'PlaceOrder' del API para generar la orden
			 */
			var newOrder = client.Api.PlaceOrder(order);
            Console.WriteLine(newOrder.id);


            return 0;
        }
    }
}

