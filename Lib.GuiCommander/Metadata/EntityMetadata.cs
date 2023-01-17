namespace Lib.GuiCommander
{
    /// <summary>
    /// В отличие от <see cref="EntityObject"/>, которые содержат информацию
    /// об инстансе сущности, здесь хранится описание каждой сущности
    /// </summary>
    public class EntityMetadata
    {
        readonly string _entityName;
        readonly int _entityId;
        readonly bool _isDocument;
        /// <summary>
        /// Сущность может содержат несколько табличных частей. У документов обычно одна.
        /// У справочников может быть несколько. Например, Goods может иметь табличные
        /// части для связки с фотографиями, а так же для хранения оценок товара (если
        /// такая оценка не является самостоятельной сущностью)
        /// </summary>
        readonly Dictionary<string, TablePartMetadata> _tableParts = new();

        public EntityMetadata(string entityName, int entityId, bool isDocument)
        {
            _entityName = entityName;
            _entityId = entityId;
            _isDocument = isDocument;
        }

        public string EntityName => _entityName;

        public int Id => _entityId;

        public bool IsDocument => _isDocument;

        public void ShowCreateForm()
        {
            MessageBox.Show("Will be shown");
        }

        public void ShowForm(int id)
        {
            MessageBox.Show("Will be shown for id " + id);
        }

        public void AddTablePart(TablePartMetadata tablePart)
        {
            _tableParts.Add(tablePart.Name, tablePart);
        }
    }
}
