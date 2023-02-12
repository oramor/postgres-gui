namespace Lib.GuiCommander
{
    public interface ILogger
    {
        void GuiReport(ILogMessage message);
        void GuiReport(string message);
    }
}
