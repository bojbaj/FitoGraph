using System;
using System.Net;
using System.Net.Http;
using FitoGraph.Api.Helpers.Settings;
using Microsoft.Extensions.Options;
using MihaZupan;

namespace FitoGraph.Api.Helpers.Lib
{
    public static class HttpClientManager
    {
        public static IWebProxy GetWebProxy(AppSettingProxy proxy)
        {
            IWebProxy webProxy = new WebProxy();
            bool useProxy = proxy.Enable;
            if (useProxy)
            {
                string proxyType = proxy.Type;
                string proxyHost = proxy.Server;
                int proxyPort = proxy.Port;
                string proxyUserName = proxy.Username;
                string proxyPassword = proxy.Password;
                bool hasAuth = !string.IsNullOrEmpty(proxy.Username);

                if (proxyType == "http")
                {
                    webProxy = new WebProxy
                    {
                        Address = new Uri($"http://{proxyHost}:{proxyPort}"),
                        BypassProxyOnLocal = false,
                        UseDefaultCredentials = !hasAuth,
                    };
                    if (hasAuth)
                    {
                        webProxy.Credentials = new NetworkCredential(userName: proxyUserName, password: proxyPassword);
                    }
                }
                else if (proxyType == "socks5")
                {
                    webProxy = new HttpToSocks5Proxy(proxyHost, proxyPort);
                }
            }
            return webProxy;
        }
        public static HttpClientHandler GetHttpClientHandlerWithProxy(AppSettingProxy proxy)
        {
            var httpClientHandler = new HttpClientHandler()
            {
                Proxy = GetWebProxy(proxy)
            };
            return httpClientHandler;
        }
        public static HttpClient GetHttpClientWithProxy(AppSettingProxy proxy)
        {
            var httpClientHandler = GetHttpClientHandlerWithProxy(proxy);
            var client = new HttpClient(httpClientHandler, true);
            return client;
        }
    }
}