namespace Gui.Desktop.Forms
{
    public partial class DbTableColumnFk : BaseObjectForm
    {
        protected DbTableColumnFk() : base()
        {
            InitializeComponent();
        }

        public DbTableColumnFk(int objId)
    : base(new DbTableColumnDto { FormType = DbTableColumnFormType.Custom }, "Table column", "db_table_column", objId)
        {
            InitializeComponent();
            Init();
        }
    }
}
