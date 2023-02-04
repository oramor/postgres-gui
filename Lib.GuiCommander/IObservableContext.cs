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

    public delegate void ContextChangedByUserEventHandler(IObservableContext sender, EventArgs e);

    /// <summary>
    /// Раньше наследовался от <see cref="INotifyPropertyChanged"/>, но удобнее
    /// отправлять подписчикам типизированный инстанс контекста
    /// </summary>
    public interface IObservableContext
    {
        /// <summary>
        /// Потребителями этого события являются контролы, реализовавшие интерфейс <see cref="IBaseControl"/>, что позволяет им отслеживать изменение контекста
        /// и приводить свой состояние в актуальное. Важно иметь в виду, что форма,
        /// которая хранит контекст, не должна подписываться на это событие для
        /// обновления IsModified, который зависит от ручного ввода пользователя.
        /// </summary>
        event ContextPropertyChangedEventHandler? ContextPropertyChanged;

        /// <summary>
        /// Это событие позволяет форме получить оповещеним об изменении контекста,
        /// которое было инициализировано со стороны пользователя. В свою очередь,
        /// форма меняет флаг IsModified, который соотносится только с пользовательским
        /// вводом
        /// </summary>
        event ContextChangedByUserEventHandler? ContextChangedByUser;

        /// <summary>
        /// Этот обработчик позволяет реализовать двухстороннее связывание:
        /// когда котекст биндится к контролам на форме, контрол не только подписывается
        /// на обновление контекста, но и подписывает форму на свои обновления
        /// (иначе обработчик не имело бы смысла делать публичным)
        /// </summary>
        void ControlValueChangedEventHandler(IBaseControl sender, ControlValueChangedEventArgs e);

        object? this[string propName] { get; set; }

        int Id { get; set; }
        int Version { get; set; }
        DataRecordState State { get; set; }
    }
}
