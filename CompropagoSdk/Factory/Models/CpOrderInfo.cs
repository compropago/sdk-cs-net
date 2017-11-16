namespace CompropagoSdk.Factory.Models
{
    public class CpOrderInfo
    {
        public string id { get; set; }
        public string type { get; set; }
        public string Object { get; set; }
        public string created { get; set; }
        public bool paid { get; set; }
        public string amount { get; set; }
        public bool livemode { get; set; }
        public string currency { get; set; }
        public bool refunded { get; set; }
        public string fee { get; set; }
        public FeeDetails fee_details { get; set; }
        public OrderInfo order_info { get; set; }
        public Customer customer { get; set; }
        public bool captured { get; set; }
        public string failure_message { get; set; }
        public string failure_code { get; set; }
        public double amount_refunded { get; set; }
        public string description { get; set; }
        public string dispute { get; set; }

        public CpOrderInfo()
        {
            fee_details = new FeeDetails();
            order_info = new OrderInfo();
            customer = new Customer();
        }
    }
}