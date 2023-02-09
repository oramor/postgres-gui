using Lib.GuiCommander;
using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class DbTableColumnCustom : DataRecordForm
    {
        protected DbTableColumnCustom() : base()
        {
            InitializeComponent();
        }

        public DbTableColumnCustom(IDataRecordContext ctx)
            : base(ctx)
        {
            InitializeComponent();
            LoadComboBoxTypes();
            LoadComboBoxDbTable();
            Init();
        }

        private void LoadComboBoxTypes()
        {
            var cmd = ApiProvider.GetLogicalDataTypeShortList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            logicalTypeComboBoxControl.SetDataSource(dt);
        }

        private void LoadComboBoxDbTable()
        {
            var cmd = ApiProvider.GetDbTableList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            dbTableComboBoxControl.SetDataSource(dt);
        }
    }
}
