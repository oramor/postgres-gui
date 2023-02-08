namespace Lib.GuiCommander
{
    /// <summary>
    /// Под доменом понимается любая сущность, экземпляр которой имеет идентификатор.
    /// При этом не важно, что является источником данных для записей этого домена:
    /// БД, локальный файл или текущее состояние приложения. Если говорить в терминах
    /// реляционной модели, то DataDomain — это таблица.
    /// </summary>
    public interface IDataDomain
    {
        /// <summary>
        /// Любая сущность обязана иметь имя, которое одновременно является
        /// ее идентификатром. Имя неизменно (поэтому init).
        /// </summary>
        string DomainName { get; init; }
        /// <summary>
        /// Возвращает объект по его идентификатору
        /// </summary>
        object? GetOne(int id);
        /// <summary>
        /// Возвращает коллекцию объектов
        /// </summary>
        ICollection<IDataRecord> GetList(object? filter);
        /// <summary>
        /// Возвращает идентификатор созданного экземпляря сущности
        /// </summary>
        int Create();
        /// <summary>
        /// Возвращает версию после обновления
        /// </summary>
        int Update();
        void Delete();
    }
}
