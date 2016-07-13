
namespace CompropagoSdk.Factory.Abs
{
    public abstract class OrderInfo
    {
        public abstract string getOrderId();
        public abstract string getOrderPrice();
        public abstract string getOrderName();
        public abstract string getPaymentMethod();
        public abstract string getStore();
        public abstract string getCountry();
        public abstract string getImageUrl();
        public abstract string getSuccessUrl();
    }
}
