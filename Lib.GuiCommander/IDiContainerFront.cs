using Lib.Providers;

namespace Lib.GuiCommander
{
    /// <summary>
    /// Простейший DI-контейнер, который хранится на уровне
    /// инстанса главной формы
    /// </summary>
    public interface IDiContainerFront<TLogger>
    {
        IDbProvider DbProvider { get; }
        TLogger Logger { get; }
    }
}
