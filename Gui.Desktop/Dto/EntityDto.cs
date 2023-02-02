using Gui.Desktop.Dto;

namespace Gui.Desktop
{
    public class EntityDto : BaseFormDto
    {
        public int? Id { get; set; }
        public string? PascalName { get; set; }
        public string? PublicName { get; set; }
        public string? PublicCode { get; set; }
        public bool? IsDocument { get; set; } = false; // for save only
        public int? DbTableId { get; set; }
        public int? DbSchemaId { get; set; }
        public int? BizObjectId { get; set; }
    }
}
