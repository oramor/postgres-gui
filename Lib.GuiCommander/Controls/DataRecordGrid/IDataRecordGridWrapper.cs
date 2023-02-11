namespace Lib.GuiCommander.Controls.DataRecordGrid
{
    public interface IDataRecordGridWrapper
    {
        int? GetSelectedRowId();
        // GetSelectedRows();
        void Load();
    }
}
