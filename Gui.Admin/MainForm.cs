namespace Gui.Admin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void connectToPostgresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ConnectionForm();
            form.ShowDialog();
        }
    }
}
