namespace Gui.Desktop
{
    public enum DbTableColumnFormType
    {
        Custom = 1,
        Fk = 2,
        Abstract = 3,
    }

    public class DbTableColumnDto
    {
        public DbTableColumnFormType? FormType { get; set; }
        public int? Id { get; set; }
        public int? DbTableId { get; set; }
        public string? SnakeName { get; set; }
        public string? CamelName { get; set; }
        public string? DefaultGuiName { get; set; }
        public string? DefaultGuiShortName { get; set; }
        public int? DefaultSize { get; set; }
        public int? DefaultPriority { get; set; }
        public int? LogicalDataTypeId { get; set; }
        public int? FkTableColumnId { get; set; }
        public bool? IsRequired { get; set; }
        public string? Description { get; set; }
    }
}

