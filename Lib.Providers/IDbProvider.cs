namespace Lib.Providers
{
    public interface IDbConnectionParams
    {
        public string Host { get; init; }
        public string Port { get; init; }
        public string Database { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }

    public interface IDbProvider
    {
        string Host { get; }
        string Port { get; }
        string Database { get; }
        string Username { get; }
        string ServerVersion { get; }
        bool IsConnected { get; }
        void TryConnect(IDbConnectionParams connParams);
        void TryDisconnect();
        IEnumerable<T> Execute<T>(string cmdString);
    }
}
