using Lib.GuiCommander;

namespace Gui.Desktop.Forms
{
    public partial class ObjectListForm : Form
    {
        readonly string? _schemaName;
        readonly string? _funcName;
        readonly IDiContainer? _di;

        #region Constructors

        protected ObjectListForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Этот вариант конструктора используется при отсутствии метаданных,
        /// когда форма передается явно. Предполагается, что в этом случае
        /// функции имеют формат имени fn_entity_name_get_list_t
        /// </summary>
        public ObjectListForm(IDiContainer di, string token)
            : this()
        {
            _di = di;
            _schemaName = "api_admin";
            _funcName = "fn_" + token + "_get_list_t";

            // Load grid

        }

        #endregion

        //public void Init<T>(string routinePathName) where T: DataRecordForm, new()
        //{
        //    var cmd = new ApiCommand(routinePathName);
        //    var dt = _di.DbProvider.Query<DataTable>(cmd);
        //    OpenRecordFormDelegate d = (int id) => new T();
        //    var grid = new ObjectListGridWrapper(gridControl, _di, d);
        //    //grid.Load(dt);
        //}
    }
}
