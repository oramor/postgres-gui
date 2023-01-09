namespace Gui.Desktop.Forms
{
    public partial class EntityForm : GuiObjectForm
    {
        private string _entityName = string.Empty;
        private string _pascalName = string.Empty;
        private bool _isDocument = false;

        public EntityForm() : base()
        {
            InitializeComponent();
        }

        public EntityForm(int id) : base("entity", id)
        {
            InitializeComponent();
        }

        private void SetFieldValues()
        {
            _entityName = this.textBoxEntityName.Text;
            _pascalName = this.textBoxPascalName.Text;
            _isDocument = this.checkBoxIsDocument.Checked;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SetFieldValues();
            var cmdString = ApiAdmin.CreateEntity(_entityName, _pascalName, _isDocument);
            var entityId = CallApiMethod<int>(cmdString);
            MessageBox.Show(entityId.ToString());
        }
    }
}
