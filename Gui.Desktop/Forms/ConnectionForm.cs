using Lib.Providers;
using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class ConnectionForm : Form
    {
        readonly IDbProvider _db;
        readonly bool _closeAfterAction;

        string _hostField = string.Empty;
        string _portField = string.Empty;
        string _databaseField = string.Empty;
        string _usernameField = string.Empty;
        string _passwordField = string.Empty;

        public ConnectionForm(IDbProvider dbProvider, bool closeAfterAction = false)
        {
            InitializeComponent();
            _db = dbProvider;
            _closeAfterAction = closeAfterAction;

            ReloadButtons();

            if (_db.IsConnected)
            {
                FillFields();
            }

            _db.ConnectionStatusChanged += Db_ConnectionStatusChanged;
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

        private void ReloadButtons()
        {
            this.btnDisconnect.Visible = _db.IsConnected;
            this.btnConnect.Enabled = !_db.IsConnected;
        }

        #region Handlers

        void Db_ConnectionStatusChanged(object? sender, ConnectionState e)
        {
            if (_closeAfterAction) this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SetFieldValues();

            try
            {
#if DEBUG
                _db.TryConnect(new DbConnectionParams("localhost", "5435", "demo", "demo", "demo"));
#else
                _db.TryConnect(new DbConnectionParams(_hostField, _portField, _databaseField, _usernameField, _passwordField));
#endif
            } catch
            {
                App.ShowErrorDialog("Connection attempt failed: database error occured");
            }

            ReloadButtons();
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
        }

        #endregion
    }
}
