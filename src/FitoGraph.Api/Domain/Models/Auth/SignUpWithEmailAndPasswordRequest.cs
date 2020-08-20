namespace FitoGraph.Api.Domain.Models.Auth
{
    public class SignUpWithEmailAndPasswordRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}