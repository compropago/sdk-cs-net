
namespace Compropago.Sdk.JsonStructure
{
    public class SmsInfo
    {
        public string type { get; set; }
        public string Object { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public ObjectSmsInfo Object { get; set; }
    }

    public class ObjectSmsInfo
    {
        public string id { get; set; }
        public string Object { get; set; }
        public string short_id { get; set; }
    }
}
