using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Models.Auth
{
    public class GetUserDataResponseWrapper
    {
        public List<GetUserDataResponse> users { get; set; }
    }
}