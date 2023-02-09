using Lib.GuiCommander;

namespace Gui.Desktop.Forms
{
    public partial class DbTableColumnFkForm : DataRecordForm
    {
        protected DbTableColumnFkForm() : base()
        {
            InitializeComponent();
        }

        public DbTableColumnFkForm(IDataRecordContext ctx)
            : base(ctx)
        {
            InitializeComponent();
            Init();
        }
    }
}
