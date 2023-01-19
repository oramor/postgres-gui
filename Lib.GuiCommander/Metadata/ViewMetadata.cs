namespace Lib.GuiCommander
{
    /// <summary>
    /// На стороне базы для каждой сущности, табличной части или отчета
    /// генерируется вью, а так же функция, которая обрабатывает к ней
    /// запрос (с возможным наложением фильтров). Тип вью позволяет получить
    /// нужную метадату для построения формы или контрола. Например,
    /// EntityIdNameView используется в комбо-боксах, а EntityJointView
    /// в типовых списках
    /// </summary>
    public enum ViewTypeEnum
    {
        EntityObjectView = 1,       // именно по ней определяются колонки для сохранения
        EntitySelectView = 2,       // обычно id + publicName. Для простых комбо-боксов
        EntityImgSelectView = 3,    // только для сущностей, у которых есть иконка/превью
        EntitySubGridView = 4,      // для списков подстановки в EntitySubGridControl
        EntityGridView = 5,         // самый подробный список для EntityGridControl
        TablePartObjectView = 6,    // так же для сохранения
        TablePartGridView = 7,      // для EntityGridControl
        TablePartEditableView = 8,  // для EntityEditableGridControl
        ReportView = 9,             // любая кастомная вьюха
    }

    public class ViewMetadata
    {
        readonly Dictionary<string, ColumnMetadata> _columns = new();
        readonly Dictionary<RoutineTypeEnum, RoutineMetadata> _routines = new();

        public required string Name { get; init; }
        public required int Id { get; init; }
        public required ViewTypeEnum ViewType { get; init; }


        public void AddColumn(ColumnMetadata column)
        {
            /// Когда функция возвращает DataTable, именно CamelName
            /// является ключем для определения PublicName
            _columns.Add(column.CamelName, column);
        }

        public void SetRoutine(RoutineMetadata routine)
        {
            _routines.TryAdd(routine.RoutineType, routine);
        }

        public RoutineMetadata? GetRoutineByType(RoutineTypeEnum routineType)
        {
            _routines.TryGetValue(routineType, out var result);
            return result;
        }

        public IList<ColumnMetadata> Columns => new List<ColumnMetadata>(_columns.Values);
    }
}
