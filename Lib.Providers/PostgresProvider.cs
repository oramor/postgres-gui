using Npgsql;

namespace Lib.Providers
{
    public class PostgresProvider
    {
        static PostgresProvider()
        {
        }

        private NpgsqlConnection? objConn = null;

        public bool isConnected
        {
            get => objConn is not null;
        }

        public static string MakeConnectionString(string host, string port, string username, string password, string database)
        {
            return $"Host={host};Port={port};Username={username};Password={password};Database={database}";
        }

        public NpgsqlConnection TryConnect(string connString)
        {
            if (objConn != null) return objConn;

            try
            {
                objConn = new NpgsqlConnection(connString);
                return objConn;
            } catch
            {
                throw new Exception("Connection filed");
            };
        }

        public void tryDisconnect()
        {
            if (objConn == null) return;

            objConn.Close();
            objConn = null;
        }
    }
}