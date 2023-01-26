using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.Desktop
{
    public abstract class BaseColumnDao
    {
            public int Id { get; set; }
            public string? PascalName { get; set; }
            public string? DefaultGuiName { get; set; }
            public string? DefaultGuiShortName { get; set; }
            public int? DefaultSize { get; set; }
            public int? DefaultPriority { get; set; }
            public int? LogicalDataTypeId { get; set;}
            public bool? IsRequired { get; set; }
            public string? Description { get; set;}
    }
}

