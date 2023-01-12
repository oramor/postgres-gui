using Lib.Providers;

namespace Gui.Desktop
{
    internal static class ApiAdmin
    {
        static readonly string _schemaName = "api_admin";

        public static ApiCommand CreateEntity(EntityDto dao)
        {
            var cmd = new ApiCommand(_schemaName, "pr_create_entity_n");
            cmd.AddParam(new ApiParameter("p_entity_id", ApiParameterDataType.Number));
            cmd.AddParam(new ApiParameter("p_public_name", dao.PublicName!));
            cmd.AddParam(new ApiParameter("p_pascal_name", dao.PascalName!));
            cmd.AddParam(new ApiParameter("p_is_doc", dao.IsDocument));

            return cmd;
        }

        public static ApiCommand RemoveEntity(int entityId)
        {
            var cmd = new ApiCommand(_schemaName, "pr_remove_entity_");
            cmd.AddParam(new ApiParameter("p_public_name", entityId));

            return cmd;
        }

        public static ApiCommand GetEntityList()
        {
            return new ApiCommand(_schemaName, "fn_get_entity_list_t");
        }
    }
}
