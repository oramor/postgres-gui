using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class EntityColumnForm : BaseObjectForm
    {
        EntityColumnDto _dao = new();

        protected EntityColumnForm() : base()
        {
            InitializeComponent();
        }

        public EntityColumnForm(int objId) : base("Entity Column", objId)
        {
            InitializeComponent();
            Init();

        }

        protected override void Init()
        {
            base.Init();
            FillComboBoxTypes();
            FillComboBoxEntity();
        }

        private void FillComboBoxTypes()
        {
            var cmd = ApiAdmin.GetLogicalDataTypeShortList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            this.comboBoxControlLogicalType.Bind(dt);
        }

        private void FillComboBoxEntity()
        {
            var cmd = ApiAdmin.GetEntityShortList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            this.comboBoxControlEntity.Bind(dt);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click!!!!!!");
        }
    }
}
