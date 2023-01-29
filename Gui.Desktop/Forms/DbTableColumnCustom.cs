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
            : base(new DbTableColumnDto { FormType = DbTableColumnFormType.Custom }, "Table column", "db_table_column", objId)
        {
            InitializeComponent();
            Init();
        }

        protected override void Init()
        {
            base.Init();
            FillComboBoxTypes();
            FillComboBoxDbTable();
        }

        private void FillComboBoxTypes()
        {
            var cmd = ApiAdmin.GetLogicalDataTypeShortList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            logicalTypeComboBoxControl.Bind(dt);
        }

        private void FillComboBoxDbTable()
        {
            var cmd = ApiAdmin.GetDbTableList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            dbTableComboBoxControl.Bind(dt);
        }
    }
}
