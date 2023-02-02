using System.ComponentModel;

namespace Lib.GuiCommander
{
    /// <summary>
    /// Используется для работы с экземплярами сущностей. Содержит
    /// индексатор, который используется для формирования свойств.
    /// </summary>
    public interface IRecordContext : INotifyPropertyChanged
    {
        /// <summary>
        /// Публичный метод отправки событий позволяет обращаться к контексту
        /// одних форм из других
        /// </summary>
        void OnPropertyChanged(string propertyName, object? propertyValue);

        object? this[string propName] { get; set; }
    }
}
