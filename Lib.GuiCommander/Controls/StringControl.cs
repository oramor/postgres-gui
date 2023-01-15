using System.ComponentModel;
using static Lib.GuiCommander.IBaseControl;

namespace Lib.GuiCommander.Controls
{
    public partial class StringControl : TextBox, IBaseControl
    {
        bool _isRequired;
        string _columnName;
        string _jsonName;
        bool _readOnly;
        EntityObject _entityObject;

        public StringControl()
        {
            InitializeComponent();
        }

        #region IBindableControl Members

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

            if (string.IsNullOrEmpty(_columnName))
                return;

            if (_entityObject != null && _entityObject[_columnName] != DBNull.Value)
                base.Text = _entityObject[_columnName].ToString();
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
                if (_entityObject != null || !string.IsNullOrEmpty(_columnName))
                {
                    _entityObject[_columnName] = value;
                    OnControlChanged(this, EventArgs.Empty);
                }
            }
        }

        #endregion

        #region Events

        private void StringControl_TextChanged(object sender, EventArgs e)
        {
            if (_entityObject != null || !string.IsNullOrEmpty(_columnName))
            {
                if (_entityObject[_columnName].ToString() != Text)
                {
                    _entityObject[_columnName] = Text;
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

