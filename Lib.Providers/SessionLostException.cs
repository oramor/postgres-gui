namespace Lib.Providers
{
    /// <summary>
    /// Notify Gui-client that session or database connection have lost
    /// and user should repeat auth/connection process. Usually GUI-client
    /// shows auth/connection form.
    /// </summary>
    public enum CommanHandlerType { Query, Execute }

    public class SessionLostException : Exception
    {
        public SessionLostException(ApiCommand command, CommanHandlerType commandHandlerType)
        {
            Command = command;
            HandlerType = commandHandlerType;
        }

        public ApiCommand Command { get; }
        /// <summary>
        /// Otherwise it is not obviously what method should be called
        /// </summary>
        public CommanHandlerType HandlerType { get; }
    }
}
