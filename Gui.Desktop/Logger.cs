namespace Gui.Desktop
{
    public interface ILogger
    {
        void GuiReport(string message);
    }

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
