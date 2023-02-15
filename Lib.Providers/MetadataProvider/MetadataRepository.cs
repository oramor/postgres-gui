using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Providers.MetadataProvider
{
    public enum MetadataLoadingState
    {
        NotLoaded, OnLoading, Loaded, OnCancelling
    }

    public static class MetadataRepository
    {
        /// <summary>
        /// Используется для хранения raw-data по метаданных в виде связанных таблиц,
        /// по сути локальная копия реляционной структуры. Если эта структура
        /// пустая, пользователь получит оповещение о первичной загрузке метаданных,
        /// иначе об обновлении.
        /// </summary>
        static DataSet? _metadata;

        public static void Init(IMetadataLoader loader)
        {
            bool isInitial = _metadata == null;
            loader.LoadCancelling += Loader_LoadCancelling;
            loader.LoadingStartReport(isInitial);

        }

        static void Loader_LoadCancelling(object? sender, EventArgs e)
        {

        }
    }
}
