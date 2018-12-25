using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PonyChallenge
{
    public class HttpClientHandler : IHttpClientHandler
    {
        private HttpClient client = new HttpClient();

        public TResponse Get<TResponse>(string url)
        {
            var response = client.GetAsync(url).Result;
            var responseType = response.Content.ReadAsAsync<TResponse>().Result;
            return responseType;
        }

        public string Get(string url)
        {
            var response = client.GetAsync(url).Result;
            var responseType = response.Content.ReadAsStringAsync().Result;
            return responseType;
        }

        public TResponse PostAsJson<TRequest, TResponse>(string url, TRequest value)
        {
            var response = client.PostAsJsonAsync<TRequest>(url, value).Result;
            var responseType = response.Content.ReadAsAsync<TResponse>().Result;
            return responseType;
        }
    }
}
