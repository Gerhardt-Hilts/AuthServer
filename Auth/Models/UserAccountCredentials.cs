namespace Auth.Models
{
    public class UserAccountCredentials
    {
        public readonly string UserId;
        public readonly string Username;
        public readonly string Password;
        public readonly string Salt;

        public UserAccountCredentials(string userId ,string username, string password, string salt)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Salt = salt;
        }
    }
}