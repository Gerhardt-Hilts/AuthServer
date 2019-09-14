using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Auth.Data;
using Auth.Models;
using JWT.Algorithms;
using JWT.Builder;

namespace Auth.Logic
{
    public class AuthLogic
    {
        private readonly string _secret;
        private readonly UserCredentialsDataAccessDataManagement _userCredentialsDataAccessDataManagement;
        
        public AuthLogic(string secret)
        {
            _secret = secret;
            var database = new PostgresDatabase(
                PostgresDatabase.BuildConnectionString(
                    "localhost",
                    "postgres",
                    "postgres",
                    "test"));
            
            var userCredentialsDataAccessTableManagement = new UserCredentialsDataAccessTableManagement(database);
            _userCredentialsDataAccessDataManagement = new UserCredentialsDataAccessDataManagement(database);
            
            // check if table exists
            var tableValidation = userCredentialsDataAccessTableManagement.ValidateTable();
            // if not create table
            if (tableValidation.Code != InternalStatusCode.Ok)
                userCredentialsDataAccessTableManagement.InitializeTable();
        }

        public string GenerateTokensForUser(string userId)
        {
            var subject = userId;
            // create the access token
            var accessToken = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_secret)
                .AddClaim("iat", DateTimeOffset.UtcNow)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds())
                .AddClaim("sub", subject)
                .Build();
            // var refreshToken
            return accessToken;
        }
        
        public bool AuthenticateUser(string username, string password)
        {
            return true;
        }

        public string GetUserIdByUsername(string username)
        {
            return "";
        }

        public InternalResponse<string> CreateUser(string username, string password)
        {
            var saltBytes = CreateSalt();
            var hashedPassword = HashPassword(password, saltBytes);

            var guid = Guid.NewGuid().ToString();
            var salt = saltBytes.ToString();
            _userCredentialsDataAccessDataManagement.CreateUser(guid, username, password, salt);
            
            return new InternalResponse<string>(InternalStatusCode.Ok, "user successfully created", guid);
        }
        
        public void BlacklistToken()
        {
            // invalidates a token
        }
        
        private static byte[] CreateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            return salt;
        }

        private static string HashPassword(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            var hash = pbkdf2.GetBytes(20);
            var hashBytes = new byte[36];
            
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash,0, hashBytes, 16, 20);
            
            var savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }
    }
}