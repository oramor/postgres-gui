namespace Gui.Desktop.Forms
{
    public partial class DbTableColumnFk : BaseObjectForm
    {
        protected DbTableColumnFk() : base()
        {
            InitializeComponent();
        }

        public DbTableColumnFk(int objId)
    : base(new DbTableColumnDto { FormType = GuiFormTypeEnum.Fk }, "Table column (FK)", "db_table_column", objId)
        {
            InitializeComponent();
            Init();
        }
    }
}
