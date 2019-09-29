namespace Auth.Data
{
    public static class UserCredentialsDataCommands
    {

        internal const string CreateUserCommand =
            @"INSERT INTO user_credentials
                (
                    guid,
                    username,
                    password,
                    salt
                )
                VALUES 
                (
                    @guid,
                    @username,
                    @password,
                    @salt
                )
            ";

        private const string GetUserByUsername =
            @"SELECT username, password, guid, salt FROM user_credentials
                WHERE username = @username
            ";
    }
}