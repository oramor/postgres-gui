namespace Lib.GuiCommander
{
    /// <summary>
    /// В отличие от <see cref="EntityObject"/>, которые содержат информацию
    /// об инстансе сущности, здесь хранится описание каждой сущности
    /// </summary>
    public class EntityMetadata
    {
        readonly string _entityName;
        readonly bool _isDocument;
        readonly int _entityId;
        /// <summary>
        /// Сущность может содержат несколько табличных частей. У документов обычно одна.
        /// У справочников может быть несколько. Например, Goods может иметь табличные
        /// части для связки с фотографиями, а так же для хранения оценок товара (если
        /// такая оценка не является самостоятельной сущностью)
        /// </summary>
        readonly Dictionary<string, TablePartMetadata> _tableParts = new();
        readonly Dictionary<ViewTypeEnum, ViewMetadata> _viewsDic = new();
        readonly Dictionary<string, ColumnMetadata> _columnsDic = new();
        readonly List<ColumnMetadata> _columns = new();

        public EntityMetadata(string entityName, int entityId, bool isDocument)
        {
            _entityName = entityName;
            _isDocument = isDocument;
            _entityId = entityId;
        }

        public string EntityName => _entityName;
        public bool IsDocument => _isDocument;
        public int EntityId => _entityId;
        public IList<ColumnMetadata> Columns => _columns;

        //public void ShowCreateForm()
        //{
        //    MessageBox.Show("Will be shown");
        //}

        //public void ShowForm(int id)
        //{
        //    MessageBox.Show("Will be shown for id " + id);
        //}

        public void AddTablePart(TablePartMetadata tablePart)
        {
            _tableParts.Add(tablePart.Name, tablePart);
        }

        public void AddColumn(ColumnMetadata column)
        {
            if (_columnsDic.TryAdd(column.CamelName, column))
            {
                _columns.Add(column);
            }
        }

        public void AddView(ViewMetadata view)
        {
            _viewsDic.TryAdd(view.ViewType, view);
        }

        public ColumnMetadata? GetColumnByName(string name)
        {
            return _columns.Find(v => v.CamelName == name);
        }
    }
}
