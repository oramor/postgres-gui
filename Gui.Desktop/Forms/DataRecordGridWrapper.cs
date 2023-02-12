using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Data;

namespace Gui.Desktop.Forms
{
    /// <summary>
    /// Например, событие удаления строки может по-разному обрабатываться на формах.
    /// Например, если на форме есть фильтр по удаленным и он активен, то удаленная строка
    /// просто будет подсвечена. А если в приложении строки удаляются физически,
    /// то форма отдаст врапперу команду удалить строку с нужным индексом из таблицы,
    /// что позволит не обновлять всю таблицу целиком.
    /// 
    /// Класс создан обобщенным, т.к. в различных вариантах приложения, для разных
    /// врапперов, возможны свои варианты ActionType (например, для документов
    /// добавляется Commited).
    /// </summary>
    public class RowActionSucceedEventArgs<T> : EventArgs
    {
        public RowActionSucceedEventArgs(T actionType, int rowIndex)
        {
            ActionType = actionType;
            RowIndex = rowIndex;
        }
        public T ActionType { get; }
        /// <summary>
        /// По иднексу строки мы всегда можем получить id сущности
        /// </summary>
        public int RowIndex { get; }
    }

    /// <summary>
    /// На форме может быть несколько грид-контролов, которые получают оповещения
    /// от различных врапперов. Чтобы форма могла определить, какому врапперу
    /// передавать команду, возвращается ссылка на сам враппер.
    /// </summary>
    public delegate void RowActionSucceedEventHandler(DataRecordGridWrapper wrapper, RowActionSucceedEventArgs<DataRecordActionType> args);

    /// <summary>
    /// Врапперы не должны модифицировать себя самостоятельно. Это решение
    /// принимает форма, которую они оповещают. Это обусловлено тем, что 
    /// на форме могут быть контролы, состояние которых определяет опведение грида
    /// (например, фильтры). Враппер ничего не знает (и не должне знать)
    /// об этих контролах.
    /// </summary>
    public class DataRecordGridWrapper : BaseGridWrapper
    {
        //readonly string DataDomainName;
        readonly ToolStripMenuItem _openMenuItem = new("Open") { Enabled = false };
        readonly ToolStripMenuItem _deleteMenuItem = new("Delete") { Enabled = false };

        public DataRecordGridWrapper(GridControl gridControl, string dataDomainName)
            : base(gridControl)
        {
            DataDomainName = dataDomainName;
            _gridControl.CellMouseDoubleClick += GridControl_CellMouseDoubleClick;
            InitContextMenu();
        }

        string Token => DataDomainName.ToSnakeCase();

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

        #region Public Methods

        public void Load()
        {
            DataTable dt = ApiProvider.GetList(Token);
            _gridControl.DataSource = dt;
        }

        public void RemoveRow(int rowIndex)
        {
            _gridControl.Rows.RemoveAt(rowIndex);
        }

        public string DataDomainName { get; }

        #endregion

        #region Events

        /// <summary>
        /// Формы, которые инициировали грид через враппер, могут получать оповещения
        /// о событиях со строками этого грида (например, оповещение об удалении)
        /// </summary>
        public event RowActionSucceedEventHandler? RowActionSucceed;
        private void OnRowActionSucceed(DataRecordActionType actionType, int rowIndex)
        {
            RowActionSucceed?.Invoke(this, new RowActionSucceedEventArgs<DataRecordActionType>(actionType, rowIndex));
        }

        #endregion

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
                    var ctx = App.GetDataRecordContext(DataDomainName, id);
                    /// Но вообще у Delete есть свое событие об успешном заверщении операции,
                    /// но может ли подписка на него в цикле привести к утечке памяти?
                    ctx.Delete();
                    OnRowActionSucceed(DataRecordActionType.Delete, row.Index);
                }

                var logMessage = $"Removed {cnt} {DataDomainName} object(s)";
                OnLogReported(LogLevel.Information, logMessage);
            }
        }

        void OpenMenuItem_Click(object? sender, EventArgs e)
        {
            var id = (int)_gridControl.CurrentRow.Cells[AppSettings.IdColumnName].Value;
            App.ShowDataRecordForm(DataDomainName, id);
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
            App.ShowDataRecordForm(DataDomainName, id);
        }

        #endregion
    }
}
