using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using CompropagoSdk.Tools;
using CompropagoSdk.Models;
using CompropagoSdk.Factory.Abs;


namespace CompropagoSdk
{
    class Service
    {
        private Client client { get; set; }
        private Dictionary<string, string> headers = new Dictionary<string, string>();

        public Service(Client client)
        {
            this.client = client;
            headers.Add("useragent",client.getContained());
        }


        /**
         * Obtiene el listado de proveedores diponibles
         * 
         * @param bool  auth  = false   Forzar Autentificación
         * @param float limit = 0       Filtrar por limite de transacción
         * @param bool  fetch = false   Forzar recuperación de proveedores por base de datos
         * @return List<Provider>
         */     
        public List<Provider> listProviders(bool auth = false, float limit = 0, bool fetch = false)
        {
            if (auth)
            {
                Validations.validateGateway(this.client);
            }

            string uri = auth ? this.client.getUri() + "providers" : this.client.getUri() + "providers/true";

            uri = (limit > 0) ? uri + "?order_total=" + limit : uri;

            uri = fetch ? (
                (limit > 0) ? uri + "&fetch=true" : uri + "?fetch=true"
            ) : uri;

            Uri requestUri = null;
            Uri.TryCreate(uri, UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "GET";

            if (auth)
            {
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Authorization", string.Concat("Basic ",
                    (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}", this.client.getFullAuth()))))));
            }



            foreach (KeyValuePair<string, string> entry in this.headers)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }



            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            var resp = reader.ReadToEnd();

            var obj = Factory.Factory.listProviders(resp);

            return obj;
        }


