namespace Gui.Desktop
{
    public abstract class BaseViewColumnDao
    {
        public int? Id { get; set; }
        public string? CamelName { get; set; }
        public string? DefaultGuiName { get; set; }
        public string? DefaultGuiShortName { get; set; }
        public int? DefaultSize { get; set; }
        public int? DefaultPriority { get; set; }
        public int? LogicalDataTypeId { get; set; }
        public bool? IsRequired { get; set; }
        public string? Description { get; set; }
    }
}

