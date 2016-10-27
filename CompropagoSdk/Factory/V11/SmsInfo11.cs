
using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V11
{
    public class SmsInfo11 : SmsInfo
    {
        public string type { get; set; }
        public string Object { get; set; }
        public SmsData data { get; set; }

        public override string getId()
        {
            return data.Object.id;
        }

        public override string getObject()
        {
            return data.Object.Object;
        }

        public override string getShortId()
        {
            return data.Object.short_id;
        }

        public override string getType()
        {
            return type;
        }
    }
}
