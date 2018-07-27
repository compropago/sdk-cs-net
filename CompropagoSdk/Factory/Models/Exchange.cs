namespace CompropagoSdk.Factory.Models
{
    public class Exchange
    {
        public float rate { get; set; }
        public string request { get; set; }
        public float origin_amount { get; set; }
        public string origin_currency { get; set; }
        public float final_amount { get; set; }
        public string final_currency { get; set; }
        public string exchange_id { get; set; }
    }
}
