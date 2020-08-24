using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FitoGraph.Api.Infrastructure
{
    public static class StringExtentions
    {
        public static string ToJsonString<T>(this T obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, settings);
        }

        public static string JoinWithCDNAddress(this string Url)
        {
            string CDN_URL = Startup.StaticConfig.GetValue<string>("App:Config:CDN_URL");
            if (CDN_URL.EndsWith("/"))
                CDN_URL = CDN_URL.Substring(0, CDN_URL.Length - 1);

            if (Url.StartsWith("/"))
                Url = Url.Substring(1);

            return $"{CDN_URL}/{Url}";
        }

    }
}