using Gui.Desktop.Forms;
using Lib.GuiCommander;
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

        #region Dependency Injection

        public static IDiContainerFront<IFrontLogger> DiContainer
        {
            get {
                var mainForm = GetMainForm();
                /// Фактически у нас инстанс главной формы и является DI-контейнером.
                /// То есть ссылка на инстанс главной формы передается во все другие
                /// формы, где нужно реализовать DI
                var di = (IDiContainerFront<IFrontLogger>)mainForm;
                if (di == null)
                {
                    throw new Exception("MainForm should be compatible with IDiContainer");
                }

                return di;
            }
        }

        public static IDbProvider DbProvider => DiContainer.DbProvider;
        public static IFrontLogger Logger => DiContainer.Logger;

        #endregion

        public static void ShowChildForm(Form form)
        {
            form.Show();
        }

        public static void ShowModalForm(Form form)
        {
            form.ShowDialog();
        }

        public static void ShowDataRecordListForm(string dataDomainName)
        {
            var form = new DataRecordListForm(dataDomainName);
            form.TopMost = true;
            form.Show();
        }

        public static void ShowDataRecordForm(string dataDomainName, int? id)
        {
            ShowDataRecordForm(dataDomainName, "", id);
        }

        public static void ShowDataRecordForm(string dataDomainName, string postfix, int? id)
        {
            var ctx = new DataRecordContext(dataDomainName, id);
            var form = ctx.GetForm(postfix);
            //form.MdiParent = GetMainForm();
            form.Show();
        }

        public static IDataRecordContext GetDataRecordContext(string dataDomainName, int id)
        {
            return new DataRecordContext(dataDomainName, id);
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

        public static void ShowConnectionForm(bool closeAfterAction)
        {
            ShowModalForm(new ConnectionForm(DbProvider, closeAfterAction));
        }

        public static string About { get => "The about message will be soon later"; }
    }
}
