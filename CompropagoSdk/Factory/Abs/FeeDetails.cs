
namespace CompropagoSdk.Factory.Abs
{
    public abstract class FeeDetails
    {
        public abstract string getAmount();
        public abstract string getCurrency();
        public abstract string getType();
        public abstract string getDescription();
        public abstract string getApplication();
        public abstract string getAmountRefunded();
        public abstract string getTax();
    }
}
