using System.ComponentModel;
using System.Data;


namespace Lib.GuiCommander.Controls
{
    public interface IComboBoxListItem
    {
        int Id { get; init; }
        string Title { get; init; }
    }

    public readonly struct ComboBoxListItem : IComboBoxListItem
    {
        public int Id { get; init; }
        public string Title { get; init; }
    }

    public partial class ComboBoxControl : ComboBox, IBaseControl, IJsonControl<int?> //IAsyncControl
    {
        bool _isRequired;
        bool _isReadOnly;
        string? _dataSourceRoutine;
        EntityObject? _entityObject;

        public ComboBoxControl()
        {
            InitializeComponent();

            /// Каким бы ни был способ связывания (перегрузка метода Bind)
            /// в DataSource контрола должен быть передан объект IList<IComboBoxListItem>
            ValueMember = "Id";
            DisplayMember = "Title";
        }

        #region IBaseControl Members

        public bool IsEmpty => SelectedIndex == -1;

        #region Bindable Properties

        [Bindable(true), Category("Object properties")]
        public bool IsRequired
        {
            get => _isRequired;
            set {
                _isRequired = value;
                if (_isReadOnly)
                    BackColor = LibSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? LibSettings.ControlMandatoryColor : LibSettings.ControlBaseColor;
            }
        }

        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public string BindingName { get; set; }

        [Bindable(true), Category("Object properties")]
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set {
                _isReadOnly = value;
                Enabled = !_isReadOnly;
                if (_isReadOnly)
                    BackColor = LibSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? LibSettings.ControlMandatoryColor : LibSettings.ControlBaseColor;
            }
        }

        #endregion

        public string? CamelName => BindingName?.LowFirstChar();
        public string? PascalName => BindingName?.UpFirstChar();

        public int? CurrentValue
        {
            get {
                if (IsEmpty)
                    return null;

                if (SelectedValue is int v)
                    return v;

                return null;
            }

            set {
                if (value == null)
                {
                    SelectedIndex = -1;
                    return;
                }

                /// Источником данных для данного контрола является объект DataTable.
                /// Соответственно, все Bind должны приводиться к его установлению.
                if (DataSource is not DataTable dt)
                    return;

                /// Значением комбо-бокса является идентификатор сущности/объекта.
                /// Проверяем, есть ли данный идентификатор в источнике данных.
                /// Когда контрол будет асинхронным, будем ожидать завершения
                /// его инициализации.
                var isExists = dt?.AsEnumerable().Select(row =>
                    row.Field<int>("id") == value).Count() > 0;

                if (isExists)
                {
                    SelectedValue = value;
                    // TODO OnControlValueChanged();
                    return;
                }

                SelectedIndex = -1;
            }
        }

        public void Bind(EntityObject entityObject)
        {
            this._entityObject = entityObject;

            // Пока что этот метод не выполняет действий
        }

        public void Bind(IDictionary<int, string> dic)
        {
            var list = dic.Select(v => new ComboBoxListItem { Id = v.Key, Title = v.Value }).ToList();

            DataSource = list;
        }

        /// <summary>
        /// Для случаев, когда запрос к базе выполняется за пределами контрола
        /// (например, если приложение не работает с метадатой)
        /// </summary>
        public void Bind(DataTable dt)
        {
            // Tables without id does not sense
            if (!dt.Columns.Contains("id"))
                return;

            ValueMember = "id";

            DisplayMember = string.Empty;

            var arr = new[] { "title", "public_name", "doc_name" };

            foreach (var str in arr)
            {
                if (dt.Columns.Contains(str))
                {
                    DisplayMember = str;
                    break;
                }
            }

            if (string.IsNullOrEmpty(DisplayMember))
            {
                var colName = arr[0];

                DisplayMember = colName;
                DataColumn column = new() {
                    DataType = typeof(string),
                    ColumnName = colName,
                    DefaultValue = "<Not data found>"
                };

                dt.Columns.Add(column);
                IsReadOnly = true;
            }

            DataSource = dt;
            CurrentValue = null;
        }

        public event ControlValueChangedEventHandler? ControlValueChanged;
        protected void OnControlValueChanged(object sender, EventArgs e)
        {
            ControlValueChanged?.Invoke(sender, e);
        }

        #endregion

        [Bindable(true), Category("Object properties")]
        public string DataSourceRoutine
        {
            get => _dataSourceRoutine;
            set => _dataSourceRoutine = value;
        }

        /// <summary>
        /// Этот метод инициализирует контрол в зависимости от того, какая
        /// перегрузка метода Bind() была вызвана. Кроме того, возможен BindAsync()
        /// и, соответственно, InitAsync()
        /// </summary>
        //private void Init()
        //{
        //    if (!string.IsNullOrEmpty(DataSourceRoutine)) { 

        //    }
        //}

        #region Events

        private void C_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void C_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isReadOnly)
                return;

            if (e.KeyData == Keys.Delete)
                CurrentValue = null;
        }

        #endregion
    }
}
