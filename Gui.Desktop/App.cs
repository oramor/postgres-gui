using Lib.Providers;

namespace Gui.Desktop
{
    public class App : ApplicationContext
    {
        public App(Form mainForm)
        {
            this.MainForm = mainForm;
            mainForm.Show();
        }

        public static Form GetMainForm()
        {
            foreach (Form form in Application.OpenForms)
                if (form is MainForm mainForm)
                    return mainForm;

            throw new Exception("Main Form did not found");
        }

        public static IDiContainer DiContainer
        {
            get {
                var mainForm = GetMainForm();
                /// Фактически у нас инстанс главной формы и является DI-контейнером.
                /// То есть ссылка на инстанс главной формы передается во все другие
                /// формы, где нужно реализовать DI
                var di = (IDiContainer)mainForm;
                if (di == null)
                {
                    throw new Exception("MainForm should be compatible with IDiContainer");
                }

                return di;
            }
        }

        public static IDbProvider DbProvider => DiContainer.DbProvider;
        public static ILogger Logger => DiContainer.Logger;

        public static void ShowChildForm(Form form)
        {
            // Mdi TODO
            form.Show();
        }

        public static void ShowModalForm(Form form)
        {
            form.ShowDialog();
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

        public static string About { get => "The about message will be soon later"; }

        public static T CallApiCommand<T>(ApiCommand cmd)
        {
            var result = DbProvider.Execute<T>(cmd);
            return result;
        }
    }
}
