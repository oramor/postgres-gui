using System.Data;

namespace Lib.Providers
{
    public readonly record struct DbConnectionParams(string Host, string Port, string Database, string Username, string Password);

    public interface IDbProvider
    {
        string Host { get; }
        string Port { get; }
        string Database { get; }
        string Username { get; }
        string ServerVersion { get; }
        bool IsConnected { get; }
        void TryConnect(DbConnectionParams connParams);
        void TryDisconnect();
        /// <summary>
        /// Здесь API, который схож с Dapper: Query<T> для запросов,
        /// которые должны возвращать данные и Execute для запросов,
        /// где результат не ожидается (процедуры вроде pr_do_something_)
        /// </summary>
        T Query<T>(ApiCommand cmd);
        void Execute(ApiCommand cmd);
        event EventHandler<ConnectionState> ConnectionStatusChanged;
    }
}
