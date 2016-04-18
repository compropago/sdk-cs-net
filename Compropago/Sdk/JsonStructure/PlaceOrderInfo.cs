
namespace Compropago.Sdk.JsonStructure
{
    public class PlaceOrderInfo
    {
        public string order_id { get; set; }
        public double order_price { get; set; }
        public string order_name { get; set; }        
        public string image_url { get; set; }
        public string customer_name { get; set; }
        public string customer_email { get; set; }
        public string payment_type { get; set; }

        public PlaceOrderInfo(string order_id, double order_price, string order_name, string customer_name, string customer_email, string payment_type = "OXXO", string image_url = null)
        {
            this.order_id = order_id;
            this.order_price = order_price;
            this.order_name = order_name;
            this.image_url = image_url;
            this.customer_name = customer_name;
            this.customer_email = customer_email;
            this.payment_type = payment_type;
        }
    }
}
