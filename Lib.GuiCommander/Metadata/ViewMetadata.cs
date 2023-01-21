namespace Lib.GuiCommander
{
    /// <summary>
    /// На стороне базы для каждой сущности, табличной части или перечисления генерируются
    /// вью. Причем JointView и ShortView создаются только для сущностей и табличных
    /// частей (кроме того, их колонки могут быть настроены).
    /// 
    /// Разные виды контролов требуют определенных вью. Например, EntityComboBox запросит
    /// в метаданных сущность и попытается вызвать рутину, которая указана для вьюхи
    /// с категорией IdNameView.
    /// 
    /// DataView нужна для того, чтобы инициализировать формы сущностей (поэтому она
    /// не создается для объектов, по которым формы не предусмотрены). Например,
    /// при загрузке EntityForm, из метаданных будет получено описание сущности и найдена
    /// вьюха с типом DataView, по которой получено название рутины get_data_item().
    /// Из полученного объекта будет создан EntityObject и передан в экземпляр каждого
    /// контрола на форме, который поддерживает биндинг.
    /// 
    /// В свою очередь, контол, получив объект, попытается найти в нем значение по ключу,
    /// который соответствует ColumnName из <see cref="IBindableComponent"/>. Если найдет,
    /// то вызовет инициализацию этим значением (к примеру, в ComboBox будет подставлена
    /// строка с нужным id).
    /// </summary>
    public enum ViewTypeEnum
    {
        ReportView = 0,     // Все кастомные вью, которые не связаны с таблицей
        DataView = 1,       // Техническая, которая содержит все колонки таблицы, но без джойнов
        JointView = 2,      // Создается для Entity и TablePart. Используется в отчетах
        ShortView = 3,      // Например, для списков подстановки. Обычно не содержит джойнов
        IdNameView = 4,     // Если у сущности есть колонка id (для простых ComboBox)
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
