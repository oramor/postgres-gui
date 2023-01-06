using Npgsql;

namespace Gui
{
    public static class PgConnector
    {
        static PgConnector() 
        {
        }

        public static string MakeConnectionString(string host, string port, string username, string password, string database)
        {
            return $"Host={host};Port={port};Username={username};Password={password};Database={database}";
        }

        public static NpgsqlConnection GetConnection(string connString)
        {
            try
            {
                var objConn = new NpgsqlConnection(connString);
                return objConn;
            } catch
            {
                throw new Exception("Connection filed");
            };
        }
    }
}