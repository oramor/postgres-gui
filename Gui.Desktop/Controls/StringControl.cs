using Gui.Desktop.Metadata;
using System.ComponentModel;

namespace Gui.Desktop.Controls
{
    public partial class StringControl : TextBox, IBindableControl
    {
        bool _isRequired;
        string _columnName;
        string _jsonName;
        bool _readOnly;
        BizObject _bizObject;

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
                    BackColor = AppSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? AppSettings.ControlMandatoryColor : AppSettings.ControlBaseColor;
            }
        }

        /// <summary>
        /// Этот параметр заполняется вручную при добавлении контрола на форму
		/// и содержит название колонки в базе данных (snake_case).
        /// Соответственно, от лежит в Designer-классе. Именно _columnName является
        /// ключем, по которому выполняется привязка к значению. Само значение
        /// берется из <see cref="BizObject"/> — объекта метадаты, который
		/// содержит все поля сущности и передается в метод <see cref="Init(BizObject)"/>.
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
                    BackColor = AppSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? AppSettings.ControlMandatoryColor : AppSettings.ControlBaseColor;
            }
        }

        public void Bind(BizObject _bizObject)
        {
            this._bizObject = _bizObject;

            if (string.IsNullOrEmpty(_columnName))
                return;

            if (_bizObject != null && _bizObject[_columnName] != DBNull.Value)
                base.Text = _bizObject[_columnName].ToString();
        }

        public event ControlChangedEventHandler ControlChanged;
        protected void OnControlChanged(object sender, EventArgs e)
        {
            if (ControlChanged != null) ControlChanged(sender, e);
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
                if (_bizObject != null || !string.IsNullOrEmpty(_columnName))
                {
                    _bizObject[_columnName] = value;
                    OnControlChanged(this, EventArgs.Empty);
                }
            }
        }

        #endregion

        #region Events

        private void StringControl_TextChanged(object sender, EventArgs e)
        {
            if (_bizObject != null || !string.IsNullOrEmpty(_columnName))
            {
                if (_bizObject[_columnName].ToString() != Text)
                {
                    _bizObject[_columnName] = Text;
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
