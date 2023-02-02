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
        T Execute<T>(ApiCommand cmd);
        void ExecuteVoid(ApiCommand cmd);
    }
}
