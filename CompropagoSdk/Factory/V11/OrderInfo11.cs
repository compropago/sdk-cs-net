using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V11
{
    public class OrderInfo11 : OrderInfo
    {
        public string order_id { get; set; }
        public string order_price { get; set; }
        public string order_name { get; set; }
        public string payment_method { get; set; }
        public string store { get; set; }
        public string country { get; set; }
        public string image_url { get; set; }
        public string success_url { get; set; }

        public override string getCountry()
        {
            return country;
        }

        public override string getImageUrl()
        {
            return image_url;
        }

        public override string getOrderId()
        {
            return order_id;
        }

        public override string getOrderName()
        {
            return order_name;
        }

        public override string getOrderPrice()
        {
            return order_price;
        }

        public override string getPaymentMethod()
        {
            return payment_method;
        }

        public override string getStore()
        {
            return store;
        }

        public override string getSuccessUrl()
        {
            return success_url;
        }
    }
}
