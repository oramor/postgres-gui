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

        private static DbType GetDbType(ApiParameterDataType value)
        {
            return value switch {
                ApiParameterDataType.String => DbType.String,
                ApiParameterDataType.Number => DbType.Int32,
                ApiParameterDataType.Bool => DbType.Boolean,
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

        T IDbProvider.Execute<T>(ApiCommand apiCommand)
        {
            var cmd = new NpgsqlCommand(apiCommand.CommandString, connection);
            var apiParams = apiCommand.Params;

            foreach (var param in apiParams)
            {
                if (param.ParamType == ApiParameterType.Out)
                {
                    cmd.Parameters.Add(new NpgsqlParameter(param.ParamName, GetDbType(param.ParamDataType)) { Direction = ParameterDirection.Output });
                }

                if (param.ParamType == ApiParameterType.In)
                {
                    cmd.Parameters.Add(new NpgsqlParameter(param.ParamName, GetDbType(param.ParamDataType)) { NpgsqlValue = param.ParamValue });
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
                if (t == null) throw new Exception("Got null");

                return t;
            } catch
            {
                throw;
            }
        }

        //T IDbProvider.Execute<T>(string cmdString)
        //{
        //    var cmd = new NpgsqlCommand("CALL api_admin.pr_create_entity_n(NULL, @p_public_name, @p_pascal_name, @p_is_doc);", connection);
        //    cmd.Parameters.Add(new NpgsqlParameter("p_entity_id", DbType.Int32) { Direction = ParameterDirection.Output }
        //    );

        //    cmd.Parameters.Add(new NpgsqlParameter("p_public_name", DbType.String) { NpgsqlValue = "Тест2" });
        //    cmd.Parameters.Add(new NpgsqlParameter("p_pascal_name", DbType.String) { NpgsqlValue = "TestTwo" });
        //    cmd.Parameters.Add(new NpgsqlParameter("p_is_doc", DbType.Boolean) { NpgsqlValue = false });

        //    cmd.ExecuteNonQuery();
        //    var outParam = cmd.Parameters[0];
        //    var result = outParam.Value;

        //    try
        //    {
        //        var t = (T)result;
        //        if (t == null) throw new Exception("Got null");

        //        return t;
        //    } catch
        //    {
        //        throw;
        //    }



        //NpgsqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
        //}

        /// <summary>
        /// Для функцй, вызываемых с этой оберткой, возвращаемое значение
        /// будет игнорироваться
        /// </summary>
        public void ExecuteVoid(ApiCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}