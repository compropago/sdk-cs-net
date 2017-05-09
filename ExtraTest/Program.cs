using System;
using System.Collections.Generic;
using CompropagoSdk;
using CompropagoSdk.Factory.Models;


namespace ExtraTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var client = new Client("pk_test_638e8b14112423a086", "sk_test_9c95e149614142822f", false);

            var list = client.Api.ListProviders();

            foreach(Provider prov in list) {
                Console.WriteLine(prov.name);
            }
        }
    }
}