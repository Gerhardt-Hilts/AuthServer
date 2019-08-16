using Auth.Models;

namespace Auth.Logic
{
    public static class UserLogic
    {
        public static bool AuthenticateUser(string username, string password)
        {
            return true;
        }

        public static User GetUserByUsername(string username)
        {
            return new User();
        }
    }
}