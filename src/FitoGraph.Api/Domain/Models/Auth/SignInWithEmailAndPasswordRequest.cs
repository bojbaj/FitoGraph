namespace FitoGraph.Api.Domain.Models.Auth
{
    public class SignInWithEmailAndPasswordRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}