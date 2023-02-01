using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Lib.GuiCommander.Controls
{
    public partial class StringControl : TextBox, IBaseControl, IJsonControl<string?>
    {
        bool _isRequired;
        bool _readOnly;
        IRecordContext? _ctx;

        public StringControl()
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
                if (_readOnly)
                    BackColor = LibSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? LibSettings.ControlMandatoryColor : LibSettings.ControlBaseColor;
            }
        }

        /// <summary>
        /// Этот параметр заполняется вручную при добавлении контрола на форму
		/// и содержит название колонки во вью (camel_case).
        /// Соответственно, от лежит в Designer-классе. Именно CamelName является
        /// ключем, по которому выполняется привязка к значению. Само значение
        /// берется из <see cref="EntityObject"/> — объекта метадаты, который
		/// содержит все поля сущности и передается в метод <see cref="Init(EntityObject)"/>.
        /// </summary>
        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public string? BindingName { get; set; }

        [Bindable(true), Category("Object properties")]
        public bool IsReadOnly
        {
            get => _readOnly;
            set {
                _readOnly = value;
                base.ReadOnly = value;
                if (_readOnly)
                    BackColor = LibSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? LibSettings.ControlMandatoryColor : LibSettings.ControlBaseColor;
            }
        }

        [Bindable(true), Category("Object properties")]
        public int Length
        {
            get => this.MaxLength;
            set => MaxLength = value;
        }

        [AllowNull]
        public override string Text
        {
            get => base.Text;
            set => CurrentValue = value;
        }

        #endregion

        public bool IsEmpty => string.IsNullOrEmpty(Text);
        public string CamelName => BindingName == null ? string.Empty : BindingName.LowFirstChar();
        public string PascalName => BindingName == null ? string.Empty : BindingName.UpFirstChar();

        public void Bind(IRecordContext ctx)
        {
            if (CamelName == null)
                return;

            _ctx = ctx;

            if (ctx[CamelName] is string v)
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

        public string? CurrentValue
        {
            get => base.Text;
            set {
                if (base.Text == value)
                    return;

                base.Text = value ?? string.Empty;
            }
        }

        #region Event Handlers

        public void C_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CamelName && sender is string v)
            {
                CurrentValue = v;
            }
        }

        private void StringControl_TextChanged(object sender, EventArgs e)
        {
            if (_ctx == null || string.IsNullOrEmpty(CamelName))
                return;

            /// Если этих проверок не будет, форма станет считать себя
            /// измененной после каждой инициализации значениями из БД
            if (_ctx[CamelName] is string oldValue && oldValue != Text)
            {
                _ctx[CamelName] = Text;
                OnControlValueChanged(this, EventArgs.Empty);
            }
        }

        private void StringControl_Enter(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        #endregion
    }
}

