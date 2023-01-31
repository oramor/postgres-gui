using System.ComponentModel;

namespace Lib.GuiCommander.Controls
{
    public partial class IntControl : NumericUpDown, IBaseControl, IJsonControl<int?>
    {
        bool _isRequired;
        bool _isReadOnly;
        IIndexedContext _ctx;

        public IntControl()
        {
            InitializeComponent();
        }

        #region Bindable properties

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

        #endregion

        public bool IsEmpty
        {
            get {
                if (ZeroAsNull)
                {
                    return Value == 0;
                }

                return false;
            }
        }

        public string CamelName => BindingName == null ? string.Empty : BindingName.LowFirstChar();
        public string PascalName => BindingName == null ? string.Empty : BindingName.UpFirstChar();

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

        public void Bind(IIndexedContext ctx)
        {
            if (CamelName == null)
                return;

            _ctx = ctx;

            if (ctx[CamelName] is int v)
            {
                CurrentValue = v;
            }

            ctx.PropertyChanged += C_PropertyChanged;
        }

        public event ControlValueChangedEventHandler? ControlValueChanged;
        protected void OnControlValueChanged(object sender, EventArgs e)
        {
            ControlValueChanged?.Invoke(sender, e);
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

        #region Event Handlers

        public void C_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CamelName && sender is int v)
            {
                CurrentValue = v;
            }
        }

        private void IntControl_Enter(object sender, EventArgs e)
        {
            this.Select(0, 20);
        }

        private void IntControl_ValueChanged(object sender, EventArgs e)
        {
            ForeColor = Value < 0 ? LibSettings.ControlValueNegativeColor : LibSettings.ControlValuePositiveColor;

            if (_ctx == null || string.IsNullOrEmpty(CamelName))
                return;

            /// Если этих проверок не будет, форма станет считать себя
            /// измененной после каждой инициализации значениями из БД
            if (_ctx[CamelName] is int oldValue && oldValue != Value)
            {
                _ctx[CamelName] = Value;
                OnControlValueChanged(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
