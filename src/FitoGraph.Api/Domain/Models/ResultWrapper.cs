namespace FitoGraph.Api.Domain.Models
{
    public class ResultWrapper<T> : PublicResult
    {
        public T Result { get; set; }
    }
}