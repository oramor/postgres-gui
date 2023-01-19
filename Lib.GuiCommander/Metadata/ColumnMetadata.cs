namespace Lib.GuiCommander
{
    /// <summary>
    /// В отличии от БД, здесь нет смысла разделять колонки вьюх и таблиц
    /// </summary>
    public class ColumnMetadata
    {
        public required string CamelName { get; init; }
        public required string PublicName { get; init; }
        public required LogicalDataTypeEnum LogicalDataType { get; init; }
        public required int Priority { get; init; } = 1;
        public required int DefaultSize { get; init; }
        public required bool IsRequired { get; init; }
        public string Description { get; init; } = string.Empty;
    }
}
