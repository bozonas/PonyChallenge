using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PonyChallenge
{
    public interface IHttpClientHandler
    {
        TResponse Get<TResponse>(string url);

        string Get(string url);

        TResponse PostAsJson<TRequest, TResponse>(string url, TRequest value);
    }
}
