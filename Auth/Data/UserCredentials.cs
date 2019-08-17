using Auth.Models;
using Npgsql;

namespace Auth.Data
{
    public class UserCredentials
    {
        private PostgresDatabase _database;
        public UserCredentials(PostgresDatabase database)
        {
            // connect to specified database
            _database = database;
            // check if table exists
            // if not create table
            // done
        }
        
        public InternalResponse InitializeTable()
        {
            return new InternalResponse(InternalStatusCode.Ok, "stub method");
        }
    }
}