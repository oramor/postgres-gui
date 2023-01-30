using System.ComponentModel;

namespace Gui.Desktop
{
    /// <summary>
    /// Реализация интерфейса INotifyPropertyChanged позволяет сделать любую
    /// DTO, которая наследуется от этого контекста, отслеживаемой. На событие
    /// PropertyChanged подписываются контролы.
    /// </summary>
    public abstract class BaseFormContext : IObjectFormContext
    {
        public GuiFormTypeEnum? FormType { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Это событие публично и служит для передачи контролам
        /// конкретного значения
        /// </summary>
        public void OnPropertyChanged(string propertyName, object? propertyValue)
        {
            if (propertyValue == null)
                return;

            PropertyChanged?.Invoke(propertyValue, new PropertyChangedEventArgs(propertyName));
        }
    }
}
