namespace Lib.GuiCommander
{
    /// <summary>
    /// В методе BindControls базовая форма подписывается на событие обновления контрола
    /// (т.е. добавляет в объект делегата контрола ссылку на метод OnControlChanged).
    /// Вызов этого метода в любом из контролов приведет к обновлению статуса самой
    /// формы (IsModified = true), что приведет к появлению запроса на подтверждение
    /// действия перед закрытием.
    /// </summary>
    public delegate void ControlChangedEventHandler(object sender, EventArgs e);

    public interface IBaseControl
    {
        event ControlChangedEventHandler ControlChanged;
        bool IsEmpty { get; }
        bool IsRequired { get; set; }
        bool IsReadOnly { get; set; }
        void Bind(EntityObject obj);
    }
}
