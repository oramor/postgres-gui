using Lib.GuiCommander.Controls;
using Microsoft.Extensions.Logging;

namespace Lib.GuiCommander
{
    /// <summary>
    /// Чтобы не связывать такие классы как, наследники <see cref="BaseGridWrapper"/>
    /// с конкретной реализацией логгера, выглядит логичным подписывать формы на события
    /// логирования LogReported. Другим вариантом явлется отправка в такие классы
    /// делегата, вызов которого приведет к логированию.
    /// </summary>
    public class LogMessageEventArgs : EventArgs, ILogMessage
    {
        public LogMessageEventArgs(LogLevel level, string message)
        {
            Level = level;
            Message = message;
        }

        public LogLevel Level { get; }
        public string Message { get; }
    }
}
