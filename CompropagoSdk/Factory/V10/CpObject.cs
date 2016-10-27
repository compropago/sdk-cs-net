
namespace CompropagoSdk.Factory.V10
{
    public class CpObject
    {
        public string id { get; set; }
        public string Object { get; set; }
        public string created_at { get; set; }
        public bool paid { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public bool refunded { get; set; }
        public string fee { get; set; }
        public FeeDetails10 fee_details { get; set; }
        public PaymentDetails payment_details { get; set; }
        public bool captured { get; set; }
        public string failure_message { get; set; }
        public string failure_code { get; set; }
        public float amount_refunded { get; set; }
        public string description { get; set; }
        public string dispute { get; set; }
    }
}
