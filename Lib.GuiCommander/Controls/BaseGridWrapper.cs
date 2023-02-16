using Microsoft.Extensions.Logging;

namespace Lib.GuiCommander.Controls
{
    public abstract class BaseGridWrapper
    {
        protected readonly GridControl _gridControl;

        public BaseGridWrapper(GridControl gridControl)
        {
            _gridControl = gridControl;
            _gridControl.Wrapper = this;
        }

        /// <summary>
        /// Already added in <see cref="GridControl"/> with designer
        /// </summary>
        protected ContextMenuStrip ContextMenu => _gridControl.ContextMenuStrip!;

        public event EventHandler<LogMessageEventArgs>? LogReported;
        protected void OnLogReported(LogLevel logLevel, string message)
        {
            LogReported?.Invoke(this, new LogMessageEventArgs(logLevel, message));
        }
    }
}