        /**
         * Verifica las datos de una orden en especifico
         * 
         * @param string orderId        Id de orden generada por ComproPago
         * @return CpOrderInfo
         */ 
        public CpOrderInfo verifyOrder(string orderId)
        {
            Validations.validateGateway(this.client);

            var uri = this.client.getUri() + "charges/" + orderId;

            Uri requestUri = null;
            Uri.TryCreate(uri, UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "GET";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", string.Concat("Basic ",
                (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}", this.client.getFullAuth()))))));

            foreach (KeyValuePair<string, string> entry in this.headers)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            var resp = reader.ReadToEnd();

            var obj = Factory.Factory.cpOrderInfo(resp);

            return obj;
        }


        /**
         * Genera ordenes de compra
         * 
         * @param PlaceOrderInfo info   Objeto con la informacion de la orden de compra
         * @return NewOrderInfo 
         */ 
        public NewOrderInfo placeOrder(PlaceOrderInfo info)
        {
            Validations.validateGateway(this.client);

            var append =
                "order_id=" + info.order_id +
                "&order_price=" + info.order_price +
                "&order_name=" + info.order_name +
                "&customer_name=" + info.customer_name +
                "&customer_email=" + info.customer_email +
                "&image_url=" + info.image_url +
                "&payment_type=" + info.payment_type +
                "&app_client_name" + info.app_client_name +
                "&app_client_version" + info.app_client_version;

            var uri = this.client.getUri() + "charges/";

            var postUrl = new StringBuilder();
            postUrl.Append(append);

            byte[] formBytes = ASCIIEncoding.Default.GetBytes(postUrl.ToString());

            Uri requestUri = null;
            Uri.TryCreate(uri, UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "POST";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", string.Concat("Basic ",
                (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}", this.client.getFullAuth()))))));

            foreach (KeyValuePair<string, string> entry in this.headers)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }

            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(formBytes, 0, formBytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            var resp = reader.ReadToEnd();

            var obj = Factory.Factory.newOrderInfo(resp);

            return obj;
        }


        /**
         * Envia las instrucciones de pago de una orden generada
         * 
         * @param string number         Numero al que se enviaran las instrucciones (10 digitos)
         * @param string orderId        Id de orden generada por ComproPago
         * @return SmsInfo
         */ 
        public SmsInfo sendSmsInstructions(string number, string orderId)
        {
            Validations.validateGateway(client);

            var append = "customer_phone=" + number;

            var uri = this.client.getUri() + "charges/"+orderId+"/sms";

            var postUrl = new StringBuilder();
            postUrl.Append(append);

            byte[] formBytes = ASCIIEncoding.Default.GetBytes(postUrl.ToString());

            Uri requestUri = null;
            Uri.TryCreate(uri, UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "POST";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", string.Concat("Basic ",
                (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}", this.client.getFullAuth()))))));

            foreach (KeyValuePair<string, string> entry in this.headers)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }

            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(formBytes, 0, formBytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            var resp = reader.ReadToEnd();

            var obj = Factory.Factory.smsInfo(resp);

            return obj;
        }


        /**
         * Registra un nuevo WebHook
         * 
         * @param string url            Url del webhook a registrar
         * @return Webhook
         */ 
        public Webhook createWebhook(string url)
        {
            Validations.validateGateway(client);

            var append = "url=" + url;

            var uri = this.client.getUri() + "webhooks/stores";

            var postUrl = new StringBuilder();
            postUrl.Append(append);

            byte[] formBytes = ASCIIEncoding.Default.GetBytes(postUrl.ToString());

            Uri requestUri = null;
            Uri.TryCreate(uri, UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "POST";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", string.Concat("Basic ",
                (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}", this.client.getFullAuth()))))));

            foreach (KeyValuePair<string, string> entry in this.headers)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }

            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(formBytes, 0, formBytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            var resp = reader.ReadToEnd();

            var obj = Factory.Factory.webhook(resp);

            return obj;
        }


        /**
         * Regresa el listado de los webhooks existentes de una cuenta
         * 
         * @return List<Webhook>
         */ 
        public List<Webhook> listWebhooks()
        {
            Validations.validateGateway(client);

            var uri = this.client.getUri() + "webhooks/stores";

            Uri requestUri = null;
            Uri.TryCreate(uri, UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "GET";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", string.Concat("Basic ",
                (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}", this.client.getFullAuth()))))));

            foreach (KeyValuePair<string, string> entry in this.headers)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            var resp = reader.ReadToEnd();

            var obj = Factory.Factory.listWebhooks(resp);

            return obj;
        }


        /**
         * Actualiza la URL de un webhook
         * 
         * @param string webhookId       Id del webhook que se desea actualizar
         * @param string url             Url nueva del webhook
         * @return Webhook
         */ 
        public Webhook updateWebhook(string webhookId, string url)
        {
            Validations.validateGateway(client);

            var append = "url=" + url;

            var uri = this.client.getUri() + "webhooks/stores/"+webhookId;

            var postUrl = new StringBuilder();
            postUrl.Append(append);

            byte[] formBytes = ASCIIEncoding.Default.GetBytes(postUrl.ToString());

            Uri requestUri = null;
            Uri.TryCreate(uri, UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "PUT";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", string.Concat("Basic ",
                (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}", this.client.getFullAuth()))))));

            foreach (KeyValuePair<string, string> entry in this.headers)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }

            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(formBytes, 0, formBytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            var resp = reader.ReadToEnd();

            var obj = Factory.Factory.webhook(resp);

            return obj;
        }


        /**
         * Eliminar un webhook
         * 
         * @param string webhookId       Id del webhook registrado
         * @return Webhook
         */ 
        public Webhook deleteWebhook(string webhookId)
        {
            Validations.validateGateway(client);

            var uri = this.client.getUri() + "webhooks/stores/" + webhookId;

            Uri requestUri = null;
            Uri.TryCreate(uri, UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "DELETE";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", string.Concat("Basic ",
                (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}", this.client.getFullAuth()))))));

            foreach (KeyValuePair<string, string> entry in this.headers)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            var resp = reader.ReadToEnd();

            var obj = Factory.Factory.webhook(resp);

            return obj;
        }
    }
}
