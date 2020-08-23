namespace FitoGraph.Api.Domain.Models.Auth
{
    public class SendVerificationEmailResponse : FireBaseErrorResponse
    {
        public string email { get; set; }
    }
}