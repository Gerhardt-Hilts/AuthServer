using System;
using System.Security.Cryptography;
using Auth.Data;
using Auth.Models;
using Auth.Util;

namespace Auth.Logic
{
    public class UserLogic
    {
        private readonly UsersCredentialsData _userDatabaseInstance;
        public UserLogic(UsersCredentialsData userCredentialsDatabaseInstance)
        {
            _userDatabaseInstance = userCredentialsDatabaseInstance;
        }
        
        public bool CreateUser(string username, string password)
        {
            var guid = Guid.NewGuid().ToString();
            return true;
        }
        
        public bool AuthenticateUser(string username, string password)
        {
            var user = GetUserByUsername(username);
            var userHashedPassword = user.Password;
            var userSalt = user.Salt;

            Crypto.HashPasswordWithSalt(password, userSalt);
            
            return true;
        }

        public User GetUserByUsername(string username)
        {
            var user = _userDatabaseInstance.GetUserByUsername(username);
            return user;
        }

        public bool GetUserByUserId(string userId)
        {
            return true;
        }
    }
}