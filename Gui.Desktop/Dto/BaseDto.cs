namespace Gui.Desktop.Dto
{
    public enum GuiFormTypeEnum
    {
        Custom = 1,
        Fk = 2,
        Abstract = 3,
    }

    public abstract class BaseDto
    {
        public GuiFormTypeEnum? FormType { get; set; }
    }
}
