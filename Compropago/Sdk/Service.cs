/**
 * @author Eduardo Aguilar <eduardo.aguilar@compropago.com>
 */

using System.Net;
using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compropago.Sdk.Utils;
using Compropago.Sdk.Exceptions;
using Compropago.Sdk.JsonStructure;


/**
 * Clase que provee los servicios consumibles de ComproPago
 * 
 * @var client      Compropago.Sdk.Client
 * 
 * @method getProviders         List<Compropago.Sdk.JsonStructure.Provider>
 * @method verifyOrder          Compropago.Sdk.JsonStructure.CompropagoOrderInfo
 * @method sendSmsInstructions  Compropago.Sdk.JsonStructure.SmsInfo
 * @method placeOrder           Compropago.Sdk.JsonStructure.NewOrderInfo
 * 
 * @construct Compropago.Sdk.Client
 */

namespace Compropago.Sdk
{
    public class Service
    {
        private Client client { get; }
       
        public Service(Client client)
        {
            this.client = client;
        }

        /**
         * Retorna el listado de proveedores ordernados por rank
         * 
         * @throw Compropago.Sdk.Exceptions.BaseException
         * @return List<Compropago.Sdk.JsonStructure.Provider>
         */
        public List<Provider> getProviders()
        {
            List<Provider> providers = null;

            string stripe;

            try
            {
                string uri = client.getSsl() + client.getUri() + "providers/true/";
                Uri requestUri = null;
                Uri.TryCreate((uri), UriKind.Absolute, out requestUri);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
                request.Method = "GET";

                StreamReader reader;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream respStream = response.GetResponseStream();

                reader = new StreamReader(respStream);
                stripe = reader.ReadToEnd();
                
                var serializer = new JavaScriptSerializer();

                providers = serializer.Deserialize<List<Provider>>(stripe);
                providers = providers.OrderBy(o => o.rank).ToList();
            }
            catch (Exception e)
            {
                throw new BaseException(e.Message);
            }

            return providers;
        }

        /**
         * Verifica la orden ce compra mediante su ID
         * 
         * @var orderId string 
         * @throw Compropago.Sdk.Exceptions.BaseException
         * @return Compropago.Sdk.JsonStructure.CompropagoOrderInfo
         */
        public CompropagoOrderInfo verifyOrder(string orderId)
        {
            string uri = client.getSsl() + client.getUri() + "charges/" + orderId + "/";
            string stripe;

            try
            {
                Uri requestUri = null;
                Uri.TryCreate((uri), UriKind.Absolute, out requestUri);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Authorization", string.Concat("Basic ",
                    (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", client.getAuth()))))));

                StreamReader reader;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream respStream = response.GetResponseStream();

                reader = new StreamReader(respStream);
                stripe = reader.ReadToEnd();

                var serializer = new JavaScriptSerializer();
                CompropagoOrderInfo orderInfo = serializer.Deserialize<CompropagoOrderInfo>(stripe);

                return orderInfo;

            }
            catch (Exception e)
            {
                throw new BaseException(e.Message, e);
            }

        }

        /**
         * Envia las instrucciones SMS de una ordern de compra
         * 
         * @var phoneNumber string
         * @var orderId     string
         * @throw Compropago.Sdk.Exceptions.BaseException
         */
        public SmsInfo sendSmsInstructions(string phoneNumber, string orderId)
        {
            if(string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(orderId))
            {
                throw new BaseException("No se reconoce la informacion para envio Sms");
            }

            string toappend = "customer_phone=" + phoneNumber;
            string uri = client.getSsl() + client.getUri() + "charges/" + orderId + "/sms/";
            string stripe = null;

            try
            {
                if (Validations.validateGateway(client))
                {
                    var postUrl = new StringBuilder();
                    postUrl.Append(toappend);

                    byte[] formbytes = ASCIIEncoding.Default.GetBytes(postUrl.ToString());

                    Uri requestUri = null;
                    Uri.TryCreate((uri), UriKind.Absolute, out requestUri);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Authorization", string.Concat("Basic ",
                        (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", client.getAuth()))))));

                    using (Stream postStream = request.GetRequestStream())
                    {
                        postStream.Write(formbytes, 0, formbytes.Length);
                    }

                    StreamReader reader;

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream respStream = response.GetResponseStream();

                    reader = new StreamReader(respStream);
                    stripe = reader.ReadToEnd();

                    var serializer = new JavaScriptSerializer();
                    SmsInfo info = serializer.Deserialize<SmsInfo>(stripe);

                    return info;
                }

                throw new BaseException("No se permiten operaciones.");
                
            }
            catch (Exception e)
            {
                throw new BaseException(e.Message, e);
            }
        }

        /**
         * Genera una orden de compra
         * 
         * @var order       Compropago.Sdk.JsonStructure.PlaceOrderInfo
         * @throw   Compropago.Sdk.Exceptions.BaseException
         * @return  Compropago.Sdk.JsonStructure.NewOrderInfo 
         */
        public NewOrderInfo placeOrder(PlaceOrderInfo order)
        {
            string toappend =
                "order_id=" + order.order_id +
                "&order_price=" + order.order_price +
                "&order_name=" + order.order_name +
                "&customer_name=" + order.customer_name +
                "&customer_email=" + order.customer_email +
                "&image_url=" + order.image_url +
                "&payment_type=" + order.payment_type ;

            string uri = client.getSsl() + client.getUri() + "charges/";
            string stripe = null;

            try
            {
                if (Validations.validateGateway(client))
                {
                    var postUrl = new StringBuilder();
                    postUrl.Append(toappend);

                    byte[] formbytes = ASCIIEncoding.Default.GetBytes(postUrl.ToString());

                    Uri requestUri = null;
                    Uri.TryCreate((uri), UriKind.Absolute, out requestUri);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Authorization", string.Concat("Basic ",
                        (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", client.getAuth()))))));

                    using (Stream postStream = request.GetRequestStream())
                    {
                        postStream.Write(formbytes, 0, formbytes.Length);
                    }

                    StreamReader reader;

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream respStream = response.GetResponseStream();

                    reader = new StreamReader(respStream);
                    stripe = reader.ReadToEnd();

                    var serializer = new JavaScriptSerializer();
                    NewOrderInfo neworder = serializer.Deserialize<NewOrderInfo>(stripe);

                    if (string.IsNullOrEmpty(neworder.id))
                    {
                        GeneralError error = serializer.Deserialize<GeneralError>(stripe);
                        throw new BaseException(error.message);
                    }

                    return neworder;
                }

                throw new BaseException("No se permiten transacciones.");
                
            }
            catch (Exception e)
            {
                throw new BaseException(e.Message, e);
            }

        }

    }
}
