namespace Lib.GuiCommander.Controls
{
    /// <summary>
    /// Каждый контрол, который подписывается на этот вид события, должен будет
    /// реализовать приватный обработчик, в котором, например, меняется
    /// его подсветка. Поле IsImmutable сообщает, что при повторном вводе
    /// инвалидного значения, контрол снова должен получить визуальный код ошибки
    /// (по дефолту контролы перестают подсвечиваться инвалидными, если
    /// значение в них было изменено).
    /// </summary>
    public class PropertyInvalidatedEventArgs : EventArgs
    {
        public PropertyInvalidatedEventArgs(string propertyName, string message, bool isImmutable = false)
        {
            PropertyName = propertyName;
            Message = message;
            IsImmutable = isImmutable;
        }

        public string PropertyName { get; init; }
        public string Message { get; init; }
        public bool IsImmutable { get; init; }
    }
}
