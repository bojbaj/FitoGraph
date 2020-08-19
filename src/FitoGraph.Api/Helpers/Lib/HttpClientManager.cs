using System;
using System.Net;
using System.Net.Http;
using FitoGraph.Api.Helpers.Settings;
using Microsoft.Extensions.Options;

namespace FitoGraph.Api.Helpers.Lib
{
    public static class HttpClientManager
    {        
        public static HttpClient GetHttpClientWithProxy(AppSettingProxy proxy)
        {
            var client = new HttpClient();
            bool useProxy = proxy.Enable;
            if (useProxy)
            {
                string proxyHost = proxy.Server;
                int proxyPort = proxy.Port;
                string proxyUserName = proxy.Username;
                string proxyPassword = proxy.Password;
                bool hasAuth = !string.IsNullOrEmpty(proxy.Username);
                var webProxy = new WebProxy
                {
                    Address = new Uri($"http://{proxyHost}:{proxyPort}"),
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = !hasAuth,
                };
                if (hasAuth)
                {
                    webProxy.Credentials = new NetworkCredential(userName: proxyUserName, password: proxyPassword);
                }
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = webProxy,
                };
                client = new HttpClient(handler: httpClientHandler, disposeHandler: true);
            }
            return client;
        }
    }
}