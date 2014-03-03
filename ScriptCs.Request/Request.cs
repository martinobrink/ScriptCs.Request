using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using ScriptCs.Contracts;
using System.Collections.Generic;

namespace ScriptCs.Request
{
    public class Request : IScriptPackContext
    {
        public string Get(string url, AuthenticationHeaderValue authenticationHeaderValue = null, Dictionary<string, string> customHeaders = null)
        {
            var httpClient = new HttpClient();
            SetOptionalHeaders(httpClient, authenticationHeaderValue, customHeaders);
            return httpClient.GetStringAsync(url).Result;
        }

        public HttpResponseMessage GetJson(string url, AuthenticationHeaderValue authenticationHeaderValue = null, Dictionary<string, string> customHeaders = null)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            SetOptionalHeaders(httpClient, authenticationHeaderValue, customHeaders);
            return httpClient.GetAsync(url).Result;
        }

        public T GetJson<T>(string url, AuthenticationHeaderValue authenticationHeaderValue = null, Dictionary<string, string> customHeaders = null) where T : class
        {
            var result = GetJson(url, authenticationHeaderValue, customHeaders);
            return JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().Result);
        }

        public HttpResponseMessage PostJson<T>(string url, T objectToPost, AuthenticationHeaderValue authenticationHeaderValue = null, Dictionary<string, string> customHeaders = null) where T : class
        {
            var httpClient = new HttpClient();
            var bodyContent = new StringContent(JsonConvert.SerializeObject(objectToPost), Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            SetOptionalHeaders(httpClient, authenticationHeaderValue, customHeaders);
            return httpClient.PostAsync(url, bodyContent).Result;
        }

        public HttpResponseMessage PutJson<T>(string url, T objectToPut, AuthenticationHeaderValue authenticationHeaderValue = null, Dictionary<string, string> customHeaders = null) where T : class
        {
            var httpClient = new HttpClient();
            var bodyContent = new StringContent(JsonConvert.SerializeObject(objectToPut), Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            SetOptionalHeaders(httpClient, authenticationHeaderValue, customHeaders);
            return httpClient.PutAsync(url, bodyContent).Result;
        }

        public HttpResponseMessage Delete(string url, AuthenticationHeaderValue authenticationHeaderValue = null, Dictionary<string, string> customHeaders = null)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            SetOptionalHeaders(httpClient, authenticationHeaderValue, customHeaders);
            return httpClient.DeleteAsync(url).Result;
        }

        private void SetOptionalHeaders(HttpClient httpClient, AuthenticationHeaderValue authenticationHeaderValue = null, Dictionary<string, string> customHeaders = null)
        {
            if (authenticationHeaderValue != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
            }

            if (customHeaders != null)
            {
                foreach (var customHeader in customHeaders)
                {
                    httpClient.DefaultRequestHeaders.Add(customHeader.Key, customHeader.Value);
                }
            }
        }
    }
}