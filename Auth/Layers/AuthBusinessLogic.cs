using Auth.AuthModels;

namespace Auth.Layers
{
    public class AuthBusinessLogic
    {
        // Get User Auth Info
        public AuthUserInfo GetUserInfo(string userId)
        {
            return new AuthUserInfo();
        }
    }
}