using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.GuiCommander
{
    /// <summary>
    /// На стороне базы для каждой сущности, табличной части или отчета
    /// генерируется вью, а так же функция, которая обрабатывает к ней
    /// запрос (с возможным наложением фильтров). Тип вью позволяет получить
    /// нужную метадату для построения формы или контрола. Например,
    /// EntityIdNameView используется в комбо-боксах, а EntityJointView
    /// в типовых списках
    /// </summary>
    public enum ViewTypeEnum
    {
        EntityIdNameView = 1,       // обычно id + publicName
        EntityIdNameDescrView = 2,  // id + publicName + description для списков подстановки
        EntityTableView = 3,        // вся таблица сущности без джойнов по id
        EntityJointView = 4,        // самый подробный список
        TablePartTableView = 5,     // таблица табличной части
        TablePartJointView = 6,     // таблица сущности с джойнами
        ReportView = 7,             // любая кастомная вьюха
    }

    public class ViewMetadata
    {
        readonly string _name;
        readonly int _id;
        readonly ViewTypeEnum _viewType;
        Dictionary<string, ViewColumnMetadata> _columns = new();

        public ViewMetadata(string name, int id, ViewTypeEnum viewType) {
            _name = name;
            _id = id;
            _viewType = viewType;
        }

        public string Name => _name;
        public int Id => _id;
        public ViewTypeEnum ViewType => _viewType;

        public void AddColumn(ViewColumnMetadata column)
        {
            /// Когда функция возвращает DataTable, именно CamelName
            /// является ключем для определения PublicName
            _columns.Add(column.CamelName, column);
        }
    }
}
