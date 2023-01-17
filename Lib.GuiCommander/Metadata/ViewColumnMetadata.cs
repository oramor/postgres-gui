namespace Lib.GuiCommander
{
    public class ViewColumnMetadata
    {
        readonly string _camelName;

        public ViewColumnMetadata(string columnName)
        {
            _camelName = columnName;
        }

        public string CamelName => _camelName;
        public required string PublicName { get; init; }
        public required LogicalDataTypeEnum LogicalDataType { get; init; }
        public required int Priority { get; init; } = 1;
    }
}
