namespace Lib.GuiCommander
{
    /// <summary>
    /// Это один из вариантов реализации структуры метаданных (пока под вопросом).
    /// База может предоставить метаданные, по которым будут сконстриированы
    /// объекты <see cref="IDataDomain"/> и помещены во внутреннюю коллецию.
    /// Но смысл интерфейса в том, чтобы отвязаться от реализации. Поэтому классы,
    /// реализующие <see cref="IDataDomain"/> вообще могут буть созданы вручную
    /// в небольших приложениях и вручную же добавлены в провайдер, который,
    /// в свою очередь, будет помещен в DiContainer.
    /// </summary>
    public interface IDataProvider
    {
        // GetRecordOwner
        IDataRecord GetRecord(string dataDomainName, int dataRecordId);
        IDataDomain GetRecordDomain(string recordDomainName);
    }
}
