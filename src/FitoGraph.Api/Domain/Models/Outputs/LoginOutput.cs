namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class LoginOutput
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}