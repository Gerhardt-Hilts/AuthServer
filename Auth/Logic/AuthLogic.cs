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
        private readonly UserLogic _userLogic;
        private readonly TokenLogic _tokenLogic;
        
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
            var userCredentialsDataInstance = new UsersCredentialsData(database);
            _userLogic = new UserLogic(userCredentialsDataInstance);
            _tokenLogic = new TokenLogic();
            
            // check if table exists
            var tableValidation = userCredentialsDataAccessTableManagement.ValidateTable();
            // if not create table
            if (tableValidation.Code != StatusCode.Ok)
                userCredentialsDataAccessTableManagement.InitializeTable();
        }

        public void CreateUser(string username, string password)
        {
            
        }

        public AuthTokens LoginUser(string username, string password, string clientId)
        {
            // authenticate user
            var valid = _userLogic.AuthenticateUser(username, password);
            if (!valid)
                return null;
            
            // get user from database to view userId, scopeId
            var user = _userLogic.GetUserByUsername(username);
            
            // give user new tokens
            return _tokenLogic.GenerateTokens(user.Id, user.ScopeId, clientId);
        }

        public AuthTokens RefreshUser(RefreshToken refreshToken)
        {
            var valid = _tokenLogic.ValidateRefreshToken(refreshToken);
            if (valid)
            {
                _tokenLogic.RevokeRefreshToken(refreshToken);
                return _tokenLogic.GenerateTokensForRefreshToken(refreshToken);
            }

            return null;
        }

        public void LogoutUser(RefreshToken refreshToken)
        {
            // end user session
            // invalidate user session token
            _tokenLogic.RevokeRefreshToken(refreshToken);
        }

        public void DeactivateUser(string userId)
        {
            _userLogic.DeactivateUser(userId);
        }
    }
}