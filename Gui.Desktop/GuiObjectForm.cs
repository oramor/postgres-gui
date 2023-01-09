namespace Gui.Desktop
{
    public partial class GuiObjectForm : Form
    {
        int? _objectId;
        IDiContainer? _di;

        protected GuiObjectForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public GuiObjectForm(string objectName, int objectId)
        {
            InitializeComponent();
            _objectId = objectId;
            SetTitle(objectName);

            this.MaximizeBox = false;
        }

        private void SetTitle(string objectName)
        {
            if (_objectId.HasValue)
            {
                this.Text = $"{objectName} {_objectId.Value}";
            }
            else
            {
                this.Text = $"Create new {objectName}";
            }
        }

        public void InjectDi(IDiContainer di)
        {
            _di = di;
        }

        protected IEnumerable<T> CallApiMethod<T>(string cmd)
        {
            var db = _di?.DbProvider;
            if (db == null)
            {
                throw new Exception("Can't get DbProvider");
            }

            var result = db.Execute<T>(cmd);
            return result;
        }
    }
}
