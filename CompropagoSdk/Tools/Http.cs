using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace CompropagoSdk.Tools
{
    public class Http
    {
        private readonly string _url;
        private string _data;
        private string _auth;
        private string _method;
        private Dictionary<string,string> _extraHeaders;

        public Http(string url)
        {
            _url = url;
        }

        public void SetMethod(string method)
        {
            if (method == "GET" || method == "POST" || method == "PUT" || method == "DELETE")
            {
                _method = method;
            }
            else
            {
                throw new Exception("HTTP Method not supported.");
            }
        }

        public void SetAuth(Dictionary<string,string> auth)
        {
            if (auth != null && auth.ContainsKey("user") && auth.ContainsKey("pass"))
            {
                _auth = auth["user"] + ":" + auth["pass"];
            }
            else
            {
                _auth = null;
            }
        }

        public void SetData(Dictionary<string, string> data)
        {
            _data = data != null ? JsonConvert.SerializeObject(data) : null;
        }

        public void SetExtraHeaders(Dictionary<string, string> headers)
        {
            _extraHeaders = headers ?? null;
        }

        public string ExecuteRequest()
        {
            Uri requestUri;
            Uri.TryCreate(_url, UriKind.Absolute, out requestUri);

            var request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = _method;

            if (_auth != null)
            {
                var encode = Convert.ToBase64String(Encoding.UTF8.GetBytes(_auth));
                request.Headers.Add("Authorization", "Basic "+encode);
            }

            request.ContentType = "application/json";
            request.Headers.Add("Cache-Control", "no-cache");

            if (_extraHeaders != null)
            {
                foreach (var entry in _extraHeaders)
                {
                    request.Headers.Add(entry.Key, entry.Value);
                }
            }

            if (_data != null)
            {
                var postBytes = Encoding.UTF8.GetBytes(_data);
                request.ContentLength = postBytes.Length;

                var requestStream = request.GetRequestStream();

                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var respStream = response.GetResponseStream();

                var reader = new StreamReader(respStream);
                var resp = reader.ReadToEnd();

                return resp;
            }
            catch (WebException e)
            {
                var respStream = e.Response.GetResponseStream();
                var reader = new StreamReader(respStream);
                var resp = reader.ReadToEnd();

                return resp;
            }
        }
    }
}