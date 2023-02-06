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

    public partial class ComboBoxControl : ComboBox, IBaseControl //IAsyncControl
    {
        bool _isRequired;
        bool _isReadOnly;
        bool _isInvalid;
        bool _isImmutable;
        int _invalidValueCache = 0;
        string? _dataSourceRoutine;

        public ComboBoxControl()
        {
            InitializeComponent();

            /// Каким бы ни был способ связывания (перегрузка метода Bind)
            /// в DataSource контрола должен быть передан объект IList<IComboBoxListItem>
            ValueMember = "Id";
            DisplayMember = "Title";
        }

        #region Bindable Properties

        [Bindable(true), Category("Object properties")]
        public bool IsRequired
        {
            get => _isRequired;
            set {
                _isRequired = value;
                BackColor = GetBackgroundColor();
            }
        }

        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public string? BindingName { get; set; }

        [Bindable(true), Category("Object properties")]
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set {
                _isReadOnly = value;
                Enabled = !_isReadOnly;
                BackColor = GetBackgroundColor();
            }
        }

        [Bindable(true), Category("Object properties")]
        public string? DataSourceRoutine
        {
            get => _dataSourceRoutine;
            set => _dataSourceRoutine = value;
        }

        #endregion

        public bool IsEmpty => SelectedIndex == -1;
        public string CamelName => BindingName == null ? string.Empty : BindingName.LowFirstChar();
        public string PascalName => BindingName == null ? string.Empty : BindingName.UpFirstChar();

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
                    return;
                }

                SelectedIndex = -1;
            }
        }

        public void Bind(IRecordFormContext ctx)
        {
            if (CamelName == null)
                return;

            if (ctx[CamelName] is int v)
            {
                CurrentValue = v;
            }

            ControlValueChanged += ctx.ControlValueChangedEventHandler;
            ctx.ContextPropertyChanged += C_ContextPropertyChanged;
            ctx.PropertyInvalidated += C_PropertyInvalidated;
        }

        Color GetBackgroundColor()
        {
            if (_isReadOnly)
            {
                return LibSettings.ControlReadOnlyColor;
            }
            else if (_isInvalid)
            {
                return LibSettings.ControlInvalidColor;
            }
            else if (_isRequired)
            {
                return LibSettings.ControlRequiredColor;
            }
            else
            {
                return LibSettings.ControlBaseColor;
            }
        }

        public void SetDataSource(IDictionary<int, string> dic)
        {
            var list = dic.Select(v => new ComboBoxListItem { Id = v.Key, Title = v.Value }).ToList();

            DataSource = list;
        }

        /// <summary>
        /// Для случаев, когда запрос к базе выполняется за пределами контрола
        /// (например, если приложение не работает с метадатой)
        /// </summary>
        public void SetDataSource(DataTable dt)
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
        protected void OnControlValueChanged(IBaseControl sender, ControlValueChangedEventArgs e)
        {
            ControlValueChanged?.Invoke(sender, e);
        }

        #region Event Handlers

        void C_PropertyInvalidated(object? sender, PropertyInvalidatedEventArgs e)
        {
            if (e.PropertyName == PascalName)
            {
                _isInvalid = true;
                _isImmutable = e.IsImmutable;
                _invalidValueCache = SelectedIndex;
                BackColor = GetBackgroundColor();
            }
        }

        public void C_ContextPropertyChanged(IObservableContext sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null && sender[CamelName] is int v)
            {
                CurrentValue = v;
            }
        }

        private void C_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnControlValueChanged(this, new ControlValueChangedEventArgs(CurrentValue));

            if (_isInvalid)
            {
                _isInvalid = false;
                BackColor = GetBackgroundColor();
            }
            else if (_isImmutable && SelectedIndex == _invalidValueCache)
            {
                _isInvalid = true;
                BackColor = GetBackgroundColor();
            }
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
