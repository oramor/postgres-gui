using Lib.Providers.JsonProvider;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lib.Providers
{
    public static class GlobalMethods
    {
        public static string ToJson(this JsonParameter obj)
        {
            var opts = new JsonSerializerOptions {
                NumberHandling = JsonNumberHandling.Strict,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
#if DEBUG
                // For human readability 
                WriteIndented = true,
#endif
                IncludeFields = false,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Serialize(obj, opts);
        }
    }
}
