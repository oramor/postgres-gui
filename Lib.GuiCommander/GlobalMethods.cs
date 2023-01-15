namespace Lib.GuiCommander
{
    public static class GlobalMethods
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

        /// <summary>
        /// Позволяет проверить обязательные контролы и, возможно,
        /// выделить их отдельным цветом
        /// </summary>
        //public static bool CheckRequiredControls(Control parentControl, bool parentReturn)
        //{
        //    IBind bc;
        //    foreach (Control c in parentControl.Controls)
        //    {
        //        bc = c as IBaseControl;
        //        if (bc != null && bc.IsRequired && bc.IsEmpty)
        //        {
        //            parentReturn = false;
        //        }
        //        else if (c.Controls.Count > 0)
        //        {
        //            parentReturn = CheckMandatoryControls(c, parentReturn);
        //        }
        //    }
        //    return parentReturn;
        //}

        #endregion
    }
}
