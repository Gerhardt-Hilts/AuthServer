using Microsoft.Win32.SafeHandles;

namespace Auth.Models
{
    public class AuthTokens
    {
        public AccessToken AccessToken;
        public RefreshToken RefreshToken;

        public AuthTokens(AccessToken inputAccessToken, RefreshToken inputRefreshToken)
        {
            AccessToken = inputAccessToken;
            RefreshToken = inputRefreshToken;
        }
    }
}