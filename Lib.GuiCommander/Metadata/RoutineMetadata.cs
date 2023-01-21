namespace Lib.GuiCommander
{
    public enum RoutineTypeEnum
    {
        GetList = 1,        // Список с возможным фильтром, но без пагинации
        GetItem = 2,        // Одна запись по Id
        GetPage = 3,        // Постраничная выдача, так же возможен фильтр
        GetPageCount = 4,   // Кол-во страниц
        //Create = 5,
        //Update = 6,
        //Delete = 7,
        //Commit = 8,
    }

    public class RoutineMetadata
    {
        public required string DbName;
        public required string Description;
        public required RoutineTypeEnum RoutineType;
    }
}
