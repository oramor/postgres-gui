using Gui.Desktop.Dto;
using Lib.Providers;
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

        #region Entity

        public static ApiCommand CreateEntity(EntityDto dao)
        {
            var cmd = new ApiCommand(_schemaName, "pr_create_entity_n");
            cmd.AddParam(new ApiParameter("p_entity_id", ApiParameterDataType.Integer));
            cmd.AddParam(new ApiParameter("p_obj", dao));
            return cmd;
        }

        public static ApiCommand GetEntityList()
        {
            return new ApiCommand(_schemaName, "fn_get_entity_list_t");
        }

        public static ApiCommand GetEntityShortList()
        {
            return new ApiCommand(_schemaName, "fn_get_entity_sl_t");
        }

        #endregion

        #region LogicalDataType

        public static ApiCommand GetLogicalDataTypeShortList()
        {
            return new ApiCommand(_schemaName, "fn_get_logical_data_type_sl_t");
        }

        #endregion

        public static ApiCommand GetDbTableList()
        {
            return new ApiCommand(_schemaName, "fn_get_db_table_sl_t");
        }

    }
}
