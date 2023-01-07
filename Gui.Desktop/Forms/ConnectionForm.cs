using Lib.Providers;

namespace Gui.Desktop.Forms
{
    public partial class ConnectionForm : Form
    {
        private PostgresProvider _pg;

        private string _hostField = string.Empty;
        private string _portField = string.Empty;
        private string _databaseField = string.Empty;
        private string _usernameField = string.Empty;
        private string _passwordField = string.Empty;

        public ConnectionForm(PostgresProvider pg)
        {
            InitializeComponent();
            _pg = pg;

            ReloadButtons();
        }

        private void SetFieldValues()
        {
            _hostField = this.textBoxHost.Text;
            _portField = this.textBoxPort.Text;
            _databaseField = this.textBoxDatabase.Text;
            _usernameField = this.textBoxUsername.Text;
            _passwordField = this.textBoxPassword.Text;
        }

        private void CheckFields()
        {
            if (String.IsNullOrEmpty(_hostField))
            {
                MessageBox.Show("Host field is required");
            }
        }

        private void ReloadButtons()
        {
            this.btnDisconnect.Visible = _pg.IsConnected;
            this.btnConnect.Enabled = !_pg.IsConnected;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SetFieldValues();
            CheckFields();

            try
            {
                _pg.TryConnect(new PostgresConnectionParams {
                    Host = _hostField,
                    Port = _portField,
                    Database = _databaseField,
                    Username = _usernameField,
                    Password = _passwordField
                });
            } catch
            {
                MessageBox.Show("Error due DB connection");
            }

            ReloadButtons();
        }
    }
}
