namespace Lib.GuiCommander
{
    public enum RoutineTypeEnum
    {
        GetList = 1,        // Список с возможным фильтром, но без пагинации
        GetItem = 2,        // Одна запись по Id
        GetPage = 3,        // Постраничная выдача, так же возможен фильтр
        GetPageCount = 4,   // Кол-во страниц
    }

    public class RoutineMetadata
    {
        public required string DbName;
        public required string Description;
        public required RoutineTypeEnum RoutineType;
    }
}
