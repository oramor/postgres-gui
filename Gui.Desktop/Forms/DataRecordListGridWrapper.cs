using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using System.Data;

namespace Gui.Desktop.Forms
{
    public class DataRecordListGridWrapper : BaseGridWrapper
    {
        public readonly string _dataDomainName;

        public DataRecordListGridWrapper(GridControl gridControl, string dataDomainName)
            : base(gridControl)
        {
            _dataDomainName = dataDomainName;
            _gridControl.CellMouseDoubleClick += CellMouseDoubleClickHandler;
        }

        string Token => _dataDomainName.ToSnakeCase();

        public void Load()
        {
            DataTable dt = ApiProvider.GetList(Token);
            _gridControl.DataSource = dt;
        }

        #region Handlers

        private void CellMouseDoubleClickHandler(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int objectId = Convert.ToInt32(_gridControl["id", e.RowIndex].Value);
            App.ShowDataRecordForm(_dataDomainName, objectId);
        }

        #endregion
    }
}
