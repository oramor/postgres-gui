using System.Data;

namespace Lib.GuiCommander
{
    /// <summary>
    /// This object represents a table part of entity
    /// </summary>
    public class TablePartObject
    {
        readonly string _tableName;
        readonly DataTable _tableData;

        public TablePartObject(string tableName, DataTable tableData)
        {
            _tableName = tableName;
            _tableData = tableData;
        }

        public string TableName => _tableName;
        public DataTable TableData => _tableData;
    }
}
