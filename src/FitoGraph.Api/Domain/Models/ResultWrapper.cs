namespace FitoGraph.Api.Domain.Models
{
    public class PublicResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }

    public class ResultWrapper<T> : PublicResult
    {
        public T Result { get; set; }
    }
}