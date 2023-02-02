using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.GuiCommander
{
    /// <summary>
    /// Любая DTO для сущности обязана иметь идентификатор
    /// </summary>
    public interface IDataRecordDto
    {
        int? Id { get; set; }
    }
}
