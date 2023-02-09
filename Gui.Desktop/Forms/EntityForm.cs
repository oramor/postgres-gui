using Lib.GuiCommander;

namespace Gui.Desktop.Forms
{
    public partial class EntityForm : DataRecordForm
    {
        protected EntityForm() : base()
        {
            InitializeComponent();
        }

        public EntityForm(IDataRecordContext ctx) : base(ctx)
        {
            InitializeComponent();
            Init();
        }
    }
}
