namespace FitoGraph.Api.Domain.Models.Auth
{
    public class RefreshTokenResponse : FireBaseErrorResponse
    {
        public string user_id { get; set; }
        public string id_token { get; set; }
        public string refresh_token { get; set; }        
    }
}