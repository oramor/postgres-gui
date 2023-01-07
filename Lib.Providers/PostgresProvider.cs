using Npgsql;

namespace Lib.Providers
{
    public readonly struct PostgresConnectionParams
    {
        public string Host { get; init; }
        public string Port { get; init; }
        public string Database { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }

    public class PostgresProvider
    {
        static PostgresProvider()
        {
        }

        private NpgsqlConnection? objConn = null;

        public bool IsConnected
        {
            get => objConn is not null;
        }

        public static string MakeConnectionString(PostgresConnectionParams connParams)
        {
            return $"Host={connParams.Host};Port={connParams.Port};Username={connParams.Username};Password={connParams.Password};Database={connParams.Database}";
        }

        public void TryConnect(PostgresConnectionParams connParams)
        {
            if (objConn != null) return;

            var connString = MakeConnectionString(connParams);

            try
            {
                objConn = new NpgsqlConnection(connString);
            } catch
            {
                throw new Exception("Connection filed");
            };
        }

        public void TryDisconnect()
        {
            if (objConn == null) return;

            objConn.Close();
            objConn = null;
        }
    }
}