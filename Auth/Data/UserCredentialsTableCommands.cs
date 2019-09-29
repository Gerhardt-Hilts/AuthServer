namespace Auth.Data
{
    public static class UserCredentialsTableCommands
    {
        internal const string CreateTableCommand =
            @"CREATE TABLE user_credentials (
                id          SERIAL,
                guid        VARCHAR(256)    PRIMARY KEY UNIQUE NOT NULL,
                username    VARCHAR(256)    UNIQUE NOT NULL,
                password    VARCHAR(256)    NOT NULL,
                salt        VARCHAR(256)    NOT NULL
            )";

        internal const string ValidateTableExistsCommand =
            @"SELECT EXISTS (
                SELECT  1
                FROM    information_schema.tables
                WHERE   table_schema = 'public'
                AND     table_name = 'user_credentials'
            )";

        internal const string ValidateTableColumnsCommand =
            @"SELECT column_name, data_type
                FROM information_schema.columns
                WHERE table_name = 'user_credentials'
            ";
    }
}