namespace Lib.GuiCommander
{
    public static class WinFormsUtils
    {
        #region Extension Methods

        /// <summary>
        /// Определяет, выполнен ли клик по ячейке таблицы. Позволяет не отображаться
        /// пункты контекстного меню, которые относятся к конкретной сущности, если
        /// пользователь кликнул по пустой области таблицы
        /// </summary>
        public static bool DataGridViewCellClicked(this DataGridView dataGridView, Point mousePosition)
        {
            Point locp = dataGridView.PointToClient(mousePosition);
            DataGridView.HitTestInfo hti = dataGridView.HitTest(locp.X, locp.Y);
            bool cellClicked = hti.Type == DataGridViewHitTestType.Cell;
            if (cellClicked)
                dataGridView.CurrentCell = dataGridView[hti.ColumnIndex, hti.RowIndex];

            return cellClicked;
        }

        /// <summary>
        /// Метод определяет колонку с именем "id" и возвращает идентификатор
        /// сущности, либо -1, если колонка отсутствует
        /// </summary>
        public static int GetColumnIdValue(this DataGridView dataGridView)
        {
            var selected = dataGridView.SelectedRows;

            // Is available only for one selected row
            if (selected.Count != 1) return -1;

            var selectedRow = selected[0];

            int id = -1;

            // Finding cell which belongs column with name id
            foreach (DataGridViewCell cell in selectedRow.Cells)
            {
                var col = cell.OwningColumn;
                if (col == null) continue;

                var colName = col.Name;
                if (colName.ToLower() == "id")
                {
                    var v = cell.Value;
                    if (cell?.Value is int)
                    {
                        id = (int)cell.Value;
                        break;
                    }
                }
            }

            return id;
        }

        #endregion

        /// Можно сделать приватным и добавить статические методы расширения
        /// для каждого типа меню
        public static void CorrectSeparators(ToolStripItemCollection items)
        {
            ToolStripItem? prevItem = null;
            /// Флаг указывает, является ли предыдущий пункт сепаратором.
            /// Для удаления двойных сепараторов
            bool prevSeparator = false;

            foreach (ToolStripItem i in items)
            {
                /// В рамках этого корректора все не доступные пункты
                /// окажутся скрытыми
                i.Visible = i.Enabled;
                if (!i.Enabled)
                    continue;

                if (i is ToolStripSeparator)
                {
                    if (prevItem == null || prevSeparator)
                    {
                        /// Отключаем, если перед сепаратором ничего нет,
                        /// либо там тоже сепаратор
                        i.Visible = false;
                        continue;
                    }

                    prevSeparator = true;
                }
                else
                {
                    prevSeparator = false;
                }

                if (i is ToolStripDropDownItem d)
                    /// Циклично для вложенных пунктов. Собственно, этот
                    /// фрагмент не позволил сходу сделать данный метод
                    /// методом расширения для ToolStripMenu
                    CorrectSeparators(d.DropDownItems);

                prevItem = i;
            }

            if (prevItem != null && prevSeparator)
                prevItem.Visible = false;
        }
    }
}
