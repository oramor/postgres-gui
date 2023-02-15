using Lib.GuiCommander;
using Lib.Providers;
using System.Data;

namespace Gui.Desktop
{
    public partial class MainForm : Form, IDiContainerFront<IFrontLogger>
    {
        readonly IDbProvider _pg = new PostgresProvider();
        readonly IFrontLogger _logger;

        public MainForm()
        {
            InitializeComponent();
            UpdateLastCommandReportStatusStrip(string.Empty);
            //this.LostFocus += MainForm_LostFocus;
            _pg.ConnectionStatusChanged += Db_ConnectionStatusChanged;

            _logger = new Logger(UpdateLastCommandReportStatusStrip);
        }

        public IDbProvider DbProvider => _pg;
        public IFrontLogger Logger => _logger;

        private void UpdateLastCommandReportStatusStrip(string message)
        {
            this.toolStripStatusLastCommandReport.Text = message;
        }

        #region Handlers

        void Db_ConnectionStatusChanged(object? sender, ConnectionState e)
        {
            this.toolStripStatusLabel1.Text = e == ConnectionState.Open
                    ? $"Connected to PostgreSQL {_pg.ServerVersion} (database {_pg.Database})"
                    : "Without database connection";
        }

        void MainForm_LostFocus(object sender, EventArgs e)
        {
            //foreach (Form form in Application.OpenForms)
            //{
            //    form.TopMost = false;
            //}
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowConnectionForm(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pg.TryDisconnect();
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(App.About);
        }

        #region List Menu

        private void entitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowDataRecordListForm("Entity");
        }

        #endregion

        #region Create Menu

        private void newEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowDataRecordForm("Entity", null);
        }

        private void newEntityColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowDataRecordForm("DbTableColumn", "Custom", null);
        }

        private void newDbTableColumnFkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowDataRecordForm("DbTableColumn", "Fk", null);
        }

        #endregion

        #endregion
    }
}