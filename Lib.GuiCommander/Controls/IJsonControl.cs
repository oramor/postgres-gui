﻿namespace Lib.GuiCommander
{
    /// <summary>
    /// Любые контролы, которые реализуют данный интерфейс, могут возвращать
    /// nulluble-типы, что означает: текущее значение не задано (например,
    /// не выбран селект).
    /// </summary>
    public interface IJsonControl<T>
    {
        string? CamelName { get; set; }
        /// <summary>
        /// Это свойство не должно вызывать OnControlValueChanged, оно только
        /// отвечает за инициализацию значений. Событие, что контрол изменен,
        /// отправляется из обработчика стандатного события, которое отслеживает
        /// изменение значения (например, IntControl_ValueChanged)
        /// </summary>
        T CurrentValue { get; }
    }
}
