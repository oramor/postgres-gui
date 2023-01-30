using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Lib.GuiCommander.Controls
{
    public partial class StringControl : TextBox, IBaseControl, IJsonControl<string?>, IPropertyChangeSubscriber
    {
        bool _isRequired;
        bool _readOnly;
        EntityObject? _entityObject;

        public StringControl()
        {
            InitializeComponent();
        }

        #region IBaseControl Members

        public bool IsEmpty => string.IsNullOrEmpty(Text);

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

        public string? CamelName => BindingName?.LowFirstChar();
        public string? PascalName => BindingName?.UpFirstChar();

        public void Bind(EntityObject _entityObject)
        {
            this._entityObject = _entityObject;

            if (string.IsNullOrEmpty(CamelName))
                return;

            if (_entityObject != null && _entityObject[CamelName] != DBNull.Value)
                base.Text = _entityObject[CamelName].ToString();
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
                    CurrentValue = (string?)property.GetValue(dto);
                }
            }
        }

        public event ControlValueChangedEventHandler? ControlValueChanged;
        protected void OnControlValueChanged(object sender, EventArgs e)
        {
            ControlValueChanged?.Invoke(sender, e);
        }

        #endregion

        #region Properties

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

        public string? CurrentValue
        {
            get => base.Text;
            set {
                if (base.Text == value)
                    return;

                base.Text = value ?? string.Empty;
            }
        }

        #endregion

        #region Events

        private void StringControl_TextChanged(object sender, EventArgs e)
        {
            /// Если этих проверок не будет, форма станет считать себя
            /// измененной после каждой инициализации значениями из БД
            if (_entityObject != null && !string.IsNullOrEmpty(CamelName))
            {
                if (_entityObject[CamelName]?.ToString() != Text)
                {
                    _entityObject[CamelName] = Text;
                    OnControlValueChanged(this, EventArgs.Empty);
                }
            }
        }

        private void StringControl_Enter(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        #endregion
    }
}

