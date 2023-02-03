using Lib.GuiCommander.Controls;
using System.ComponentModel;

namespace Lib.GuiCommander
{
    [Flags]
    public enum DataRecordState
    {
        None = 0,       // объект еще не записан
        Saved = 1,      // виден другим пользователям системы (не обязательно, что проведен)
        Draft = 2,      // записан, но виден только автору
        Deleted = 4,    // marked for remove
        Commited = 8    // объект записан и проведен по регистрам (Saved+)
    }

    /// <summary>
    /// В отличие от стандартного делегата <see cref="INotifyPropertyChanged"/>
    /// здесь отправителем всегда является инстанс контекста, что позволяет контролу
    /// не хранить постоянно ссылку на контекст, а так же извлекать данные из
    /// контекста по ключу
    /// </summary>
    public delegate void ContextPropertyChangedEventHandler(IObservableContext sender, PropertyChangedEventArgs e);

    /// <summary>
    /// Раньше наследовался от <see cref="INotifyPropertyChanged"/>, но удобнее
    /// отправлять подписчикам типизированный инстанс контекста
    /// </summary>
    public interface IObservableContext
    {
        /// <summary>
        /// Каждый контрол, реализующий <see cref="IBaseControl"/>, подписывается
        /// в своей реализации метода Bind() на обновления контекста. При обработке
        /// события значение контрола будет обновляться, т.к. единственный true source
        /// это контекст
        /// </summary>
        event ContextPropertyChangedEventHandler? ContextPropertyChanged;

        /// <summary>
        /// Этот обработчик позволяет реализовать двухстороннее связывание:
        /// когда котекст биндится к контролам на форме, он подписывается
        /// на каждый контрол, в котором реализован интерфейс <see cref="IBaseControl"/>
        /// </summary>
        void ControlValueChangedEventHandler(IBaseControl sender, ControlValueChangedEventArgs e);

        object? this[string propName] { get; set; }

        int Id { get; set; }
        int Version { get; set; }
        DataRecordState State { get; set; }
    }
}
