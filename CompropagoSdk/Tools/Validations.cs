using System;
using System.Net;
using System.IO;
using System.Text;
using CompropagoSdk.Models;

namespace CompropagoSdk.Tools
{
    public class Validations
    {
        public static EvalAuthInfo evalAuth(Client client)
        {
            var uri = client.getUri() + "users/auth/";

            Uri requestUri = null;
            Uri.TryCreate(uri, UriKind.Absolute, out requestUri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

            request.Method = "GET";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", string.Concat("Basic ",
                (Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}", client.getFullAuth()))))));

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            var stripe = reader.ReadToEnd();

            EvalAuthInfo obj = Factory.Factory.evalAuthInfo(stripe);

            switch (obj.code)
            {
                case 200:
                    return obj;

                default:
                    throw new Exception("Code "+obj.code+": "+obj.message);
            }
        }

        public static bool validateGateway(Client client)
        {
            var clientMode = client.getMode();
            var authInfo = evalAuth(client);

            if (authInfo.mode_key != authInfo.livemode)
            {

                throw new Exception("Las llaves no corresponden al modo de la tienda.");
            }

            if (clientMode != authInfo.livemode)
            {
                throw new Exception("El modo del cliente no corresponde al de la tienda.");
            }

            if (clientMode != authInfo.mode_key)
            {
                throw new Exception("El modo del cliente no corresponde al de las llaves.");
            }

            return true;
        }
    }
}
