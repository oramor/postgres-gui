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
        PrimaryKey = 6,     // Колонка является идентфикатором сущности
        ForeinKey = 7,      // Внешний ключ на другую сущность
        ParentKey = 8,      // Рекурсивно ссылкается на себя
        Image = 9,          // Токен изображения, по которому выполняется обращение к серверу api
        Icon = 10,           // Колонка хранит имя пиктограммы в ресурсах сборки
        Preview = 11,       // Изображение (обычно очень мелкое), которое хранится в базе
        PublicName = 12,    // Имя объекта (например, Москва для city)
        Description = 13,   // Дополнительная информация об объекте
        Code = 14,          // Текстовый идентификатор товара (например, артикул)
        Status = 15,        // Идентификатор статуса (не путать со state сущности)
        StatusName = 16,    // Имя статуса
        StatusIcon = 17,    // При наличии этого поля StatusName будет выводиться в подсказке
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
