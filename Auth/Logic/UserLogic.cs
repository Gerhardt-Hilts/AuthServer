using System;
using System.Security.Cryptography;
using Auth.Models;

namespace Auth.Logic
{
    public class UserLogic
    {
        public UserLogic(UsersData userDatabaseInstance)
        {
            
        }
        
        public bool CreateUser(string username, string password)
        {
            var guid = Guid.NewGuid().ToString();
            return true;
        }
        
        public bool AuthenticateUser(string username, string password)
        {
            return true;
        }

        public bool GetUserByUsername(string username)
        {
            return true;
        }

        public bool GetUserByUserId(string userId)
        {
            return true;
        }
    }
}