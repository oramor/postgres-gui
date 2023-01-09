using Gui.Desktop.Forms;
using Lib.Providers;

namespace Gui.Desktop
{
    public partial class MainForm : Form, IDiContainer
    {
        private readonly IDbProvider _pg = new PostgresProvider();

        public MainForm()
        {
            InitializeComponent();
            ReloadConnectionStatusLabel();
        }

        public IDbProvider DbProvider { get { return _pg; } }

        private void ReloadConnectionStatusLabel()
        {
            this.toolStripStatusLabel1.Text = _pg.IsConnected
                    ? $"Connected to PostgreSQL {_pg.ServerVersion} (database {_pg.Database})"
                    : "Without database connection";
        }

        #region Events

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.ShowModalForm(new ConnectionForm(_pg, ReloadConnectionStatusLabel));
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

        #endregion

        private void newEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.ShowModalForm(new EntityForm());
        }
    }
}