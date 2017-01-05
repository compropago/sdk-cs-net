namespace CompropagoSdk.Factory.Models
{
    public class SmsInfo
    {
        public string type { get; set; }
        public string Object { get; set; }
        public SmsData data { get; set; }

        public SmsInfo()
        {
            data = new SmsData();
        }
    }
}