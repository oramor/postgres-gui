namespace Lib.GuiCommander
{
    /// <summary>
    /// Является объектом, через который можно получить экземпляр домена записей)
    /// по его имени. Так же можно реализовать IRecordDomainFabric,
    /// как класс с indexed properties
    /// </summary>
    public interface IDataProvider
    {
        // GetRecordOwner
        IDataRecord GetRecord(string dataDomainName, int dataRecordId);
        IDataDomain GetRecordDomain(string recordDomainName);
    }
}
