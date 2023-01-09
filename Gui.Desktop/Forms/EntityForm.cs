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
            this.textBoxEntityName.Text = _entityName;
            this.textBoxPascalName.Text = _pascalName;
            this.checkBoxIsDocument.Checked = _isDocument;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SetFieldValues();
            var cmdString = ApiCommands.CreateEntity(_entityName, _pascalName, _isDocument);
            var entityId = this.CallApiMethod<int>(cmdString).FirstOrDefault();
            MessageBox.Show(entityId.ToString());
        }
    }
}
