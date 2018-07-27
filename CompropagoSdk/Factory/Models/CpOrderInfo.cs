namespace CompropagoSdk.Factory.Models
{
    public class CpOrderInfo
    {
        public string id { get; set; }
        public string short_id { get; set; }
        public string type { get; set; }
        public string Object { get; set; }
        public int? created_at { get; set; }
        public int? accepted_at { get; set; }
        public int? expires_at { get; set; }
        public bool paid { get; set; }
        public float amount { get; set; }
        public bool livemode { get; set; }
        public string currency { get; set; }
        public bool refunded { get; set; }
        public float fee { get; set; }
        public FeeDetails fee_details { get; set; }
        public OrderInfo order_info { get; set; }
        public Customer customer { get; set; }
        public string api_version { get; set; }

        public CpOrderInfo()
        {
            fee_details = new FeeDetails();
            order_info = new OrderInfo();
            customer = new Customer();
        }
    }
}