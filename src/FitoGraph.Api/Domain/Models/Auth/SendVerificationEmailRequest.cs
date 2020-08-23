using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Domain.Models.Auth
{
    public class SendVerificationEmailRequest
    {
        public string idToken { get; set; }
        public string requestType { get; set; }
    }
}