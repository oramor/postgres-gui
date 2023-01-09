using Lib.Providers;
using System.CodeDom;

namespace Gui.Desktop
{
    /// <summary>
    /// Простейший DI-контейнер, который хранится на уровне
    /// инстанса главной формы
    /// </summary>
    internal interface IDiContainer
    {
        IDbProvider DbProvider { get; }
    }
}
