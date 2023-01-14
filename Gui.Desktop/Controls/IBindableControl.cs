namespace Gui.Desktop.Controls
{
    /// <summary>
    /// Событие ловится на форме <see cref="GuiObjectForm"/> и обновляет статус
    /// формы на changed, что влияет на вопрос перед ее закрытием
    /// </summary>
    public delegate void ControlChangedEventHandler(object sender, EventArgs e);

    public interface IBindableControl
    {
        int Id { get; set; }
        bool IsEmpty { get; }
        bool IsRequired { get; set; }
        bool IsReadOnly { get; set; }
        string ColumnName { get; set; }
        void Bind();
        event ControlChangedEventHandler ControlChanged;
    }
}
