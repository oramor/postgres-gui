using Lib.Providers.JsonProvider;

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
        readonly string _paramName = string.Empty;
        readonly object? _paramValue;
        readonly JsonParameter? _json;
        readonly ApiParameterType _paramType;
        readonly ApiParameterDataType _paramDataType;

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
        public ApiParameter(JsonParameter json)
        {
            _paramName = "p_obj";
            _paramType = ApiParameterType.In;
            _json = json;
        }


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

        public object? ParamValue
        {
            get {
                if (_json != null)
                {
                    // This is extenshion method
                    return _json.ToJson();
                }

                return _paramValue;
            }
        }

        public ApiParameterType ParamType => _paramType;

        public ApiParameterDataType ParamDataType
        {
            get {
                /// Для out-параметров тип данных обязательно указывается
                /// в конструкторе. Для in-параметров вычисляется на основании
                /// значения, которое было передано в конструктор
                if (_paramType == ApiParameterType.Out)
                    return _paramDataType;

                if (_json != null)
                    return ApiParameterDataType.Json;

                if (_paramValue is string)
                    return ApiParameterDataType.String;

                if (_paramValue is int)
                    return ApiParameterDataType.Integer;

                if (_paramValue is bool)
                    return ApiParameterDataType.Bool;

                if (_paramValue == null)
                    throw new Exception("NULL is currently not supported");

                throw new Exception("Unknown parameter type for APIParameter");
            }
        }
    }
}
