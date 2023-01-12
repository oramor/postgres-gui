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
    }
}