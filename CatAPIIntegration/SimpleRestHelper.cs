using CatAPIIntegration.Servicos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CatAPIIntegration
{

    /// <summary>Small Rest API service helper</summary>
    public class SimpleRestHelper
    {
        CatAPISettings _setting;        
        public SimpleRestHelper(CatAPISettings setting)
        {
            _setting = setting;
        }

        public static class Methods
        {
            public const string Get = "GET";
            public const string Post = "POST";
        }
        public static class ContentType
        {
            public const string formUrlEncoded = "application/x-www-form-urlencoded";
            public const string Json = "application/json";
        }

        public static class Headers
        {
            public const string X_API_KEY = "x-api-key";
        }


        public T SendRequest<T>(string method, string url, string serializedContent, string contentType, out HttpStatusCode? statusCode)
        {
            statusCode = null;
            T result = default(T);

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method.ToString();
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                request.Headers.Add(Headers.X_API_KEY, $"{_setting.Xapikey}");


                if (!string.IsNullOrEmpty(serializedContent))
                {
                    request.ContentType = contentType.ToString();
                    using (var stream = request.GetRequestStream())
                    {
                        var bytes = Encoding.UTF8.GetBytes(serializedContent);
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }

                var response = (HttpWebResponse)request.GetResponse();
                statusCode = response.StatusCode;
                using (var responseStream = new StreamReader(response.GetResponseStream(), true))
                {
                    var contentResult = responseStream.ReadToEnd();
                    result = JsonConvert.DeserializeObject<T>(contentResult);
                }

            }
            catch (Exception ex)
            {
                throw new RestAPIException($"Unable to query api {ex.Message}. StatusCode: {statusCode?.ToString() ?? "Unknown"}", ex);
            }
            return result;
        }

        public class RestAPIException : Exception
        {
            public RestAPIException(string message, Exception ex) : base(message, ex)
            { }
        }
    }
}