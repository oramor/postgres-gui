namespace Lib.Providers
{
    /// <summary>
    /// Позволяет повторить команду после того, как соединение будет
    /// восстановлено
    /// </summary>
    public enum CommanHandlerType { Query, Execute }

    public class DbDisconnectException : Exception
    {
        public DbDisconnectException(ApiCommand command, CommanHandlerType commandHandlerType)
        {
            Command = command;
            HandlerType = commandHandlerType;
        }

        public ApiCommand Command { get; }
        /// <summary>
        /// Иначе будет не ясно, в какой метод отправлять команду
        /// </summary>
        public CommanHandlerType HandlerType { get; }
    }
}
