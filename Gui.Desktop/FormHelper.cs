namespace Gui.Desktop
{
    public static class FormHelper
    {
        private static readonly Form mainForm;
        public static Form MainForm
        {
            get { return mainForm; }
        }

        static FormHelper()
        {
            mainForm = new MainForm();
        }
    }
}
