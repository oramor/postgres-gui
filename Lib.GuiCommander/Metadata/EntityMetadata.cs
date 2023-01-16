using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.GuiCommander
{
    public class TablePartMetadata
    {
        readonly string _tablePartName;

        public TablePartMetadata(string tablePartName) { 
            _tablePartName = tablePartName;
        }

        public string Name => _tablePartName;
    }

    public class EntityColumnMetadata
    {
        readonly string _columnName;
        readonly string _publicName;

        public EntityColumnMetadata(string columnName, string publicName) { 
            _columnName = columnName;
            _publicName = publicName;
        }

        public string ColumnName => _columnName;
        public string PublicName => _publicName;
    }

    /// <summary>
    /// В отличие от <see cref="EntityObject"/>, которые содержат информацию
    /// об инстансе сущности, здесь хранится описание каждой сущности
    /// </summary>
    public class EntityMetadata
    {
        readonly string _entityName;
        readonly int _entityId;
        Dictionary<string, EntityColumnMetadata> _columns = new();
        Dictionary<string, TablePartMetadata> _tableParts = new();

        public EntityMetadata(string entityName, int entityId) {
            _entityName = entityName;
            _entityId = entityId;
        }

        public string EntityName => _entityName;
        public int EntityId => _entityId;

        public void AddColumn(EntityColumnMetadata column)
        {
            _columns.Add(column.ColumnName, column);
        }

        public void AddTablePart(TablePartMetadata tablePart)
        {
            _tableParts.Add(tablePart.Name, tablePart);
        }
    }
}
