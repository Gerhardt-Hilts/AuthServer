using System;
using Auth.Models;

namespace Auth.Data
{
    public class UserCredentialsDataAccessTableManagement
    {
        private readonly PostgresDatabase _database;
        
        public UserCredentialsDataAccessTableManagement(PostgresDatabase database)
        {
            _database = database;
        }
        
        public InternalResponse InitializeTable()
        {
            var cmd = _database.CreateCommand(UserCredentialsTableCommands.CreateTableCommand);
            return new InternalResponse(InternalStatusCode.Ok, "table initialized");
        }

        public InternalResponse ValidateTable()
        {
            using (var validateTableExists = _database.CreateCommand(UserCredentialsTableCommands.ValidateTableExistsCommand))
            using (var reader = validateTableExists.ExecuteReader())
                while (reader.Read())
                {
                    Console.WriteLine(reader.FieldCount);
                    Console.WriteLine(reader.GetString(0));
                }

            using (var validateTableColumns = _database.CreateCommand(UserCredentialsTableCommands.ValidateTableColumnsCommand))
            using (var reader = validateTableColumns.ExecuteReader())
                while (reader.Read())
                    Console.WriteLine(reader.GetString(0));
            
            return new InternalResponse(InternalStatusCode.Ok, "table validated successfully");
        }

    }
}