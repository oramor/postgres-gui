using Lib.GuiCommander.Controls;
using System.ComponentModel;

namespace Lib.GuiCommander
{
    public partial class BoolControl : CheckBox, IBaseControl
    {
        bool _isRequired;
        bool _isReadOnly;

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
            get => _isReadOnly;
            set { _isReadOnly = value; base.Enabled = !_isReadOnly; }
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

        public void Bind(IRecordFormContext ctx)
        {
            if (CamelName == null)
                return;

            /// Устанавливаем дефолтное значение из контекста, или передаем
            /// в контекст начальное значение контрола
            if (ctx[CamelName] is bool v)
            {
                CurrentValue = v;
            }
            else
            {
                ctx[CamelName] = CurrentValue;
            }

            ControlValueChanged += ctx.ControlValueChangedEventHandler;
            ctx.ContextPropertyChanged += C_ContextPropertyChanged;
            ctx.PropertyInvalidated += C_PropertyInvalidated;
        }

        public event ControlValueChangedEventHandler? ControlValueChanged;
        protected void OnControlValueChanged(IBaseControl sender, ControlValueChangedEventArgs e)
        {
            ControlValueChanged?.Invoke(sender, e);
        }

        #endregion

        #region Event Handlers

        void C_PropertyInvalidated(object? sender, PropertyInvalidatedEventArgs e)
        {
        }

        public void C_ContextPropertyChanged(IObservableContext sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null && sender[CamelName] is bool v)
            {
                CurrentValue = v;
            }
        }

        private void BoolControl_CheckedChanged(object sender, EventArgs e)
        {
            OnControlValueChanged(this, new ControlValueChangedEventArgs(CurrentValue));
        }

        #endregion
    }
}
