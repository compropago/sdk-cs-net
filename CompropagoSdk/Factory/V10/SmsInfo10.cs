
using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V10
{
    class SmsInfo10 : SmsInfo
    {
        public string type { get; set; }
        public string Object { get; set; }
        public SmsPayment payment { get; set; }

        public override string getId()
        {
            return payment.id;
        }

        public override string getObject()
        {
            return Object;
        }

        public override string getShortId()
        {
            return payment.short_id;
        }

        public override string getType()
        {
            return type;
        }
    }
}
