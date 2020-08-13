namespace FitoGraph.Api.Infrastructure
{
    public static class StringExtentions
    {
        public static string ToJsonString<T>(this T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}