namespace FitoGraph.Api.Domain.Models.User
{
    public class FirebaseUser
    {
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}