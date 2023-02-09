using Lib.GuiCommander;

namespace Gui.Desktop.Forms
{
    public partial class DbTableColumnFk : DataRecordForm
    {
        protected DbTableColumnFk() : base()
        {
            InitializeComponent();
        }

        public DbTableColumnFk(IDataRecordContext ctx)
            : base(ctx)
        {
            InitializeComponent();
            Init();
        }
    }
}
