namespace Lib.Providers
{
    public enum ApiCommandType
    {
        Func,
        Proc
    }

    public class ApiCommand
    {
        List<ApiParameter> _params = new();
        string _schemaName = string.Empty;
        string _routineName = string.Empty;

        public ApiCommand(string schemaName, string routineName)
        {
            _schemaName = schemaName;
            _routineName = routineName;
        }

        public IList<ApiParameter> Params { get { return _params; } }

        public void AddParam(string name, object value)
        {
            var param = new ApiParameter(name, value);
            _params.Add(param);
        }

        public void AddParam(ApiParameter param)
        {
            _params.Add(param);
        }

        //public void AddParamOut(string name, ApiParameterType )

        public ApiCommandType CommandType
        {
            get {
                var prefix = _routineName.Substring(0, 2);

                return prefix switch {
                    "fn" => ApiCommandType.Func,
                    "pr" => ApiCommandType.Proc,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        public bool HasOutParam
        {
            get {
                return _params.Exists(v => v.ParamType is ApiParameterType.Out);
            }
        }

        public string CommandString
        {
            get {
                var str = string.Empty;

                // Out-параметры возможны только для процедур?
                if (this.CommandType == ApiCommandType.Proc)
                {
                    str = $"CALL {_schemaName}.{_routineName}(";
                    var outParamStr = string.Empty;
                    var inParamStr = string.Empty;

                    foreach (var param in _params)
                    {
                        /// В текущей реализации может быть только один
                        /// out-параметр
                        if (param.ParamType == ApiParameterType.Out)
                        {
                            outParamStr = "NULL,";
                        }

                        if (param.ParamType == ApiParameterType.In)
                        {
                            inParamStr += $"@{param.ParamName},";
                        }
                    }

                    // Concat and remove last comma
                    str += (outParamStr + inParamStr).TrimEnd(',');
                }

                return str + ");";
            }
        }
    }
}
