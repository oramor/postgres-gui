namespace Lib.Providers
{
    public enum ApiParameterType
    {
        In,
        Out,
        InOut
    }

    public enum ApiParameterDataType
    {
        String,
        Number,
        Bool
    }

    public class ApiParameter
    {
        string _paramName = string.Empty;
        object? _paramValue = null;
        ApiParameterType _paramType;
        ApiParameterDataType _paramDataType;

        /// <summary>
        /// Constructor for in-parameters (parameter data type casts
        /// from paramValue)
        /// </summary>
        public ApiParameter(string paramName, object paramValue)
        {
            _paramName = paramName;
            _paramValue = paramValue;
            _paramType = ApiParameterType.In;
        }

        /// <summary>
        /// It is usless to pass value into out-parameters
        /// </summary>
        public ApiParameter(string paramName, ApiParameterDataType dataType)
        {
            _paramName = paramName;
            _paramType = ApiParameterType.Out;
            _paramDataType = dataType;
        }

        public string ParamName { get => _paramName; }
        public object? ParamValue { get => _paramValue; }
        public ApiParameterType ParamType { get => _paramType; }

        /// <summary>
        /// Пока поддерживаются только 3 вида входящих параметров.
        /// Для поддержки DTO, скорее всего, нужно будет применить
        /// дженерики: new ApiParameter<DTO.Subject>("p_subject")
        /// </summary>
        public ApiParameterDataType ParamDataType
        {
            get {
                if (_paramValue == null) return _paramDataType;

                if (_paramValue is string) return ApiParameterDataType.String;
                if (_paramValue is int) return ApiParameterDataType.Number;
                if (_paramValue is bool) return ApiParameterDataType.Bool;

                throw new NotSupportedException("Not supported parameter value");
            }
        }
    }
}
