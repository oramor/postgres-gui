using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class DbTableColumnCustom : BaseObjectForm
    {
        protected DbTableColumnCustom() : base()
        {
            InitializeComponent();
        }

        public DbTableColumnCustom(int objId)
            : base(new DbTableColumnDto { FormType = GuiFormTypeEnum.Custom }, "Table column", "db_table_column", 265)
        {
            InitializeComponent();
            Init();
        }

        protected override void Init()
        {
            FillComboBoxTypes();
            FillComboBoxDbTable();
            base.Init();
        }

        private void FillComboBoxTypes()
        {
            var cmd = ApiAdmin.GetLogicalDataTypeShortList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            logicalTypeComboBoxControl.SetDataSource(dt);
        }

        private void FillComboBoxDbTable()
        {
            var cmd = ApiAdmin.GetDbTableList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            dbTableComboBoxControl.SetDataSource(dt);
        }
    }
}
