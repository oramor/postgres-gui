using Lib.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.GuiCommander
{
    public static class MetadataRepository
    {
        static Dictionary<string, EntityMetadata> _entityMetadataDic = new();

        #region Loaders

        /// <summary>
        /// Загружает метадаты в статические переменные, которые существуют
        /// на всем протяжении жизненного цикла приложения
        /// </summary>
        /// <param name="db"></param>
        public static void LoadEntityMetadata(IDbProvider db)
        {
            // Get all entities

            // Get db columns for each entity

            // Get table parts for current entity

            // Get db columns for each table part
        }

        #endregion
    }
}
