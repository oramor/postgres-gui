using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class EntityColumnForm : BaseObjectForm
    {
        DbTableColumnDto _dto = new();

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

        //private void FillDto()
        //{
        //    _dto.SnakeName = snakeNameStringControl.CurrentValue;
        //    _dto.EntityId = entityComboBoxControl.CurrentValue;
        //    _dto.DefaultPriority = defaultPriorityNumericControl.CurrentValue;
        //    _dto.DefaultSize = defaultSizeNumericControl.CurrentValue;
        //    _dto.IsRequired = isRequiredBoolControl.CurrentValue;
        //}

        private void FillComboBoxTypes()
        {
            var cmd = ApiAdmin.GetLogicalDataTypeShortList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            this.logicalTypeComboBoxControl.Bind(dt);
        }

        private void FillComboBoxEntity()
        {
            var cmd = ApiAdmin.GetEntityShortList();
            var dt = App.CallApiCommand<DataTable>(cmd);
            this.entityComboBoxControl.Bind(dt);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var newDto = Grab(this, _dto) as DbTableColumnDto;
            if (newDto != null)
            {
                var cmd = ApiAdmin.CreateEntityColumn(newDto);
                var result = App.CallApiCommand<int>(cmd);
                MessageBox.Show("Created " + Convert.ToString(result));
            }

        }
    }
}
