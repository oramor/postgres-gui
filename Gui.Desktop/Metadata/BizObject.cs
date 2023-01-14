using System.Data;

namespace Gui.Desktop.Metadata
{
    public enum BizObjectState
    {
        None = 0,       // не записан
        Active = 1,     // активный
        Draft = 2,      // черновик
        Deleted = 4     // помечен как удаленный
    }

    /// <summary>
    /// Это объект представляет бизнес-сущность (переименовать в EntityObject), но не содержит
    /// ее табличных частей (по этой причине используется DataTable, а не DataSet).
    /// По идее, можно ограничиться DataRow
    /// 
    /// Более того, объект можно типизировать:
    /// var row = Execute<DataRow>(cmd);
    /// var product = new EntityObject(row).GetType<Product>();
    /// 
    /// При получении Name нужна будет проверки, есть ли связь с DataTable через DataRowState.Detached
    /// https://learn.microsoft.com/en-us/dotnet/api/system.data.datarow.table?view=net-7.0#system-data-datarow-table
    /// </summary>
    public class BizObject
    {
        DataTable _data;
        DataRow _dataRow;

        public BizObject(DataTable _data)
        {
            this._data = _data;
            this._dataRow = _data.Rows[0];
        }

        public DataTable Data => _data;

        public int Id
        {
            get => _dataRow["id"] == DBNull.Value ? 0 : Convert.ToInt32(_dataRow["id"]);
            set => _dataRow["id"] = value;
        }

        public string Name => _data.TableName;

        public BizObjectState State
        {
            get => _dataRow["state"] == DBNull.Value
                ? BizObjectState.None
                : (BizObjectState)Convert.ToInt32(_dataRow["state"]);
            set => _dataRow["state"] = (int)value;
        }

        public int Version
        {
            get => _dataRow["ver"] == DBNull.Value ? 0 : Convert.ToInt32(_dataRow["ver"]);
            set => _dataRow["ver"] = value;
        }

        public object this[string columnName]
        {
            get => _dataRow[columnName];
            set => _dataRow[columnName] = value;
        }
    }
}
