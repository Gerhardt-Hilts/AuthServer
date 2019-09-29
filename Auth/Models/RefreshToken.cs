namespace Auth.Models
{
    public class RefreshToken
    {
        public string LiteralToken;
        public long IssuedAt;
        public long ExpiresAt;
        public string ClientId;
        public string UserId;
        public string ScopeId;
    }
}