using System.ComponentModel;

namespace Lib.GuiCommander.Controls
{
    public interface IIndexedContext : INotifyPropertyChanged
    {
        /// <summary>
        /// Публичный метод отправки событий позволяет обращаться к контексту
        /// одних форм из других
        /// </summary>
        void OnPropertyChanged(string propertyName, object? propertyValue);

        object? this[string propName] { get; set; }
    }
}
