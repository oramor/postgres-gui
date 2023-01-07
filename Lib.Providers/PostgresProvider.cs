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

        private NpgsqlDataSource? dataSource = null;
        private NpgsqlConnection? connection = null;

        public string Host { get => connection?.Host ?? string.Empty; }
        public string Port { get => connection?.Port.ToString() ?? string.Empty; }
        public string Database { get => connection?.Database ?? string.Empty; }
        public string Username { get => connection?.UserName ?? string.Empty; }

        public bool IsConnected
        {
            get {
                if (connection == null) return false;

                var state = connection.State;
                if (state == System.Data.ConnectionState.Open)
                {
                    return true;
                }

                return false;
            }
        }

        public string ServerVersion
        {
            get {
                if (connection == null) return string.Empty;
                return connection.ServerVersion.ToString();
            }
        }

        public static string MakeConnectionString(PostgresConnectionParams connParams)
        {
            return $"Host={connParams.Host};Port={connParams.Port};Username={connParams.Username};Password={connParams.Password};Database={connParams.Database}";
        }

        public void TryConnect(PostgresConnectionParams connParams)
        {
            if (dataSource != null) return;

            var connString = MakeConnectionString(connParams);

            try
            {
                dataSource = NpgsqlDataSource.Create(connString);
                connection = dataSource.OpenConnection();
            } catch
            {
                throw new Exception("Connection filed");
            };
        }

        public void TryDisconnect()
        {
            if (connection == null) return;
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

            if (dataSource == null) return;
            dataSource.Dispose();
            dataSource = null;
        }
    }
}