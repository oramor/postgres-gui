using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using Lib.Providers;
using System.Data;

namespace Gui.Desktop.Forms
{
    /// <summary>
    /// В делегат должен быть передан идентификатор объекта, для которого
    /// должны быть открыта форма
    /// </summary>
    public delegate void OpenRecordFormDelegate(int dataRecordId);

    public class ObjectListGridWrapper : BaseGridWrapper
    {
        readonly OpenRecordFormDelegate _openFormDelegate;

        public ObjectListGridWrapper(GridControl gridControl, IDiContainer di, OpenRecordFormDelegate openFormDelegate)
            : base(gridControl, di)
        {
            _openFormDelegate = openFormDelegate;
            _gridControl.CellMouseDoubleClick += CellMouseDoubleClickHandler;
        }

        public void Load(string routinePathName)
        {
            var cmd = new ApiCommand(routinePathName);
            var dt = _di.DbProvider.Query<DataTable>(cmd);
            _gridControl.DataSource = dt;
        }

        #region Handlers

        private void CellMouseDoubleClickHandler(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int objectId = Convert.ToInt32(_gridControl["id", e.RowIndex].Value);
            _openFormDelegate.Invoke(objectId);
        }

        #endregion
    }
}
