using Lib.Providers;

namespace Gui.Desktop
{
    public partial class GuiObjectForm : Form
    {
        int? _objectId;

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

        protected static T CallApiCommand<T>(ApiCommand cmd)
        {
            var db = App.DbProvider;
            var result = db.Execute<T>(cmd);
            return result;
        }
    }
}
