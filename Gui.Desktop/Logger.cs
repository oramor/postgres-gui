using Lib.GuiCommander;
using Microsoft.Extensions.Logging;

namespace Gui.Desktop
{
    public class Logger : Lib.GuiCommander.ILogger
    {
        public delegate void UpdateGuiStatusReportDelegate(string message);
        UpdateGuiStatusReportDelegate _updDelegate;

        public Logger(UpdateGuiStatusReportDelegate updDelegate)
        {
            _updDelegate = updDelegate;
        }

        public void GuiReport(string message)
        {
            _updDelegate(message);
        }

        public void GuiReport(ILogMessage logMessage)
        {
            if (logMessage.Level == LogLevel.Information)
            {
                _updDelegate(logMessage.Message);
            }
        }
    }
}
