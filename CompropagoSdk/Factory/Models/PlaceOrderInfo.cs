namespace CompropagoSdk.Factory.Models
{
    public class PlaceOrderInfo
    {
        public string order_id { get; set; }
        public string order_name { get; set; }
        public double order_price { get; set; }
        public string customer_name { get; set; }
        public string customer_email { get; set; }
        public string payment_type { get; set; }
        public string currency { get; set; }
		public string expiration_time { get; set; }
        public string image_url { get; set; }
        public string app_client_name { get; set; }
        public string app_client_version { get; set; }

        public PlaceOrderInfo(
            string order_id,
            string order_name,
            double order_price,
            string customer_name,
            string customer_email,
            string payment_type = "OXXO",
            string currency = "MXN",
			string expiration_time = null,
            string image_url = "",
            string app_client_name = "sdk-cs",
            string app_client_version = null
        )
        {
            this.order_id = order_id;
            this.order_name = order_name;
            this.order_price = order_price;
            this.customer_name = customer_name;
            this.customer_email = customer_email;
            this.payment_type = payment_type;
            this.currency = currency;
			this.expiration_time = expiration_time;
            this.image_url = image_url;
            this.app_client_name = app_client_name;
            this.app_client_version = app_client_version.Equals(null) ? Client.Version : app_client_version;
        }
    }
}