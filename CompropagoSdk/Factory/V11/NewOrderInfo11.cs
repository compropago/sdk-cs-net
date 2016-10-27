using CompropagoSdk.Factory.Abs;
using CompropagoSdk.Models;

namespace CompropagoSdk.Factory.V11
{
    public class NewOrderInfo11 : NewOrderInfo
    {
        public string id { get; set; }
        public string short_id { get; set; }
        public string Object { get; set; }
        public string status { get; set; }
        public string created { get; set; }
        public string exp_date { get; set; }
        public bool live_mode { get; set; }
        public OrderInfo11 order_info { get; set; }
        public FeeDetails11 fee_details { get; set; }
        public Instructions instructions { get; set; } 

        public override string getCreated()
        {
            return created;
        }

        public override string getExpirationDate()
        {
            return exp_date;
        }

        public override FeeDetails getFeeDetails()
        {
            return fee_details;
        }

        public override string getId()
        {
            return id;
        }

        public override Instructions getInstructions()
        {
            return instructions;
        }

        public override OrderInfo getOrderInfo()
        {
            return order_info;
        }

        public override string getShortId()
        {
            return short_id;
        }

        public override string getStatus()
        {
            return status;
        }
    }
}
