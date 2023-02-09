using Lib.GuiCommander;
using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class DbTableColumnCustomForm : DataRecordForm
    {
        protected DbTableColumnCustomForm() : base()
        {
            InitializeComponent();
        }

        public DbTableColumnCustomForm(IDataRecordContext ctx)
            : base(ctx)
        {
            InitializeComponent();
            LoadComboBoxTypes();
            LoadComboBoxDbTable();
            Init();
        }

        private void LoadComboBoxTypes()
        {
            DataTable dt = ApiProvider.GetShortList("logical_data_type");
            logicalTypeComboBoxControl.SetDataSource(dt);
        }

        private void LoadComboBoxDbTable()
        {
            DataTable dt = ApiProvider.GetShortList("db_table");
            dbTableComboBoxControl.SetDataSource(dt);
        }
    }
}
