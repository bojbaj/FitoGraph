namespace FitoGraph.Api.Domain.Models.Auth
{
    public class SignInWithEmailAndPasswordResponse : FireBaseErrorResponse
    {
        public string localId { get; set; }
        public string email { get; set; }
        public string idToken { get; set; }
        public string displayName { get; set; }
        public bool registered { get; set; }
        public string refreshToken { get; set; }        
    }
}