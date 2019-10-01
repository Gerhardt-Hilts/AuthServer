namespace Auth.Models
{
    public enum GrantType
    {
        AuthorizationCode,
        Implicit,
        Password,
        ClientCredentials,
        DeviceCode,
        RefreshToken
    }
}