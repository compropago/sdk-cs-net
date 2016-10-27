using CompropagoSdk.Models;

namespace CompropagoSdk.Factory.Abs
{
    public abstract class NewOrderInfo
    {
        public abstract string getId();
        public abstract string getShortId();
        public abstract string getStatus();
        public abstract string getCreated();
        public abstract string getExpirationDate();
        public abstract OrderInfo getOrderInfo();
        public abstract FeeDetails getFeeDetails();
        public abstract Instructions getInstructions();
    }
}
