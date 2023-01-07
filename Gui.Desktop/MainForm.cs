using Gui.Desktop.Forms;
using Lib.Providers;

namespace Gui.Desktop
{
    public partial class MainForm : Form
    {
        private readonly PostgresProvider _pg = new();

        public MainForm()
        {
            InitializeComponent();
            ReloadConnectionStatusLabel();
        }

        private void ReloadConnectionStatusLabel()
        {
            this.toolStripStatusLabel1.Text = _pg.IsConnected
                    ? $"Connected to PostgreSQL {_pg.ServerVersion} (database {_pg.Database})"
                    : "Without database connection";
        }

        #region Events

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ConnectionForm(_pg, ReloadConnectionStatusLabel);
            form.ShowDialog();
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
    }
}