using System;
using System.Xml.Linq;
using Auth.Models;

namespace Auth.Data
{
    public class UserCredentialsDataAccess
    {
        private readonly PostgresDatabase _database;

        private const string TableName = "user_credentials";
        private const string CreateTableCommand =
            @"CREATE TABLE ${TableName} (
                id          SERIAL,
                guid        VARCHAR(256)    PRIMARY KEY UNIQUE NOT NULL,
                username    VARCHAR(256)    UNIQUE NOT NULL,
                password    VARCHAR(256)    NOT NULL
            )";

        private const string ValidateTableExistsCommand =
            @"SELECT EXISTS (
                SELECT  1
                FROM    information_schema.tables
                WHERE   table_schema = 'public'
                AND     table_name = ${TableName}
            )";

        private const string ValidateTableColumnsCommand =
            @"SELECT column_name, data_type
                FROM information_schema.columns
                WHERE table_name = ${TableName}
            ";

        private const string CreateUserCommand =
            @"INSERT INTO ${TableName} (guid, username, password)
                 VALUES ()
            ";
        
        public UserCredentialsDataAccess(PostgresDatabase database)
        {
            // connect to specified database
            _database = database;
            // check if table exists
            var tableValidation = ValidateTable();
            // if not create table
            if (tableValidation.Code != InternalStatusCode.Ok)
                InitializeTable();
        }
        
        private InternalResponse InitializeTable()
        {
            var cmd = _database.CreateCommand(CreateTableCommand);
            return new InternalResponse(InternalStatusCode.Ok, "table initialized");
        }

        private InternalResponse ValidateTable()
        {
            using (var validateTableExists = _database.CreateCommand(ValidateTableExistsCommand))
            using (var reader = validateTableExists.ExecuteReader())
                while (reader.Read())
                {
                    Console.WriteLine(reader.FieldCount);
                    Console.WriteLine(reader.GetString(0));
                }

            using (var validateTableColumns = _database.CreateCommand(ValidateTableColumnsCommand))
            using (var reader = validateTableColumns.ExecuteReader())
                while (reader.Read())
                    Console.WriteLine(reader.GetString(0));
            
            return new InternalResponse(InternalStatusCode.Ok, "table validated successfully");
        }

        private InternalResponse<string> CreateUser(string username, string password)
        {
            var userId = "";
            return new InternalResponse<string>(InternalStatusCode.Ok, "successfully created user", userId);
        }
    }
}