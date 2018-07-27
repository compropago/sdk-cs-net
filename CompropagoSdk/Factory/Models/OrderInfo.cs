namespace CompropagoSdk.Factory.Models
{
    public class OrderInfo
    {
        public string order_id { get; set; }
        public float order_price { get; set; }
        public string order_name { get; set; }
        public string payment_method { get; set; }
        public string store { get; set; }
        public string country { get; set; }
        public string image_url { get; set; }
        public string success_url { get; set; }
        public string failed_url { get; set; }
        public Exchange exchange { get; set; }

        public OrderInfo()
        {
            this.exchange = new Exchange();
        }
    }
}