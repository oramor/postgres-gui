using Lib.GuiCommander.Controls;

namespace Lib.GuiCommander
{
    /// <summary>
    /// Интерфейс, которому должна соответствовать любая вьюмодель
    /// (в том числе универсальная вьюмодель с индексными свойствами)
    /// </summary>
    public interface IDataRecordContext : IObservableContext, IInvalidPropertyNotify
    {
        /// <summary>
        /// Ключевое свойство, на которое завязаны многие внутренние функции
        /// вьюмодели. Например, формирования имени процедуры для запроса
        /// данных из БД.
        /// </summary>
        string DataDomainName { get; init; }
        /// <summary>
        /// Загрузит форму, используя позднее связывание. Контекст (ViewModel)
        /// первичен по отношению к формам (View). На практике инстансы форм
        /// не должны создаваться в коде явно — только чере позднее связывание
        /// из вьюмоделей.
        /// </summary>
        void ShowForm(string postfix = "");
        /// Можно добавить перегрузку этого метода с указанием постфикса
        /// для записей, которые имеют несколько вариантов форм
        //void ShowForm(string formCode);

        event EventHandler<EventArgs> ActionSucceed;
        void Create();
        void Update();
        void Delete();
    }
}
