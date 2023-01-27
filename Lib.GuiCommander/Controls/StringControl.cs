using System.ComponentModel;
using static Lib.GuiCommander.IBaseControl;

namespace Lib.GuiCommander.Controls
{
    public partial class StringControl : TextBox, IBaseControl, IJsonControl<string?>
    {
        bool _isRequired;
        string _camelName;
        bool _readOnly;
        EntityObject _entityObject;

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
        /// Соответственно, от лежит в Designer-классе. Именно _camelName является
        /// ключем, по которому выполняется привязка к значению. Само значение
        /// берется из <see cref="EntityObject"/> — объекта метадаты, который
		/// содержит все поля сущности и передается в метод <see cref="Init(EntityObject)"/>.
        /// </summary>
        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public string CamelName
        {
            get => _camelName;
            set => _camelName = value;
        }

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

        public void Bind(EntityObject _entityObject)
        {
            this._entityObject = _entityObject;

            if (string.IsNullOrEmpty(_camelName))
                return;

            if (_entityObject != null && _entityObject[_camelName] != DBNull.Value)
                base.Text = _entityObject[_camelName].ToString();
        }

        public event ControlChangedEventHandler ControlChanged;
        protected void OnControlChanged(object sender, EventArgs e)
        {
            ControlChanged?.Invoke(sender, e);
        }

        #endregion

        #region Properties

        [Bindable(true), Category("Object properties")]
        public int Length
        {
            get => this.MaxLength;
            set => MaxLength = value;
        }

        public override string Text
        {
            get => base.Text;
            set {
                base.Text = value;
                if (_entityObject != null || !string.IsNullOrEmpty(_camelName))
                {
                    _entityObject![_camelName] = value;
                    OnControlChanged(this, EventArgs.Empty);
                }
            }
        }

        public string? CurrentValue => Text;

        #endregion

        #region Events

        private void StringControl_TextChanged(object sender, EventArgs e)
        {
            if (_entityObject != null && !string.IsNullOrEmpty(_camelName))
            {
                if (_entityObject![_camelName].ToString() != Text)
                {
                    _entityObject[_camelName] = Text;
                    OnControlChanged(this, EventArgs.Empty);
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

