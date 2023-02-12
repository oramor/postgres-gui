namespace Gui.Desktop.Forms
{
    public partial class DataRecordListForm : Form
    {
        #region Constructors

        protected DataRecordListForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Этот вариант конструктора используется при отсутствии метаданных,
        /// когда форма передается явно. Предполагается, что в этом случае
        /// функции имеют формат имени fn_entity_name_get_list_t
        /// </summary>
        public DataRecordListForm(string dataDomainName)
            : this()
        {
            var grid = new DataRecordGridWrapper(gridControl, dataDomainName);
            grid.RowActionSucceed += Grid_ActionSucceed;
            grid.Load();
        }

        #endregion

        void Grid_ActionSucceed(DataRecordGridWrapper wrapper, RowActionSucceedEventArgs args)
        {
            MessageBox.Show("Removed row with index " + args.RowIndex);
        }
    }
}
