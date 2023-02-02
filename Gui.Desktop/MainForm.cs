using Gui.Desktop.Forms;
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

        private void newEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowModalForm(new EntityForm());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(App.About);
        }

        private void entitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowModalForm(new EntityListForm());
        }

        private void newEntityColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowModalForm(new DbTableColumnCustom(0));
        }

        private void newDbTableColumnFkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowModalForm(new DbTableColumnFk(0));
        }

        #endregion
    }
}