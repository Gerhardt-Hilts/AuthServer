namespace Auth.Models
{
    public class UserCredentials
    {
        public readonly string Username;
        public readonly string Password;
        public readonly string Guid;
        public readonly string Salt;

        public UserCredentials(string username, string password, string guid, string salt)
        {
            Username = username;
            Password = password;
            Guid = guid;
            Salt = salt;
        }
    }
}