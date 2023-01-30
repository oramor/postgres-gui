using System.ComponentModel;

namespace Lib.GuiCommander
{
    public partial class BoolControl : CheckBox, IBaseControl, IJsonControl<bool?>, IPropertyChangeSubscriber
    {
        bool _isRequired;
        bool _readOnly;
        EntityObject? _entityObject;

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

        public string? CamelName => BindingName?.LowFirstChar();
        public string? PascalName => BindingName?.UpFirstChar();

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

        public void Bind(EntityObject entityObject)
        {
            this._entityObject = entityObject;

            if (_entityObject != null && !string.IsNullOrEmpty(CamelName))
            {
                this.Checked = _entityObject[CamelName] == DBNull.Value ? false : Convert.ToBoolean(_entityObject[CamelName]);
            }
        }

        public void Bind(object dto)
        {
            if (PascalName == null)
                return;

            var dtoType = dto.GetType();

            foreach (var property in dtoType.GetProperties())
            {
                if (property.Name == PascalName)
                {
                    CurrentValue = (bool?)property.GetValue(dto);
                }
            }
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
            if (_entityObject != null && !string.IsNullOrEmpty(CamelName))
            {
                bool oldValue = _entityObject[CamelName] == DBNull.Value
                    ? false
                    : Convert.ToBoolean(_entityObject[CamelName]);

                _entityObject[CamelName] = Checked;

                if (oldValue != Checked) OnControlValueChanged(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
