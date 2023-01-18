namespace Lib.GuiCommander
{
    public enum LogicalDataTypeEnum
    {
        Nope = 0,           // Аналог Null. Если не удалось привести ни к какому типу
        AnyString = 1,      // Любая текстовая строка небольшой длины
        AnyText = 2,        // Строка произвльной длины (например, описание товара)
        AnyNubmer = 3,      // Любое целое число
        AnyBool = 4,        // Булево значение
        AnyDate = 5,        // Произвольная Дата
        AnyJson = 6,
        AnyUuid = 7,
        PrimaryKey = 8,     // Колонка является идентфикатором сущности
        ForeignKey = 9,      // Колонка ссылается на другую сущность
        ParentKey = 10,     // Колонка рекурсивно ссылкается на ту же сущность
        Image = 11,         // Токен изображения, по которому выполняется обращение к серверу api
        Icon = 12,          // Колонка хранит имя пиктограммы в ресурсах сборки
        Preview = 13,       // Изображение (обычно очень мелкое), которое хранится в базе
        PublicName = 14,    // Имя объекта (например, Москва для city)
        Description = 15,   // Дополнительная информация об объекте
        Code = 16,          // Текстовый идентификатор товара (например, артикул)
        Status = 17,        // Идентификатор статуса (не путать со state сущности)
        StatusName = 18,    // Имя статуса
        StatusIcon = 19,    // При наличии этого поля StatusName будет выводиться в подсказке
        EntityState = 20,   // Служебный тип, который указывает на статус сущности
        // Quantity, Measurment, Cost, CurSymbol, CurMultiplicity
    }

    public static class LogicalDataType
    {
        /// <summary>
        /// Базопасный метод извлечения типа в рантайме
        /// </summary>
        public static LogicalDataTypeEnum GetTypeById(int id)
        {
            try
            {
                return (LogicalDataTypeEnum)id;
            } catch
            {
                return LogicalDataTypeEnum.Nope;
            }
        }
    }
}
