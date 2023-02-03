namespace Lib.GuiCommander.Controls
{
    public class ControlValueChangedEventArgs : EventArgs
    {
        public ControlValueChangedEventArgs(object? newValue)
        {
            NewValue = newValue;
        }

        public object? NewValue { get; set; }
    }
}
