using Lib.GuiCommander;

namespace Gui.Desktop.Forms
{
    public partial class EntityForm : EntityBaseForm
    {
        private EntityDto _dao = new();

        public EntityForm() : base()
        {
            InitializeComponent();
        }

        public EntityForm(int entityId) : base()
        {
            InitializeComponent();
        }

        private void SetFieldValues()
        {
            _dao.PublicName = this.stringControlPublicName.Text;
            _dao.PascalName = this.stringControlPascalName.Text;
            _dao.PublicCode = this.stringControlPublicCode.Text;
            _dao.IsDocument = this.checkBoxIsDocument.Checked;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SetFieldValues();
            var apiCmd = ApiAdmin.CreateEntity(_dao);
            var entityId = App.CallApiCommand<int>(apiCmd);
            App.Logger.GuiReport("Created Entity with Id " + entityId);
            this.Close();
        }
    }
}
