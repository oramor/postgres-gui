using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class DbTableColumnCustom : BaseObjectForm
    {
        protected DbTableColumnCustom() : base()
        {
            InitializeComponent();
        }

        public DbTableColumnCustom(int? objId)
            : base("Table column", "db_table_column", objId)
        {
            InitializeComponent();
            LoadComboBoxTypes();
            LoadComboBoxDbTable();
            Init<DbTableColumnDto>();
        }

        private void LoadComboBoxTypes()
        {
            var cmd = ApiAdmin.GetLogicalDataTypeShortList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            logicalTypeComboBoxControl.SetDataSource(dt);
        }

        private void LoadComboBoxDbTable()
        {
            var cmd = ApiAdmin.GetDbTableList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            dbTableComboBoxControl.SetDataSource(dt);
        }
    }
}
