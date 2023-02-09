
namespace Gui.Desktop.Dto
{
    public class DbTableColumnDto : BaseFormDto
    {
        public int? DbTableId { get; set; }
        public string? SnakeName { get; set; }
        public string? CamelName { get; set; }
        public string? DefaultGuiName { get; set; }
        public string? DefaultGuiShortName { get; set; }
        public int? DefaultSize { get; set; }
        public int? DefaultPriority { get; set; }
        public int? LogicalDataTypeId { get; set; }
        public int? FkTableColumnId { get; set; }

        // Because default for nullable types is null
        public bool? IsRequired { get; set; }
        public string? Description { get; set; }
    }
}

