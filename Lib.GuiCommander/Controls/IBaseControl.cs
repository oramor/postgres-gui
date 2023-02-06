using Lib.GuiCommander.Controls;

namespace Lib.GuiCommander
{
    /// <summary>
    /// В методе BindControls базовая форма подписывается на событие обновления контрола
    /// (т.е. добавляет в объект делегата контрола ссылку на метод OnControlValueChanged).
    /// Типизация сендера как IBaseControl позволяет извлекать актуальные данные
    /// непосредственно в инстансе контекста формы. Кастомные элемент события <see cref="ControlValueChangedEventArgs"/> позволяет упаковать любое значение в объект,
    /// что является заменой обращения к слабо типизированному CurrentValue, которое
    /// предлагается из контролов удалить.
    /// </summary>
    public delegate void ControlValueChangedEventHandler(IBaseControl sender, ControlValueChangedEventArgs e);

    public interface IBaseControl
    {
        string? BindingName { get; set; }
        string? PascalName { get; }
        string? CamelName { get; }
        bool IsEmpty { get; }
        bool IsRequired { get; set; }
        bool IsReadOnly { get; set; }
        void Bind(IRecordFormContext ctx);
        /// <summary>
        /// На это событие подписываются как заинтересованные контролы,
        /// так и стейт формы.
        /// </summary>
        event ControlValueChangedEventHandler ControlValueChanged;
    }
}
