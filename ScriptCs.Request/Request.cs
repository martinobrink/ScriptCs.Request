using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using ScriptCs.Contracts;

namespace ScriptCs.Request
{
    public class Request : IScriptPackContext
    {
        public string Get(string url)
        {
            var httpClient = new HttpClient();
            return httpClient.GetStringAsync(url).Result;
        }

        public HttpResponseMessage GetJson(string url)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient.GetAsync(url).Result;
        }

        public HttpResponseMessage PostJson<T>(string url, T objectToPost) where T : class
        {
            var httpClient = new HttpClient();
            var bodyContent = new StringContent(JsonConvert.SerializeObject(objectToPost), Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient.PostAsync(url, bodyContent).Result;
        }

        public HttpResponseMessage PutJson<T>(string url, T objectToPut) where T : class
        {
            var httpClient = new HttpClient();
            var bodyContent = new StringContent(JsonConvert.SerializeObject(objectToPut), Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient.PutAsync(url, bodyContent).Result;
        }

        public HttpResponseMessage Delete(string url)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient.DeleteAsync(url).Result;
        }
    }
}