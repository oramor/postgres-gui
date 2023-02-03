namespace Lib.Providers.JsonProvider
{
    /// <summary>
    /// Объект словаря может быть передан в сторонний сериализатор "как есть",
    /// либо может быть вызван метод расширения ToJson из <see cref="GlobalMethods"/>
    /// </summary>. Резон в том, чтобы оставить объект легковесным, не создавая
    /// инстанс JsonSerializerOptions внутри каждого JsonParameter
    public class JsonParameter : Dictionary<string, object>
    {
        public new void Add(string key, object? value)
        {
            if (value != null && value != DBNull.Value)
            {
                base.Add(key, value);
            }
        }
    }
}
