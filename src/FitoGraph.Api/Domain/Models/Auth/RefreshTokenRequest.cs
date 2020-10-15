namespace FitoGraph.Api.Domain.Models.Auth
{
    public class RefreshTokenRequest
    {
        public string refresh_token { get; set; }
        public string grant_type { get; set; }                
    }
}