using Lib.Providers;

namespace Lib.GuiCommander
{
    /// <summary>
    /// Простейший DI-контейнер, который хранится на уровне
    /// инстанса главной формы
    /// </summary>
    public interface IDiContainer
    {
        IDbProvider DbProvider { get; }
        ILogger Logger { get; }
    }
}
