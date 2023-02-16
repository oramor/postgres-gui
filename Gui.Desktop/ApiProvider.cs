using Lib.Providers;
using Lib.Providers.JsonProvider;
using System.Data;

namespace Gui.Desktop
{
    /// <summary>
    /// Провайдер инкапсулирует в себе логику именования рутин для доступа
    /// к объектам. В данном приложении _schemaName статична и провайдер удобнее
    /// сделать статичным. В более сложном приложении инстанс провайдера может
    /// помещаться в каждый объект метаданных или DataDomain
    /// </summary>
    internal static class ApiProvider
    {
        static readonly string _schemaName = "api_admin";

        public static DataRow GetDataRecordRow(string token, int id)
        {
            var funcName = "fn_get_" + token + "_item_r";
            var cmd = new ApiCommand(_schemaName, funcName);
            cmd.AddParam(new ApiParameter("p_id", id));
            return App.DbProvider.Query<DataRow>(cmd);
        }

        public static DataTable GetList(string token)
        {
            var funcName = "fn_get_" + token + "_list_t";
            var cmd = new ApiCommand(_schemaName, funcName);
            var dt = App.DbProvider.Query<DataTable>(cmd);
            return dt;
        }

        public static T TryQuery<T>(ApiCommand cmd)
        {
            T result = App.DbProvider.Query<T>(cmd);
            return result;
        }

        public static DataTable GetShortList(string token)
        {
            var funcName = "fn_get_" + token + "_sl_t";
            var cmd = new ApiCommand(_schemaName, funcName);
            return App.DbProvider.Query<DataTable>(cmd);
        }

        public static int Create(string token, JsonParameter json)
        {
            var procName = "pr_" + token + "_create_n";
            var cmd = new ApiCommand(_schemaName, procName);
            cmd.AddParam(new ApiParameter("p_id", ApiParameterDataType.Integer));
            cmd.AddParam(new ApiParameter(json));
            return App.DbProvider.Query<int>(cmd);
        }

        public static int Update(string token, JsonParameter json)
        {
            var procName = "pr_" + token + "_update_n";
            var cmd = new ApiCommand(_schemaName, procName);
            cmd.AddParam(new ApiParameter("p_ver", ApiParameterDataType.Integer));
            cmd.AddParam(new ApiParameter(json));
            return App.DbProvider.Query<int>(cmd);
        }

        public static void Delete(string token, int id)
        {
            var procName = "pr_" + token + "_remove_";
            var cmd = new ApiCommand(_schemaName, procName);
            cmd.AddParam(new ApiParameter("p_id", id));
            App.DbProvider.Execute(cmd);
        }
    }
}
