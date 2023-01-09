using Lib.Providers;

namespace Gui.Desktop
{
    internal static class ApiAdmin
    {
        static readonly string _schemaName = "api_admin";

        //public static string CreateEntity(string publicName, string pascalName, bool isDocument)
        //{
        //    return $"CALL {_schemaName}.create_entity('{publicName}', '{pascalName}', {isDocument.ToString().ToLower()});";
        //}

        public static ApiCommand CreateEntity(string publicName, string pascalName, bool isDocument)
        {
            var cmd = new ApiCommand(_schemaName, "pr_create_entity_n");
            cmd.AddParam(new ApiParameter("p_entity_id", 0, ApiParameterType.Out));
            cmd.AddParam(new ApiParameter("p_public_name", publicName));
            cmd.AddParam(new ApiParameter("p_pascal_name", pascalName));
            cmd.AddParam(new ApiParameter("p_is_doc", isDocument));

            return cmd;
        }

        public static string RemoveEntity(int entityId)
        {
            return $"CALL {_schemaName}.remove_entity({entityId});";
        }
    }
}
