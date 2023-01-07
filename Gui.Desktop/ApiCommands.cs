namespace Gui.Desktop
{
    internal static class ApiCommands
    {
        private static readonly string ApiSchemaName = "api_admin";

        public static string CreateEntity(string publicName, string pascalName, bool isDocument)
        {
            return $"CALL {ApiSchemaName}.create_entity({publicName}, {pascalName}, {isDocument});";
        }

        public static string RemoveEntity(int entityId)
        {
            return $"CALL {ApiSchemaName}.remove_entity({entityId});";
        }
    }
}
