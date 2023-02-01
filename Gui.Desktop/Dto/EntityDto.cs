﻿using Gui.Desktop.Dto;

namespace Gui.Desktop
{
    public class EntityDto : BaseDto
    {
        public int Id { get; set; }
        public string? PascalName { get; set; }
        public string? PublicName { get; set; }
        public string? PublicCode { get; set; }
        public bool IsDocument { get; set; }
        public int MdTableId { get; set; }
    }
}
