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
    }
}