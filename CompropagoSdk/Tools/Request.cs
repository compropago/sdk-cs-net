using System;
using System.Collections.Generic;
using CompropagoSdk.Factory.Models;
using Newtonsoft.Json;

namespace CompropagoSdk.Tools
{
    public class Request
    {
        /// <summary>
        /// Validates the response.
        /// </summary>
        /// <returns><c>true</c>, if response was validated, <c>false</c> otherwise.</returns>
        /// <param name="response">Response.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
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

        /// <summary>
        /// Get the specified url, auth and headers.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="url">URL.</param>
        /// <param name="auth">Auth.</param>
        /// <param name="headers">Headers.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
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

        /// <summary>
        /// Post the specified url, data, auth and headers.
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="url">URL.</param>
        /// <param name="data">Data.</param>
        /// <param name="auth">Auth.</param>
        /// <param name="headers">Headers.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static string Post(
            string url,
            Dictionary<string, object> data = null,
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

        /// <summary>
        /// Put the specified url, data, auth and headers.
        /// </summary>
        /// <returns>The put.</returns>
        /// <param name="url">URL.</param>
        /// <param name="data">Data.</param>
        /// <param name="auth">Auth.</param>
        /// <param name="headers">Headers.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static string Put(
            string url,
            Dictionary<string, object> data = null,
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

        /// <summary>
        /// Delete the specified url, data, auth and headers.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="url">URL.</param>
        /// <param name="data">Data.</param>
        /// <param name="auth">Auth.</param>
        /// <param name="headers">Headers.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public static string Delete(
            string url,
            Dictionary<string, object> data = null,
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