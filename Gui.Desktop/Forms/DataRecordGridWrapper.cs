using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using System.ComponentModel;
using System.Data;

namespace Gui.Desktop.Forms
{
    public class DataRecordGridWrapper : BaseGridWrapper
    {
        readonly string _dataDomainName;
        readonly ToolStripMenuItem _openMenuItem = new("Open") { Enabled = false };
        readonly ToolStripMenuItem _deleteMenuItem = new("Delete") { Enabled = false };

        public DataRecordGridWrapper(GridControl gridControl, string dataDomainName)
            : base(gridControl)
        {
            _dataDomainName = dataDomainName;
            _gridControl.CellMouseDoubleClick += GridControl_CellMouseDoubleClick;
            InitContextMenu();
        }

        string Token => _dataDomainName.ToSnakeCase();

        void InitContextMenu()
        {
            /// Добавляется заглушка, т.к. это меню всегда первое,
            /// но может не отображаться, если клик не по таблице
            ContextMenu.Items.Add(_openMenuItem);
            _openMenuItem.Click += OpenMenuItem_Click;

            var reloadItem = new ToolStripMenuItem("Reload");
            reloadItem.Click += ReloadMenuItem_Click;
            ContextMenu.Items.Add(reloadItem);

            var separator = new ToolStripSeparator();
            ContextMenu.Items.Add(separator);

            /// Так же заглушка
            ContextMenu.Items.Add(_deleteMenuItem);
            _deleteMenuItem.Click += DeleteMenuItem_Click;

            ContextMenu.Opening += ContextMenu_Opening;
            ContextMenu.Closed += ContextMenu_Closed;
        }

        public void Load()
        {
            DataTable dt = ApiProvider.GetList(Token);
            _gridControl.DataSource = dt;
        }

        #region Handlers

        void ContextMenu_Opening(object? sender, CancelEventArgs e)
        {
            Point locp = _gridControl.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo hti = _gridControl.HitTest(locp.X, locp.Y);

            if (hti.Type == DataGridViewHitTestType.ColumnHeader)
            {
                // Вообще не открываем меню при клике на заголовке
                e.Cancel = true;
            }
            else if (hti.Type == DataGridViewHitTestType.Cell)
            {
                _openMenuItem.Enabled = _gridControl.SelectedRows.Count == 1;
                _deleteMenuItem.Enabled = true;

                /// Это не только позволяет выделить строку, но и через CurrentRow
                /// получить id в обработчике клика
                _gridControl.CurrentCell = _gridControl[hti.ColumnIndex, hti.RowIndex];
            }

            GlobalMethods.CorrectSeparators(ContextMenu.Items);
        }

        void ContextMenu_Closed(object? sender, EventArgs e)
        {
            /// Отключаем все пункты меню, которые row id depend, чтобы они
            /// не появились в случае клика за пределами ячейки
            _openMenuItem.Enabled = false;
            _deleteMenuItem.Enabled = false;
        }

        void DeleteMenuItem_Click(object? sender, EventArgs e)
        {
            var cnt = _gridControl.SelectedRows.Count;
            if (cnt < 1)
                return;

            if (MessageBox.Show($"Delete {cnt} object(s) from Database? You will not undo this action!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (DataGridViewRow row in _gridControl.SelectedRows)
                {
                    var id = (int)row.Cells[AppSettings.IdColumnName].Value;
                    var ctx = App.GetDataRecordContext(_dataDomainName, id);
                    ctx.Delete();
                }

                App.Logger.GuiReport($"Removed {cnt} {_dataDomainName} object(s)");
            }
        }

        void OpenMenuItem_Click(object? sender, EventArgs e)
        {
            var id = (int)_gridControl.CurrentRow.Cells[AppSettings.IdColumnName].Value;
            App.ShowDataRecordForm(_dataDomainName, id);
        }

        void ReloadMenuItem_Click(object? sender, EventArgs e)
        {
            Load();
        }

        private void GridControl_CellMouseDoubleClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = (int)_gridControl[AppSettings.IdColumnName, e.RowIndex].Value;
            App.ShowDataRecordForm(_dataDomainName, id);
        }

        #endregion
    }
}
