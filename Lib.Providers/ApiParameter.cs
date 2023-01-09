namespace Lib.Providers
{
    public enum ApiParameterType
    {
        In,
        Out,
        InOut
    }

    public class ApiParameter
    {
        string _paramName = string.Empty;
        object? _paramValue = null;
        ApiParameterType _paramType;

        public ApiParameter(string paramName, object paramValue, ApiParameterType paramType = ApiParameterType.In)
        {
            _paramName = paramName;
            _paramValue = paramValue;
            _paramType = paramType;
        }

        public string ParamName { get => _paramName; }
        public object? ParamValue { get => _paramValue; }
        public ApiParameterType ParamType { get => _paramType; }
    }
}
