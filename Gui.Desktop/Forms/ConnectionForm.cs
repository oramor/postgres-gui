using Lib.Providers;

namespace Gui.Desktop.Forms
{
    public readonly struct DbConnectionParams : IDbConnectionParams
    {
        public string Host { get; init; }
        public string Port { get; init; }
        public string Database { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }

    public partial class ConnectionForm : Form
    {
        private readonly IDbProvider _pg;
        private readonly ReloadParentForm _reloadParent;

        private string _hostField = string.Empty;
        private string _portField = string.Empty;
        private string _databaseField = string.Empty;
        private string _usernameField = string.Empty;
        private string _passwordField = string.Empty;

        public delegate void ReloadParentForm();

        public ConnectionForm(IDbProvider pg, ReloadParentForm reload)
        {
            InitializeComponent();
            _pg = pg;
            _reloadParent = reload;

            ReloadButtons();

            if (pg.IsConnected)
            {
                FillFields();
            }
        }

        private void FillFields()
        {
            this.textBoxHost.Text = _pg.Host;
            this.textBoxPort.Text = _pg.Port;
            this.textBoxDatabase.Text = _pg.Database;
            this.textBoxUsername.Text = _pg.Username;
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
                FormHelper.ShowInputRequiredDialog("Host", this);
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
                _pg.TryConnect(new DbConnectionParams {
                    Host = _hostField,
                    Port = _portField,
                    Database = _databaseField,
                    Username = _usernameField,
                    Password = _passwordField
                });
            } catch
            {
                FormHelper.ShowErrorDialog("Connection attempt failed: database error occured");
            }

            ReloadButtons();
            _reloadParent();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                _pg.TryDisconnect();
            } catch
            {
                FormHelper.ShowErrorDialog("Disconnection attempt failed: database error occured");
            }

            ReloadButtons();
            _reloadParent();
        }
    }
}
