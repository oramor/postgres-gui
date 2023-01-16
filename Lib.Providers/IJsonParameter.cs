using System.Data;

namespace Lib.Providers
{
    /// <summary>
    /// All the objects that should be convertible to json
    /// parameter should implements this interface
    /// </summary>
    public interface IJsonParameter
    {
        DataRow? DataHeader { get; }
        IDictionary<string, DataTable>? DataTables { get; }
    }
}
