namespace Gui.Desktop
{
    public partial class GuiObjectForm : Form
    {
        private int? _objectId;

        protected GuiObjectForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public GuiObjectForm(string objectName, int objectId)
        {
            InitializeComponent();
            _objectId = objectId;
            SetTitle();

            this.MaximizeBox = false;
        }

        private void SetTitle()
        {
            if (_objectId.HasValue)
            {
                this.Text = $"Entity {_objectId.Value}";
            }
            else
            {
                this.Text = "Create new";
            }
        }
    }
}
