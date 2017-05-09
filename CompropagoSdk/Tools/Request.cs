using System;
using System.Collections.Generic;
using CompropagoSdk.Factory.Models;
using Newtonsoft.Json;

namespace CompropagoSdk.Tools
{
    public class Request
    {
        public static bool ValidateResponse(string response)
        {
            if (response == "")
            {
                throw new Exception("Empty response");
            }

            try
            {
                var error = JsonConvert.DeserializeObject<GenericError>(response);

                if (error.type == "error")
                {
                    throw new Exception("Error: "+error.message);
                }

                return true;
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                return true;
            }
        }

        public static string Get(
            string url,
            Dictionary<string, string> auth = null,
            Dictionary<string,string> headers = null
        )
        {
            var http = new Http(url);
            http.SetAuth(auth);
            http.SetMethod("GET");
            http.SetExtraHeaders(headers);
            var res = @""+http.ExecuteRequest();

            ValidateResponse(res);

            return res;
        }

        public static string Post(
            string url,
            Dictionary<string, string> data = null,
            Dictionary<string, string> auth = null,
            Dictionary<string, string> headers = null
        )
        {
            var http = new Http(url);
            http.SetAuth(auth);
            http.SetMethod("POST");
            http.SetData(data);
            http.SetExtraHeaders(headers);
            var res = @""+http.ExecuteRequest();

            ValidateResponse(res);

            return res;
        }

        public static string Put(
            string url,
            Dictionary<string, string> data = null,
            Dictionary<string, string> auth = null,
            Dictionary<string, string> headers = null
        )
        {
            var http = new Http(url);
            http.SetAuth(auth);
            http.SetMethod("PUT");
            http.SetData(data);
            http.SetExtraHeaders(headers);
            var res = @""+http.ExecuteRequest();

            ValidateResponse(res);

            return res;
        }

        public static string Delete(
            string url,
            Dictionary<string, string> data = null,
            Dictionary<string, string> auth = null,
            Dictionary<string, string> headers = null
        )
        {
            var http = new Http(url);
            http.SetAuth(auth);
            http.SetMethod("DELETE");
            http.SetData(data);
            http.SetExtraHeaders(headers);
            var res = @""+http.ExecuteRequest();

            ValidateResponse(res);

            return res;
        }
    }
}