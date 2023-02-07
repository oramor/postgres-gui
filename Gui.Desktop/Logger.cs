using Lib.GuiCommander;

namespace Gui.Desktop
{
    public class Logger : ILogger
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
    }
}
