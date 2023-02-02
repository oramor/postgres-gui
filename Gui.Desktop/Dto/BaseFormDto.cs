namespace Gui.Desktop.Dto
{
    public enum GuiFormTypeEnum
    {
        Custom = 1,
        Fk = 2,
        Abstract = 3,
    }

    /// <summary>
    /// Наследники этого класса предназначены для отправки и получения
    /// данных с форм.
    /// </summary>
    public abstract class BaseFormDto
    {
        public GuiFormTypeEnum? FormType { get; set; }
    }
}
