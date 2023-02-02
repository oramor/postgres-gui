using Lib.Providers;

namespace Gui.Desktop.Forms
{
    public partial class ConnectionForm : Form
    {
        private readonly IDbProvider _db;
        private readonly ReloadParentForm _reloadParentDelegate;

        private string _hostField = string.Empty;
        private string _portField = string.Empty;
        private string _databaseField = string.Empty;
        private string _usernameField = string.Empty;
        private string _passwordField = string.Empty;

        public delegate void ReloadParentForm();

        public ConnectionForm(IDbProvider pg, ReloadParentForm reload)
        {
            InitializeComponent();
            _db = App.DbProvider;
            _reloadParentDelegate = reload;

            ReloadButtons();

            if (_db.IsConnected)
            {
                FillFields();
            }
        }

        private void FillFields()
        {
            this.textBoxHost.Text = _db.Host;
            this.textBoxPort.Text = _db.Port;
            this.textBoxDatabase.Text = _db.Database;
            this.textBoxUsername.Text = _db.Username;
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
                App.ShowInputRequiredDialog("Host", this);
            }
        }

        private void ReloadButtons()
        {
            this.btnDisconnect.Visible = _db.IsConnected;
            this.btnConnect.Enabled = !_db.IsConnected;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SetFieldValues();
            CheckFields();

            try
            {
                _db.TryConnect(new DbConnectionParams(_hostField, _portField, _databaseField, _usernameField, _passwordField));
            } catch
            {
                App.ShowErrorDialog("Connection attempt failed: database error occured");
            }

            ReloadButtons();
            _reloadParentDelegate();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                _db.TryDisconnect();
            } catch
            {
                App.ShowErrorDialog("Disconnection attempt failed: database error occured");
            }

            ReloadButtons();
            _reloadParentDelegate();
        }
    }
}
