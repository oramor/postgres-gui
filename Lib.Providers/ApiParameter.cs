using System.Text.Json;

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
        Integer,
        Number,
        Bool,
        Json
    }

    public class ApiParameter
    {
        string _paramName = string.Empty;
        object? _paramValue = null;
        ApiParameterType _paramType;
        ApiParameterDataType _paramDataType;

        #region Constructors

        /// <summary>
        /// For in-parameters (parameter data type casts
        /// from paramValue)
        /// </summary>
        public ApiParameter(string paramName, object paramValue)
        {
            _paramName = paramName;
            _paramValue = paramValue;
            _paramType = ApiParameterType.In;
        }

        /// <summary>
        /// For in-parameters which will be converted to json/jsonb
        /// </summary>
        // public ApiParameter(string paramName, ) { }

        /// <summary>
        /// For out-parameters (it is usless to pass value into)
        /// </summary>
        public ApiParameter(string paramName, ApiParameterDataType dataType)
        {
            _paramName = paramName;
            _paramType = ApiParameterType.Out;
            _paramDataType = dataType;
        }

        #endregion

        public string ParamName => _paramName;

        /// <summary>
        /// Для параметров, которые заявлены как Json, производится
        /// сериализация в строку
        /// </summary>
        public object? ParamValue
        {
            get {
                if (ParamDataType == ApiParameterDataType.Json)
                {
                    JsonSerializerOptions opts = new JsonSerializerOptions() {
#if DEBUG
                        // For human readability 
                        WriteIndented = true,
#endif
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    return JsonSerializer.Serialize(_paramValue, opts);
                }

                return _paramValue;
            }
        }

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
                if (_paramValue is int) return ApiParameterDataType.Integer;
                if (_paramValue is bool) return ApiParameterDataType.Bool;

                return ApiParameterDataType.Json;
            }
        }
    }
}
