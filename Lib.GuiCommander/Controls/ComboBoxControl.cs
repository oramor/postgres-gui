using System.ComponentModel;
using System.Data;
using static Lib.GuiCommander.IBaseControl;

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
        string _columnName = string.Empty;
        string _jsonName = string.Empty;
        string _dataSourceRoutine;
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

        /// <summary>
        /// Этот параметр заполняется вручную при добавлении контрола на форму
		/// и содержит название колонки в базе данных (snake_case).
        /// Соответственно, от лежит в Designer-классе. Именно _columnName является
        /// ключем, по которому выполняется привязка к значению. Само значение
        /// берется из <see cref="EntityObject"/> — объекта метадаты, который
		/// содержит все поля сущности и передается в метод <see cref="Init(EntityObject)"/>.
        /// </summary>
        [Bindable(true), Category("Object properties")]
        public string ColumnName
        {
            get => _columnName;
            set => _columnName = value;
        }

        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public string JsonName
        {
            get => _jsonName;
            set => _jsonName = value;
        }

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
        }

        public event ControlChangedEventHandler ControlChanged;
        protected void OnControlChanged(object sender, EventArgs e)
        {
            ControlChanged?.Invoke(sender, e);
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

        private void GuiObjectComboBoxControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isReadOnly)
                return;

            if (e.KeyData == Keys.Delete)
                SelectedIndex = -1;
        }
    }
}
