namespace CompropagoSdk.Factory.Models
{
    public class NewOrderInfo
    {
        public string id { get; set; }
        public string short_id { get; set; }
        public string Object { get; set; }
        public string status { get; set; }
        public string created { get; set; }
        public string exp_date { get; set; }
        public bool live_mode { get; set; }
        public OrderInfo order_info { get; set; }
        public FeeDetails fee_details { get; set; }
        public Instructions instructions { get; set; }

        public NewOrderInfo()
        {
            order_info = new OrderInfo();
            fee_details = new FeeDetails();
            instructions = new Instructions();
        }
    }
}