using Npgsql;
using System.Data;

namespace Lib.Providers
{
    public class PostgresProvider : IDbProvider
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

        private static string MakeConnectionString(IDbConnectionParams connParams)
        {
            return $"Host={connParams.Host};Port={connParams.Port};Username={connParams.Username};Password={connParams.Password};Database={connParams.Database}";
        }

        public void TryConnect(IDbConnectionParams connParams)
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

        private DbType GetDbType(object value)
        {
            if (value is string) return DbType.String;
            if (value is int) return DbType.Int32;
            return DbType.Byte;
        }

        T IDbProvider.Execute<T>(ApiCommand apiCommand)
        {
            var cmd = new NpgsqlCommand(apiCommand.CommandString, connection);
            var apiParams = apiCommand.Params;

            foreach (var param in apiParams)
            {
                if (param.ParamType == ApiParameterType.Out)
                {
                    //TODO
                    cmd.Parameters.Add(new NpgsqlParameter(param.ParamName, DbType.Int32) { Direction = ParameterDirection.Output });
                }

                if (param.ParamType == ApiParameterType.In)
                {
                    cmd.Parameters.Add(new NpgsqlParameter(param.ParamName, DbType.String) { NpgsqlValue = param.ParamValue });
                }
            }

            cmd.ExecuteNonQuery();
            var outParam = cmd.Parameters[0];
            var result = outParam.Value;

            try
            {
                var t = (T)result;
                if (t == null) throw new Exception("Got null");

                return t;
            } catch
            {
                throw;
            }
        }

        T IDbProvider.Execute<T>(string cmdString)
        {
            var cmd = new NpgsqlCommand("CALL api_admin.pr_create_entity_n(NULL, @p_public_name, @p_pascal_name, @p_is_doc);", connection);
            cmd.Parameters.Add(new NpgsqlParameter("p_entity_id", DbType.Int32) { Direction = ParameterDirection.Output }
            );

            cmd.Parameters.Add(new NpgsqlParameter("p_public_name", DbType.String) { NpgsqlValue = "Тест2" });
            cmd.Parameters.Add(new NpgsqlParameter("p_pascal_name", DbType.String) { NpgsqlValue = "TestTwo" });
            cmd.Parameters.Add(new NpgsqlParameter("p_is_doc", DbType.Boolean) { NpgsqlValue = false });

            cmd.ExecuteNonQuery();
            var outParam = cmd.Parameters[0];
            var result = outParam.Value;

            try
            {
                var t = (T)result;
                if (t == null) throw new Exception("Got null");

                return t;
            } catch
            {
                throw;
            }


            /// CommandBehavior.Default означает, что может вернуться
            /// несколько строк.
            //NpgsqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
        }


    }
}