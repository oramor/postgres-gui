namespace Lib.GuiCommander
{
    /// <summary>
    /// Является объектом, через который можно получить запись (экземпляр
    /// домена записей) по ключу. Так же можно реализовать IRecordDomainFabric,
    /// как класс с indexed properties
    /// </summary>
    public interface IRecordProvider
    {
        IRecordDomain GetRecordDomain(string recordDomainName);
    }
}
