namespace Lib.GuiCommander
{
    public interface IFrontLogger
    {
        void GuiReport(ILogMessage message);
        void GuiReport(string message);
    }
}
