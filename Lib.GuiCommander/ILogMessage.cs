using Microsoft.Extensions.Logging;

namespace Lib.GuiCommander
{
    /// <summary>
    /// Интерфейс нужен для того, чтобы типизировать параметр метода
    /// GuiReport у <see cref="IFrontLogger"/>
    /// </summary>
    public interface ILogMessage
    {
        LogLevel Level { get; }
        string Message { get; }
    }
}
