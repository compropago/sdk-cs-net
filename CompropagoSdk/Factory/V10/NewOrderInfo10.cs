using System;
using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V10
{
    class NewOrderInfo10 : NewOrderInfo
    {
        public string payment_id { get; set; }
        public string short_paymanet_id { get; set; }
        public string payment_status { get; set; }
        public string creation_date { get; set; }
        public string expiration_date { get; set; }
        public ProductInformation product_information { get; set; }
        public Instructions10 payment_instructions { get; set; } 

        public override string getCreated()
        {
            return creation_date;
        }

        public override string getExpirationDate()
        {
            return expiration_date;
        }

        public override FeeDetails getFeeDetails()
        {
            return null;
        }

        public override string getId()
        {
            return payment_id;
        }

        public override Instructions getInstructions()
        {
            return payment_instructions;
        }

        public override OrderInfo getOrderInfo()
        {
            var info = new OrderInfo10();

            info.order_id    = product_information.product_id;
            info.order_name  = product_information.product_name;
            info.order_price = product_information.product_price.ToString();
            info.image_url   = product_information.image_url;

            return info;
        }

        public override string getShortId()
        {
            return short_paymanet_id;
        }

        public override string getStatus()
        {
            return payment_status;
        }
    }
}
