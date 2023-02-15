using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace Lib.Providers
{
    public class PostgresProvider : IDbProvider
    {
        static PostgresProvider()
        {
        }

        /// <summary>
        /// It is an abstraction over System.Data class (new in Npgsql 7).
        /// Best choice to put into DI containers, because the instance
        /// of this class incapsulate all majority methods, including
        /// db connection
        /// </summary>
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

        private static string MakeConnectionString(DbConnectionParams connParams)
        {
            return $"Host={connParams.Host};Port={connParams.Port};Username={connParams.Username};Password={connParams.Password};Database={connParams.Database}";
        }

        public void TryConnect(DbConnectionParams connParams)
        {
            if (dataSource != null) return;

            var connString = MakeConnectionString(connParams);

            try
            {
                dataSource = NpgsqlDataSource.Create(connString);
                connection = dataSource.OpenConnection();
                OnConnectionStatusChanged(ConnectionState.Open);
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

            OnConnectionStatusChanged(ConnectionState.Closed);
        }

        public event EventHandler<ConnectionState>? ConnectionStatusChanged;
        void OnConnectionStatusChanged(ConnectionState e)
        {
            ConnectionStatusChanged?.Invoke(this, e);
        }

        private static NpgsqlDbType GetNpgsqlDbType(ApiParameterDataType value)
        {
            return value switch {
                ApiParameterDataType.String => NpgsqlDbType.Text,
                ApiParameterDataType.Integer => NpgsqlDbType.Integer,
                ApiParameterDataType.Number => NpgsqlDbType.Numeric,
                ApiParameterDataType.Bool => NpgsqlDbType.Boolean,
                ApiParameterDataType.Json => NpgsqlDbType.Jsonb,
                _ => throw new Exception("Not matched DbType for ApiParameterType")
            };
        }

        private DataTable ReadTable(NpgsqlDataReader reader)
        {
            var dt = new DataTable();

            // Otherwise will be returned an empty DataTable
            if (reader.HasRows)
            {
                dt.Load(reader);
            }

            return dt;
        }

        T IDbProvider.Query<T>(ApiCommand apiCommand)
        {
            if (!IsConnected)
            {
                throw new DbDisconnectException(apiCommand, CommanHandlerType.Query);
            }

            using var cmd = new NpgsqlCommand(apiCommand.CommandString, connection);
            var apiParams = apiCommand.Params;

            foreach (var param in apiParams)
            {
                if (param.ParamType == ApiParameterType.Out)
                {
                    cmd.Parameters.Add(new NpgsqlParameter(param.ParamName, GetNpgsqlDbType(param.ParamDataType)) { Direction = ParameterDirection.Output });
                }

                if (param.ParamType == ApiParameterType.In)
                {
                    cmd.Parameters.Add(new NpgsqlParameter(param.ParamName, GetNpgsqlDbType(param.ParamDataType)) { NpgsqlValue = param.ParamValue });
                }
            }

            object? result = null;

            /// Если функция или процедура содержит out-параметр, то мы будем
            /// получать данные именно из этого параметра.
            if (apiCommand.HasOutParam)
            {
                cmd.ExecuteNonQuery();
                var outParam = cmd.Parameters[0];
                result = outParam?.Value;
            }
            else if (apiCommand.CommandType == ApiCommandType.Func)
            {
                NpgsqlDataReader reader;

                switch (apiCommand.ResultType)
                {
                    // Для постфиксов _n, _b, _s ожадается возврат одной ячейки
                    case ApiCommandResultType.Cell:
                        reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        result = reader.GetValue(0);
                        break;
                    // For record _r return DataRow
                    case ApiCommandResultType.Row:
                        reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                        var dt = ReadTable(reader);
                        result = dt.Rows[0];
                        break;
                    // Для таблиц _t
                    case ApiCommandResultType.Table:
                        reader = cmd.ExecuteReader(CommandBehavior.Default);
                        result = ReadTable(reader);
                        break;
                    default:
                        throw new NotSupportedException("Not supported value of ApiCommandResultType");
                }
            }
            else
            {
                throw new Exception("Procedure without out-param can't be called within this method because it will never return value. Use ExecuteVoid method");
            }

            if (result == null)
            {
                throw new Exception("Got null");
            }

            try
            {
                var t = (T)result;
                if (t == null) throw new Exception("PostgresProvider: got null during type casting");

                return t;
            } catch
            {
                throw new Exception("PostgresProvider: invalid type converting");
            }
        }

        public void Execute(ApiCommand apiCommand)
        {
            if (!IsConnected)
            {
                throw new DbDisconnectException(apiCommand, CommanHandlerType.Execute);
            }

            if (apiCommand.HasOutParam || apiCommand.CommandType == ApiCommandType.Func)
            {
                throw new Exception("PostgresProvider: you should use Query method for api commands with out-parameters");
            }

            using var cmd = new NpgsqlCommand(apiCommand.CommandString, connection);
            var apiParams = apiCommand.Params;

            foreach (var param in apiParams)
            {
                if (param.ParamType == ApiParameterType.In)
                {
                    cmd.Parameters.Add(new NpgsqlParameter(param.ParamName, GetNpgsqlDbType(param.ParamDataType)) { NpgsqlValue = param.ParamValue });
                }
            }

            cmd.ExecuteNonQuery();
            //var reader = cmd.ExecuteReader(CommandBehavior.Default);
            //reader.Close();
        }
    }
}