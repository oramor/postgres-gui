namespace Lib.Providers
{
    public enum ApiCommandType
    {
        Func,
        Proc
    }

    public enum ApiCommandResultType
    {
        Void,
        Cell,
        Row,
        Table
    }

    public class ApiCommand
    {
        List<ApiParameter> _params = new();
        string _schemaName = string.Empty;
        string _routineName = string.Empty;

        #region Constructors

        public ApiCommand(string schemaName, string routineName)
        {
            _schemaName = schemaName;
            _routineName = routineName;
        }

        public ApiCommand(string pathName)
        {
            _schemaName = pathName[.._routineName.IndexOf('.')];
            _routineName = pathName[(_routineName.IndexOf('.') + 1)..];
        }

        #endregion

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

        private string RoutinePostfix
        {
            get {
                if (_routineName == null)
                {
                    throw new Exception("Routine name doesn't filled");
                }
                return _routineName[^1..];
            }
        }

        public ApiCommandResultType ResultType
        {
            get {
                return RoutinePostfix switch {
                    "_" => ApiCommandResultType.Void,
                    "t" => ApiCommandResultType.Table,
                    "r" => ApiCommandResultType.Row,
                    "n" => ApiCommandResultType.Cell,
                    "s" => ApiCommandResultType.Cell,
                    "b" => ApiCommandResultType.Cell,
                    _ => throw new NotSupportedException($"Routine name contains unknown postfix: _{RoutinePostfix}")
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
                var str = this.CommandType == ApiCommandType.Proc
                    ? $"CALL {_schemaName}.{_routineName}("
                    : $"SELECT * FROM {_schemaName}.{_routineName}(";

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

                return str + ");";
            }
        }
    }
}
