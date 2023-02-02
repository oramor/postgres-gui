namespace Lib.GuiCommander
{
    /// <summary>
    /// Является объектом, через который можно получить экземпляр домена записей)
    /// по его имени. Так же можно реализовать IRecordDomainFabric,
    /// как класс с indexed properties
    /// </summary>
    public interface IRecordProvider
    {
        // GetRecordOwner
        IRecord GetRecord(string recordDomainName, int recordId);
        IRecordDomain GetRecordDomain(string recordDomainName);
    }
}
