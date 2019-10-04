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
            if (tableValidation.Code != StatusCode.Ok)
                userCredentialsDataAccessTableManagement.InitializeTable();
        }

    }
}