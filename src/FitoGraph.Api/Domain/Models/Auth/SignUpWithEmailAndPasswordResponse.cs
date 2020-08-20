namespace FitoGraph.Api.Domain.Models.Auth
{
    public class SignUpWithEmailAndPasswordResponse : FireBaseErrorResponse
    {
        public string localId { get; set; }
        public string email { get; set; }
        public string idToken { get; set; }
        public string refreshToken { get; set; }
        public string expiresIn { get; set; }
    }
}