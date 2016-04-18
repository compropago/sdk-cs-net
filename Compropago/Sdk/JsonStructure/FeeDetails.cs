
namespace Compropago.Sdk.JsonStructure
{
    public class FeeDetails
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int amount_refunded { get; set; }
        public string tax { get; set; }
        public string tax_percent { get; set; }
    }
}
