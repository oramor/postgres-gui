using Lib.GuiCommander;

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
            var grid = new DataRecordGridWrapper(gridControl, dataDomainName, () => App.ShowConnectionForm(true));
            grid.RowActionSucceed += Grid_ActionSucceed;
            grid.LogReported += Grid_LogReported;
            grid.Load();
        }

        #endregion

        void Grid_ActionSucceed(DataRecordGridWrapper wrapper, RowActionSucceedEventArgs<DataRecordActionType> args)
        {
            if (args.ActionType == DataRecordActionType.Delete)
            {
                wrapper.RemoveRow(args.RowIndex);
            }
        }

        void Grid_LogReported(object? sender, LogMessageEventArgs e)
        {
            App.Logger.GuiReport(e);
        }
    }
}
