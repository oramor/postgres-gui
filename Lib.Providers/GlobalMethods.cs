using Lib.Providers.JsonProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lib.Providers
{
    public static class GlobalMethods
    {
        public static void ToJson(this JsonParameter obj) {
            var opts = new JsonSerializerOptions {
                NumberHandling = JsonNumberHandling.Strict,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false,
                IncludeFields = false,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }
    }
}
