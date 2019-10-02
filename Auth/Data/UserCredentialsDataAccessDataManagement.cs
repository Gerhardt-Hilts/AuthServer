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
        
        public DatabaseResponse<string> CreateUser(string guid, string username, string password, string salt)
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
                    return new DatabaseResponse<string>(StatusCode.Failed, "failed to create user", exception.ToString());
                }
            }
            
            return new DatabaseResponse<string>(StatusCode.Ok, "successfully created user", guid);
        }

        public DatabaseResponse<UserCredentials> GetUserByUserName()
        {
            var userCredentials = new UserCredentials("","","","");
            return new DatabaseResponse<UserCredentials>(StatusCode.Ok, "successfully fetched user", userCredentials);
        }

    }
}