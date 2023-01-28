namespace Lib.GuiCommander.Controls
{
    public interface ILabelFieldControl
    {
        /// <summary>
        /// Поле содержит имя контрола и необходимо для того,
        /// чтобы метод GetLabel() базового контрола вернул
        /// ссылку на связанный контрол для его модификации
        /// </summary>
        string FieldName { get; set; }
    }
}
