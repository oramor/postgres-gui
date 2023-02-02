using System.ComponentModel;

namespace Lib.GuiCommander
{
    public partial class BoolControl : CheckBox, IBaseControl, IJsonControl<bool?>
    {
        bool _isRequired;
        bool _readOnly;
        IRecordContext? _ctx;

        public BoolControl()
        {
            InitializeComponent();
        }

        #region IBindableControl Members

        public bool IsEmpty => false;

        [Bindable(true), Category("Object properties")]
        public bool IsRequired
        {
            get => _isRequired;
            set => _isRequired = value;
        }

        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public string? BindingName { get; set; }

        [Bindable(true), Category("Object properties")]
        public bool IsReadOnly
        {
            get => _readOnly;
            set { _readOnly = value; base.Enabled = !_readOnly; }
        }

        public string CamelName => BindingName == null ? string.Empty : BindingName.LowFirstChar();
        public string PascalName => BindingName == null ? string.Empty : BindingName.UpFirstChar();

        public bool? CurrentValue
        {
            get => Checked;
            set {
                // Do not change state if null value has been recived
                if (value == null || Checked == value)
                    return;

                Checked = value ?? Checked;
            }
        }

        public void Bind(IRecordContext ctx)
        {
            if (CamelName == null)
                return;

            _ctx = ctx;

            if (ctx[CamelName] is bool v)
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

        #endregion

        #region Event Handlers

        public void C_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CamelName && sender is bool v)
            {
                CurrentValue = v;
            }
        }

        private void BoolControl_CheckedChanged(object sender, EventArgs e)
        {
            if (_ctx == null || string.IsNullOrEmpty(CamelName))
                return;

            if (_ctx[CamelName] is bool oldValue && oldValue != Checked)
            {
                _ctx[CamelName] = Checked;
                OnControlValueChanged(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
