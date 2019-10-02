namespace Auth.Models
{
    public class UserCredentials
    {
        public readonly string UserId;
        public readonly string Username;
        public readonly string Password;
        public readonly string Salt;

        public UserCredentials(string userId, string username, string password, string salt)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Salt = salt;
        }
    }
}