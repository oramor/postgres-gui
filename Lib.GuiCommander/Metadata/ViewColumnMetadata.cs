namespace Lib.GuiCommander
{
    public class ViewColumnMetadata
    {
        readonly string _camelName;

        public ViewColumnMetadata(string columnName)
        {
            _camelName = columnName;
        }

        public string CamelName => _camelName;
        public required string PublicName { get; init; }
        public required LogicalDataTypeEnum LogicalDataType { get; init; }
        public required int Priority { get; init; } = 1;

        /// <summary>
        /// Поскольку названия колонок во всех вьюхах приводится (на стороне БД)
        /// к camelCase, первая буква будет в нижнем регистре
        /// </summary>
        public bool IsPrimaryKey => _camelName == "id";

        /// <summary>
        /// Внешними ключами считаются все колонки, которые оканчиваются на "Id" (именно
        /// с заглавной буквы, чтобы избежать конфилкта с простыми окончаниями!)
        /// </summary>
        public bool IsForeinKey => _camelName.Length > 2
                    ? _camelName[^2..] == "Id"
                    : false;

        public string? ForeinEntityName => IsForeinKey
            ? _camelName.Remove(_camelName.Length - 2) : null;

        /// <summary>
        /// Пиктограммы, в отличии от изображений, должны храниться на уровне
        /// ресурсов проекта и, как следствие, задействуют отдельную логику
        /// построения ячеек
        /// </summary>
        public bool IsIcon => _camelName.Length > 3
            ? _camelName[^4..].ToLower() == "icon"
            : false;

        /// <summary>
        /// Изображения не хранятся в базе. Возвращается токен, по которому
        /// приложение выполняет http-запрос к серверу хранения изображений.
        /// Возможно настроить кеширование.
        /// </summary>
        public bool IsImage => _camelName.Length > 4
            ? _camelName[^5..].ToLower() == "image"
            : false;

        // IsImageUri
    }
}
