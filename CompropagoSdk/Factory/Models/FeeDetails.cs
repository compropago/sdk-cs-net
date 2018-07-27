namespace CompropagoSdk.Factory.Models
{
    public class FeeDetails
    {
        public float amount { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public string application { get; set; }
        public float amount_refunded { get; set; }
        public float tax { get; set; }
    }
}