using Gui.Desktop.Forms;
using Lib.GuiCommander;
using Lib.Providers;

namespace Gui.Desktop
{
    public partial class MainForm : Form, IDiContainer
    {
        readonly IDbProvider _pg = new PostgresProvider();
        readonly ILogger _logger;

        public MainForm()
        {
            InitializeComponent();
            ReloadConnectionStatusLabel();
            UpdateLastCommandReportStatusStrip(string.Empty);

            _logger = new Logger(UpdateLastCommandReportStatusStrip);
        }

        public IDbProvider DbProvider => _pg;
        public ILogger Logger => _logger;

        private void ReloadConnectionStatusLabel()
        {
            this.toolStripStatusLabel1.Text = _pg.IsConnected
                    ? $"Connected to PostgreSQL {_pg.ServerVersion} (database {_pg.Database})"
                    : "Without database connection";
        }

        private void UpdateLastCommandReportStatusStrip(string message)
        {
            this.toolStripStatusLastCommandReport.Text = message;
        }

        #region Event Handlers

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowModalForm(new ConnectionForm(_pg, ReloadConnectionStatusLabel));
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