using System.Text.RegularExpressions;
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
            if (string.IsNullOrEmpty(Url))
                return string.Empty;
            string CDN_URL = Startup.StaticConfig.GetValue<string>("App:Config:CDN_URL");
            if (CDN_URL.EndsWith("/"))
                CDN_URL = CDN_URL.Substring(0, CDN_URL.Length - 1);

            if (Url.StartsWith("/"))
                Url = Url.Substring(1);

            return $"{CDN_URL}/{Url}";
        }
        public static string SafeReplace(this string input, string find, string replace, bool matchWholeWord = true)
        {
            string textToFind = matchWholeWord ? string.Format(@"\b{0}\b", find) : find;
            return Regex.Replace(input, textToFind, replace);
        }
        public static string EscapeSQLInjection(this string input)
        {
            return input
                .Replace("'", "''")
                ;
        }
        public static string FixPersianNumbers(this string input)
        {
            return (input ?? string.Empty)
                .Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                ;
        }
    }
}