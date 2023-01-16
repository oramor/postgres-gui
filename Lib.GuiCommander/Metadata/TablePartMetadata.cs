namespace Lib.GuiCommander
{
    public class TablePartMetadata
    {
        readonly string _tablePartName;
        readonly string _tablePartId;

        public TablePartMetadata(string tablePartName)
        {
            _tablePartName = tablePartName;
            _tablePartId = tablePartName;
        }

        public string Name => _tablePartName;
        public string Id => _tablePartId;
    }
}
