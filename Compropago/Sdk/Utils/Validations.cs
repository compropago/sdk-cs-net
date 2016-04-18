/**
 * @author Eduardo Aguilar <eduardo.aguilar@compropago.com>
 */

using System;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Compropago.Sdk.JsonStructure;
using Compropago.Sdk.Exceptions;

/**
 * Clase de validaciones generales
 * 
 * @method static evalAuth          Compropago.Sdk.JsonStructure.EvalAuthDetails
 * @method static validateGateway   bool
 */

namespace Compropago.Sdk.Utils
{
    class Validations
    {
        /**
         * Validacion de API Key
         * 
         * @var client  Compropago.Sdk.Client
         * @throw   Compropago.Sdk.Exceptions.CompropagoHttpExceptions
         * @return  Compropago.Sdk.JsonStructure.EvalAuthDetails
         */
        public static EvalAuthDetails evalAuth(Client client)
        {
            string uri = client.getSsl() + client.getUri() + "users/auth/";
            string stripe;
           
            Uri requestUri = null;
            Uri.TryCreate((uri), UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", string.Concat("Basic ",
                (Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(string.Format("{0}", client.getFullAuth()))))));

            StreamReader reader;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            reader = new StreamReader(respStream);
            stripe = reader.ReadToEnd();

            var serializer = new JavaScriptSerializer();
            EvalAuthDetails details = serializer.Deserialize<EvalAuthDetails>(stripe);

            switch (details.code)
            {
                case 401:
                    throw new CompropagoHttpExceptions(401, "No se logro procesar la petición");

                case 500:
                    throw new CompropagoHttpExceptions(details.code, "Error en la base de datos ComproPago");

                case 200:
                    return details;

                default:
                    throw new CompropagoHttpExceptions(details.code, details.message);
            }
            
        }

        /**
         * Verifica si las configuraciones del cliente permiten transacciones
         * 
         * @var client  Compropago.Sdk.Client
         * @throw   Compropago.Sdk.Exceptions.BaseException
         * @return  bool
         */
        public static bool validateGateway(Client client)
        {
            if (client.Equals(null))
            {
                throw new BaseException("El objeto Client no es valido"); 
            }

            var clientMode = client.getMode();

            try
            {
                EvalAuthDetails responseDetails = evalAuth(client);

                if (responseDetails.mode_key != responseDetails.livemode)
                {
                    return false;
                }
                if (clientMode != responseDetails.livemode)
                {
                    return false;
                }
                if (clientMode != responseDetails.mode_key)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new BaseException(e.Message, e);
            }

            return true;
        }

    }
}
