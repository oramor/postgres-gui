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
        EntityIdNameView = 1,       // обычно id + publicName
        EntityIdNameDescrView = 2,  // id + publicName + description для списков подстановки
        EntityTableView = 3,        // вся таблица сущности без джойнов по id
        EntityJointView = 4,        // самый подробный список
        TablePartTableView = 5,     // таблица табличной части
        TablePartJointView = 6,     // таблица сущности с джойнами
        ReportView = 7,             // любая кастомная вьюха
    }

    public class ViewMetadata
    {
        readonly Dictionary<string, ViewColumnMetadata> _columns = new();

        public required string Name { get; init; }
        public required int Id { get; init; }
        public required ViewTypeEnum ViewType { get; init; }

        public void AddColumn(ViewColumnMetadata column)
        {
            /// Когда функция возвращает DataTable, именно CamelName
            /// является ключем для определения PublicName
            _columns.Add(column.CamelName, column);
        }
    }
}
