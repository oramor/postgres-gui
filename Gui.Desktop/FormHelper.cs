using Gui.Desktop.Forms;

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

            /// Фактически у нас инстанс главной формы и является DI-контейнером.
            /// То есть ссылка на инстанс главной формы передается во все другие
            /// формы, где нужно реализовать DI
            var di = (IDiContainer)mainForm;
            if (di == null)
            {
                ShowErrorDialog("MainForm should be compatible with IDiContainer");
            }
        }

        public static void ShowModalForm(Form form)
        {
            form.ShowDialog();
        }

        public static void ShowChildForm(Form form)
        {
            /// Одна из задач FormHelper заключается в том, чтобы инжектить
            /// DI-контейнер (через init(di)?). Тем самым нет необходимости
            /// передавать его каждый раз при инстансе формы. 
            /// 

            /// Проверяем через каст (можно свитч) и, если совпадает,
            /// инжектим DI
            /// var guiForm = form as GuiObjectForm;
            /// InjectDi()


            //form.MdiParent = mainForm;
            form.Show();
        }

        public static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInputRequiredDialog(string inputName, Form parentForm)
        {
            var message = $"Field {inputName} is required";
            MessageBox.Show(message, "Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
