using System.ComponentModel;

namespace Lib.GuiCommander.Controls
{
    public partial class IntControl : NumericUpDown, IBaseControl, IJsonControl<int?>
    {
        bool _isRequired;
        bool _isReadOnly;
        EntityObject? _entityObject;

        public IntControl()
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

        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public string? BindingName { get; set; }

        /// <summary>
        /// Если true, то CurrentValue вернет Null при значение 0
        /// </summary>
        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public bool ZeroAsNull { get; set; }

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

        public string? CamelName => BindingName?.LowFirstChar();
        public string? PascalName => BindingName?.UpFirstChar();

        public int? CurrentValue
        {
            get {
                if (ZeroAsNull && Value == 0)
                {
                    return null;
                }
                return Convert.ToInt32(Value);
            }
            set {
                var intValue = Convert.ToInt32(Value);

                if (intValue == value)
                    return;

                Value = value ?? 0;
            }
        }

        public void Bind(EntityObject entityObject)
        {
            this._entityObject = entityObject;

            if (string.IsNullOrEmpty(CamelName))
                return;

            if (_entityObject != null && _entityObject[CamelName] != DBNull.Value)
                Value = Convert.ToDecimal(_entityObject[CamelName]);
        }

        public event ControlValueChangedEventHandler? ControlValueChanged;
        protected void OnControlValueChanged(object sender, EventArgs e)
        {
            ControlValueChanged?.Invoke(sender, e);
        }

        #endregion

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

        #region Events

        private void IntControl_Enter(object sender, EventArgs e)
        {
            this.Select(0, 20);
        }

        private void IntControl_ValueChanged(object sender, EventArgs e)
        {
            ForeColor = Value < 0 ? LibSettings.ControlValueNegativeColor : LibSettings.ControlValuePositiveColor;

            OnControlValueChanged(sender, EventArgs.Empty);
        }

        #endregion
    }
}
