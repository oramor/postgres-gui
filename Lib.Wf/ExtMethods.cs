namespace Lib.Wf
{
    public static class ExtMethods
    {
        public static bool DataGridViewCellClicked(this DataGridView dataGridView, Point mousePosition)
        {
            Point locp = dataGridView.PointToClient(mousePosition);
            DataGridView.HitTestInfo hti = dataGridView.HitTest(locp.X, locp.Y);
            bool cellClicked = hti.Type == DataGridViewHitTestType.Cell;
            if (cellClicked)
                dataGridView.CurrentCell = dataGridView[hti.ColumnIndex, hti.RowIndex];

            return cellClicked;
        }

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
    }


}