using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V10
{
    public class FeeDetails10 : FeeDetails
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string application { get; set; }
        public string amount_refunded { get; set; }

        public override string getAmount()
        {
            return amount;
        }

        public override string getAmountRefunded()
        {
            return amount_refunded;
        }

        public override string getApplication()
        {
            return application;
        }

        public override string getCurrency()
        {
            return currency;
        }

        public override string getDescription()
        {
            return description;
        }

        public override string getTax()
        {
            return null;
        }

        public override string getType()
        {
            return type;
        }
    }
}
