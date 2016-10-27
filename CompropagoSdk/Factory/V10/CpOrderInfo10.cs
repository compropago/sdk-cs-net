using CompropagoSdk.Models;
using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V10
{
    public class CpOrderInfo10 : CpOrderInfo
    {
        public string type { get; set; }
        public string Object { get; set; }
        public Data data { get; set; }


        public override string getAmount()
        {
            return data.Object.amount;
        }

        public override float getAmountRefunded()
        {
            return data.Object.amount_refunded;
        }

        public override bool getCaptured()
        {
            return data.Object.captured;
        }

        public override string getCreated()
        {
            return data.Object.created_at;
        }

        public override string getCurrency()
        {
            return data.Object.currency;
        }

        public override Customer getCustomer()
        {
            var customer = new Customer();

            customer.customer_email = data.Object.payment_details.customer_email;
            customer.customer_name = data.Object.payment_details.customer_name;
            customer.customer_phone = data.Object.payment_details.customer_phone;

            return customer;
        }

        public override string getDescription()
        {
            return data.Object.description;
        }

        public override string getDispute()
        {
            return data.Object.dispute;
        }

        public override string getFailureCode()
        {
            return data.Object.failure_code;
        }

        public override string getFailureMessage()
        {
            return data.Object.failure_message;
        }

        public override string getFee()
        {
            return data.Object.fee;
        }

        public override FeeDetails getFeeDetails()
        {
            return data.Object.fee_details;
        }

        public override string getId()
        {
            return data.Object.id;
        }

        public override OrderInfo getOrderInfo()
        {
            var info = new OrderInfo10();

            info.order_id = data.Object.payment_details.product_id;
            info.order_price = data.Object.payment_details.product_price;
            info.order_name = data.Object.payment_details.product_name;
            info.payment_method = data.Object.payment_details.Object;
            info.store = data.Object.payment_details.store;
            info.country = data.Object.payment_details.country;
            info.image_url = data.Object.payment_details.image_url;
            info.success_url = data.Object.payment_details.success_url;

            return info;
        }

        public override bool getPaid()
        {
            return data.Object.paid;
        }

        public override bool getRefunded()
        {
            return data.Object.refunded;
        }

        public override string getType()
        {
            return type;
        }
    }
}
