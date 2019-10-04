namespace Auth.Models
{
    public class User
    {
        public readonly string Id;
        public readonly string Username;
        public readonly string Password;
        public readonly byte[] Salt;
        public readonly string ScopeId;

        public User(string userId, string username, string password, byte[] salt, string scopeId)
        {
            Id = userId;
            Username = username;
            Password = password;
            Salt = salt;
            ScopeId = ScopeId;
        }
    }
}