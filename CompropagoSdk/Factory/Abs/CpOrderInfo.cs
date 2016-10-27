
using CompropagoSdk.Models;

namespace CompropagoSdk.Factory.Abs
{
    public abstract class CpOrderInfo
    {
        public abstract string getId();
        public abstract string getType();
        public abstract string getCreated();
        public abstract bool getPaid();
        public abstract string getAmount();
        public abstract string getCurrency();
        public abstract bool getRefunded();
        public abstract string getFee();
        public abstract FeeDetails getFeeDetails();
        public abstract OrderInfo getOrderInfo();
        public abstract Customer getCustomer();
        public abstract bool getCaptured();
        public abstract string getFailureMessage();
        public abstract string getFailureCode();
        public abstract float getAmountRefunded();
        public abstract string getDescription();
        public abstract string getDispute();
    }
}
