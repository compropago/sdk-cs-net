namespace CompropagoSdk.Factory.Models
{
    public class SmsData
    {
        public SmsObject Object { get; set; }

        public SmsData()
        {
            Object = new SmsObject();
        }
    }
}