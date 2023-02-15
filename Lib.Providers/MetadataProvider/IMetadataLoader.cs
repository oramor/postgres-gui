using System.Data;

namespace Lib.Providers.MetadataProvider
{
    /// <summary>
    /// На стороне приложения должен быть реализован интерфейс, который инкапсулирует
    /// логику получения метаданных с сервера. В одних приложениях данные могут
    /// запрашиваться через прямое подключение к базе, в других — через проксирующий
    /// API-шлюз. Данный объект передается в метод Init() <see cref="MetadataRepository"/>
    /// для конструирования объекта DataSet, из которого затем получаются данные.
    /// </summary>
    public interface IMetadataLoader
    {
        DataTable GetDbSchemas();
        DataTable GetDbTables();
        DataTable GetDbTableColumns();
        DataTable GetDbRoutines();
        DataTable GetGuiViews();
        DataTable GetGuiViewsColumns();
        DataTable GetEntities();
        DataTable GetPermissions();
        DataTable GetLocals();
        /// <summary>
        /// Оповещает GUI-клиента о начале процесса загрузки метаданных.
        /// Пользователю может быть выведен прогресс-бар.
        /// </summary>
        /// <param name="isInitial">true, если это первичная загрузка метаданных
        /// что влияет на заголовок окна лоудера.
        /// </param>
        void LoadingStartReport(bool isInitial);
        /// <summary>
        /// Через указанный метод GUI-клиент оповещается о прогрессе загрузки
        /// (или обновления) метаданных
        /// </summary>
        void LoadingProgressReport(string message, int persent);
        void LoadingSucceedReport();
        /// <summary>
        /// Оповещает клиента, что процесс был успешно остановлен.
        /// </summary>
        void LoadingCanceledReport();
        /// <summary>
        /// Оповещает клиента о неожиданном завершении процесса (параметром можно
        /// передавать код завершения (например, проблема с сетью).
        /// </summary>
        void LoadingFailedReport();
        /// <summary>
        /// GUI-клиент может отменить загрузку метаданных, что приведет к удалению
        /// DataSet (или сбросу его кеша?)
        /// </summary>
        event EventHandler<EventArgs> LoadCancelling;
    }
}
