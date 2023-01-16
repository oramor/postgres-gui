using Lib.Providers;
using System.Data;

namespace Lib.GuiCommander
{
    public enum EntityObjectState
    {
        None = 0,       // не записан
        Active = 1,     // активный
        Draft = 2,      // черновик
        Deleted = 4     // помечен как удаленный
    }

    /// <summary>
    /// Этот объект представляет экземпляр бизнес-сущности, полученный из БД.
    /// Он не содержит табличных частей сущности (по этой причине используется
    /// DataRow, а не DataTable и тем более не DataSet, как в предыдущей версии
    /// системы).
    /// 
    /// Объект можно типизировать:
    /// var row = Execute<DataRow>(cmd);
    /// var product = new EntityObject(row).GetType<Product>();
    /// 
    /// При получении Name нужна будет проверки, есть ли связь с DataTable через DataRowState.Detached
    /// https://learn.microsoft.com/en-us/dotnet/api/system.data.datarow.table?view=net-7.0#system-data-datarow-table
    /// </summary>
    public class EntityObject : IJsonParameter
    {
        readonly DataRow _dataRow;
        IDictionary<string, TablePartObject> _tableParts;

        public EntityObject(DataRow dataRow)
        {
            this._dataRow = dataRow;
        }

        #region IJsonParameter members

        public DataRow DataHeader => _dataRow;

        public IDictionary<string, DataTable> DataTables
        {
            get {
                var dic = new Dictionary<string, DataTable>();
                foreach (var t in _tableParts)
                {
                    dic.Add(t.Key, t.Value.TableData);
                }
                return dic;
            }
        }

        #endregion

        public int Id
        {
            get => _dataRow["id"] == DBNull.Value ? 0 : Convert.ToInt32(_dataRow["id"]);
            set => _dataRow["id"] = value;
        }

        public string Name => _dataRow.Table.TableName;

        public EntityObjectState State
        {
            get => _dataRow["state"] == DBNull.Value
                ? EntityObjectState.None
                : (EntityObjectState)Convert.ToInt32(_dataRow["state"]);
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

        //public T GetType<T>()
        //{
        //    var entityType = _dataRow.DataBoundItem as EntityDao;
        //}
    }
}
