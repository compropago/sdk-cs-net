using CompropagoSdk.Models;
using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V11
{
    class CpOrderInfo11 : CpOrderInfo
    {
        public string id { get; set; }
        public string type { get; set; }
        public string Object { get; set; }
        public string created { get; set; }
        public bool paid { get; set; }
        public string amount { get; set; }
        public bool livemode { get; set; }
        public string currency { get; set; }
        public bool refunded { get; set; }
        public string fee { get; set; }
        public FeeDetails11 fee_details { get; set; }
        public OrderInfo11 order_info { get; set; }
        public Customer customer { get; set; }
        public bool captured { get; set; }
        public string failure_message { get; set; }
        public string failure_code { get; set; }
        public float amount_refunded { get; set; }
        public string description { get; set; }
        public string dispute { get; set; }

        public override string getId()
        {
            return id;
        }

        public override string getType()
        {
            return type;
        }

        public override string getCreated()
        {
            return created;
        }

        public override bool getPaid()
        {
            return paid;
        }

        public override string getAmount()
        {
            return amount;
        }

        public override string getCurrency()
        {
            return currency;
        }

        public override bool getRefunded()
        {
            return refunded;
        }

        public override string getFee()
        {
            return fee;
        }

        public override FeeDetails getFeeDetails()
        {
            return fee_details;
        }

        public override OrderInfo getOrderInfo()
        {
            return order_info;
        }

        public override Customer getCustomer()
        {
            return customer;
        }

        public override bool getCaptured()
        {
            return captured;
        }

        public override string getFailureMessage()
        {
            return failure_message;
        }

        public override string getFailureCode()
        {
            return failure_code;
        }

        public override float getAmountRefunded()
        {
            return amount_refunded;
        }

        public override string getDescription()
        {
            return description;
        }

        public override string getDispute()
        {
            return dispute;
        }
    }
}
