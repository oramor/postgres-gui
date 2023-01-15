using System.ComponentModel;
using static Lib.GuiCommander.IBaseControl;

namespace Lib.GuiCommander
{
    public partial class BoolControl : CheckBox, IBaseControl
    {
        bool _isRequired;
        string _columnName;
        string _jsonName;
        bool _readOnly;
        EntityObject _entityObject;

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
            set { _readOnly = value; base.Enabled = !_readOnly; }
        }

        public int Id
        {
            get { return -1; }
            set { }
        }

        public void Bind(EntityObject entityObject)
        {
            this._entityObject = entityObject;

            if (_entityObject != null && !string.IsNullOrEmpty(_columnName))
            {
                this.Checked = _entityObject[_columnName] == DBNull.Value ? false : Convert.ToBoolean(_entityObject[_columnName]);
            }

            this.CheckedChanged += new EventHandler(BoolControl_CheckedChanged);
        }

        public event ControlChangedEventHandler ControlChanged;
        protected void OnStateChanged(object sender, EventArgs e)
        {
            ControlChanged?.Invoke(sender, e);
        }

        #endregion

        private void BoolControl_CheckedChanged(object sender, EventArgs e)
        {
            if (_entityObject != null && !string.IsNullOrEmpty(_columnName))
            {
                bool oldValue = _entityObject[_columnName] == DBNull.Value
                    ? false
                    : Convert.ToBoolean(_entityObject[_columnName]);

                _entityObject[_columnName] = Checked;

                if (oldValue != Checked) OnStateChanged(this, EventArgs.Empty);
            }
        }
    }
}
