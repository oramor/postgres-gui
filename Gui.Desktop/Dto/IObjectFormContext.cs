using System.ComponentModel;

namespace Gui.Desktop
{
    public enum GuiFormTypeEnum
    {
        Custom = 1,
        Fk = 2,
        Abstract = 3,
    }

    public interface IObjectFormContext : INotifyPropertyChanged
    {
        GuiFormTypeEnum? FormType { get; set; }
        void OnPropertyChanged(string propertyName, object? propertyValue);
    }
}
