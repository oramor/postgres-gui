using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
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
            _gridControl.CellMouseDown += GridControl_CellMouseDown;

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

        void ContextMenu_Opening(object? sender, EventArgs e)
        {
            GlobalMethods.CorrectSeparators(ContextMenu.Items);
        }

        void ContextMenu_Closed(object? sender, EventArgs e)
        {
            /// Отключаем все пункты меню, которые row id depend, чтобы они
            /// не появились в случае клика за пределами ячейки
            _openMenuItem.Enabled = false;
            _deleteMenuItem.Enabled = false;
        }

        /// <summary>
        /// Потребителем этой переменной является только обработчик клика, поэтому
        /// не важно, что кеш подвисает в случае клика за пределами ячейки
        /// </summary>
        int? _idCache;
        void GridControl_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            // Reset cache
            _idCache = Convert.ToInt32(_gridControl[AppSettings.IdColumnName, e.RowIndex].Value);

            // Чтобы подсветилась строка после клика
            _gridControl.CurrentCell = _gridControl[e.ColumnIndex, e.RowIndex];

            if (_idCache.HasValue)
            {
                // Здесь же возможна проверка прав
                _openMenuItem.Enabled = true;
                _deleteMenuItem.Enabled = true;
            }
        }

        void DeleteMenuItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Remove with id " + _idCache);
        }

        void OpenMenuItem_Click(object? sender, EventArgs e)
        {
            App.ShowDataRecordForm(_dataDomainName, _idCache);
        }

        void ReloadMenuItem_Click(object? sender, EventArgs e)
        {
            Load();
        }

        private void GridControl_CellMouseDoubleClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(_gridControl[AppSettings.IdColumnName, e.RowIndex].Value);
            App.ShowDataRecordForm(_dataDomainName, id);
        }

        #endregion
    }
}
