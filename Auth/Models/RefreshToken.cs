namespace Auth.Models
{
    public class RefreshToken
    {
        public string Id;
        public string LiteralToken;
        public string UserId;
        public string ClientId;
        public string ScopeId;
        public long IssuedAt;
        public long ExpiresAt;

        public RefreshToken(string id, string literalToken, string userId, string clientId, string scopeId, long issuedAt, long expiresAt)
        {
            Id = id;
            LiteralToken = literalToken;
            UserId = userId;
            ClientId = clientId;
            ScopeId = scopeId;
            IssuedAt = issuedAt;
            ExpiresAt = expiresAt;
        }
    }
}