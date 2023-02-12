namespace Lib.GuiCommander.Controls
{
    /// <summary>
    /// По дефолту для активации меню нужно сперва активировать главную форму.
    /// Этот класс отслеживает события операционной системы, чтобы лишний
    /// клик не требовался. Аналогично можно поступить с ToolStrip
    /// https://stackoverflow.com/questions/3427696/windows-requires-a-click-to-activate-a-window-before-a-second-click-will-select
    /// </summary>
    public class MainMenuControl : MenuStrip
    {
        const uint WM_LBUTTONDOWN = 0x201;
        const uint WM_LBUTTONUP = 0x202;

        static private bool down = false;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONUP && !down)
            {
                m.Msg = (int)WM_LBUTTONDOWN; base.WndProc(ref m);
                m.Msg = (int)WM_LBUTTONUP;
            }

            if (m.Msg == WM_LBUTTONDOWN) down = true;
            if (m.Msg == WM_LBUTTONUP) down = false;

            base.WndProc(ref m);
        }
    }
}
