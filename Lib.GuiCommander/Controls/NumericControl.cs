using System.ComponentModel;
using static Lib.GuiCommander.IBaseControl;

namespace Lib.GuiCommander.Controls
{
    public partial class NumericControl : NumericUpDown, IBaseControl
    {
        bool _isRequired;
        bool _isReadOnly;
        string _columnName = string.Empty;
        string _jsonName = string.Empty;
        EntityObject? _entityObject;

        public NumericControl()
        {
            InitializeComponent();
        }

        #region IBaseControl Members

        /// <summary>
        /// В этом варианте контрола нулевое значение считается пустым
        /// </summary>
        public bool IsEmpty => Value == 0;

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
                base.ReadOnly = value;
                if (_isReadOnly)
                    BackColor = LibSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? LibSettings.ControlMandatoryColor : LibSettings.ControlBaseColor;
            }
        }

        public void Bind(EntityObject entityObject)
        {
            this._entityObject = entityObject;

            if (string.IsNullOrEmpty(_columnName))
                return;

            if (_entityObject != null && _entityObject[_columnName] != DBNull.Value)
                Value = Convert.ToDecimal(_entityObject[_columnName]);
        }

        public event ControlChangedEventHandler ControlChanged;
        protected void OnControlChanged(object sender, EventArgs e)
        {
            ControlChanged?.Invoke(sender, e);
        }

        #endregion

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ForeColor = Value < 0 ? LibSettings.ControlValueNegativeColor : LibSettings.ControlValuePositiveColor;

            if (string.IsNullOrEmpty(_columnName) || _entityObject == null)
                return;

            object prev = _entityObject[_columnName];
            _entityObject[_columnName] = Value;
            if (prev != _entityObject[_columnName])
                OnControlChanged(this, EventArgs.Empty);
        }

        public override void UpButton()
        {
            if (!_isReadOnly)
                base.UpButton();
        }

        public override void DownButton()
        {
            if (!_isReadOnly)
                base.DownButton();
        }

        private void NumericControl_Enter(object sender, EventArgs e)
        {
            this.Select(0, 20);
        }
    }
}
