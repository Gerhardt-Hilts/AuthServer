using System;
using System.Security.Cryptography;
using System.Xml.Linq;
using Auth.Models;

namespace Auth.Data
{
    public class UserCredentialsDataAccessDataManagement
    {
        private readonly PostgresDatabase _database;

        private const string TableName = "user_credentials";
        
        public UserCredentialsDataAccessDataManagement(PostgresDatabase database)
        {
            // connect to specified database
            _database = database;
        }
        
        public InternalResponse<string> CreateUser(string guid, string username, string password, string salt)
        {
            using (var createUser = _database.CreateCommand(UserCredentialsDataCommands.CreateUserCommand))
            {
                createUser.Parameters.AddWithValue("guid", guid);
                createUser.Parameters.AddWithValue("username", username);
                createUser.Parameters.AddWithValue("password", password);
                createUser.Parameters.AddWithValue("salt", salt);
                try
                {
                    createUser.ExecuteNonQuery();
                }
                catch(Exception exception)
                {
                    return new InternalResponse<string>(InternalStatusCode.Failed, "failed to create user", exception.ToString());
                }
            }
            
            return new InternalResponse<string>(InternalStatusCode.Ok, "successfully created user", guid);
        }

        public InternalResponse<UserCredentials> GetUserByUserName()
        {
            var userCredentials = new UserCredentials("","","","");
            return new InternalResponse<UserCredentials>(InternalStatusCode.Ok, "successfully fetched user", userCredentials);
        }

    }
}