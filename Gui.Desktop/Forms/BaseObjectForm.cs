namespace Gui.Desktop.Forms
{
    public partial class BaseObjectForm : Form
    {
        string _objName;
        int _objId;

        protected BaseObjectForm()
        {
            InitializeComponent();
        }

        public BaseObjectForm(string objName, int objId)
        {
            InitializeComponent();
            _objName = objName;
            _objId = objId;
        }

        /// <summary>
        /// Возможно переопределение для более сложной логики инициализации
        /// В этом случае все равно должен быть вызван base.Init()
        /// </summary>
        protected virtual void Init()
        {
            SetTitle();
        }

        void SetTitle()
        {
            this.Text = _objId == 0
                ? "Create " + _objName
                : _objName + " # " + _objId.ToString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
