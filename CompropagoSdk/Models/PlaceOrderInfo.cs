
namespace CompropagoSdk.Models
{
    class PlaceOrderInfo
    {
        public string order_id { get; set; }
        public string order_name { get; set; }
        public float order_price { get; set; }
        public string customer_name { get; set; }
        public string customer_email { get; set; }
        public string payment_type { get; set; }
        public string image_url { get; set; }

        /**
         * @param string order_id          Id de la orden
         * @param string order_name        Nombre del producto o productos de la orden
         * @param float  order_price       Monto total de la orden
         * @param string customer_name     Nombre completo del cliente
         * @param string customer_email    Correo electronico del cliente
         * @param string payment_type      (default = OXXO) Valor del atributo internal_name' de un objeto 'Provider' 
         * @param string image_url         (optional) Url a la imagen del producto
         */
        public PlaceOrderInfo(string order_id, string order_name, float order_price, string customer_name, string customer_email, string payment_type = "OXXO", string image_url = null)
        {
            this.order_id       = order_id;
            this.order_name     = order_name;
            this.order_price    = order_price;
            this.customer_name  = customer_name;
            this.customer_email = customer_email;
            this.payment_type   = payment_type;
            this.image_url      = image_url;
        }
    }
}
