namespace Lib.GuiCommander
{
    /// <summary>
    /// Любые контролы, которые реализуют данный интерфейс, могут возвращать
    /// nulluble-типы, что означает: текущее значение не задано (например,
    /// не выбран селект).
    /// </summary>
    public interface IJsonControl<T>
    {
        string CamelName { get; set; }
        T CurrentValue { get; }
    }
}
