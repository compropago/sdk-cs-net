using System;
using System.Collections.Generic;
using CompropagoSdk.Factory.Models;

namespace CompropagoSdk.Tools
{
    public class Validations
    {
        public static EvalAuthInfo EvalAuth(Client client)
        {
            string response;

            if (client.GetUser() != "" || client.GetPass() != "")
            {
                response = Request.Get(
                    client.DeployUri + "users/auth/",
                    new Dictionary<string, string> {{"user", client.GetUser()}, {"pass", client.GetPass()}}
                );
            }
            else
            {
                throw new Exception("Error: Auth keys are empty");
            }

            var info = Factory.Factory.EvalAuthInfo(response);

            if (info.code == 200)
            {
                return info;
            }

            throw new Exception("Error: "+info.message);
        }

        public static void ValidateGateway(Client client)
        {
            if (client == null)
            {
                throw new Exception("Client object is not valid");
            }

            var clientMode = client.Live;

            var authInfo = EvalAuth(client);

            if (authInfo.mode_key != authInfo.livemode)
            {
                throw new Exception("Keys are diferent of store mode");
            }

            if (clientMode != authInfo.livemode)
            {
                throw new Exception("Client mode is diferent of store mode");
            }

            if (clientMode != authInfo.mode_key)
            {
                throw new Exception("Client mode is diferent of keys mode");
            }
        }
    }
}