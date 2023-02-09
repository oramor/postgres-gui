namespace Lib.GuiCommander
{
    /// <summary>
    /// По сути, это шаблон вьюхи, которой должны соответствовать все
    /// экземпляры DataRecord. В других приложениях могут быть более
    /// специализированные вьюхи, например, IEntityDataRecord, которые
    /// будут содержать State, Version и т.д.
    /// </summary>
    public interface IDataRecordView
    {
        int? Id { get; }
    }
}
