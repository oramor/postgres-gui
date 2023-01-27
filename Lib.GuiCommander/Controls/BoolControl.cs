using System.ComponentModel;
using static Lib.GuiCommander.IBaseControl;

namespace Lib.GuiCommander
{
    public partial class BoolControl : CheckBox, IBaseControl, IJsonControl<bool>
    {
        bool _isRequired;
        string _camelName;
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
            set { _readOnly = value; base.Enabled = !_readOnly; }
        }

        public int Id
        {
            get { return -1; }
            set { }
        }

        public bool CurrentValue => Checked;

        public void Bind(EntityObject entityObject)
        {
            this._entityObject = entityObject;

            if (_entityObject != null && !string.IsNullOrEmpty(_camelName))
            {
                this.Checked = _entityObject[_camelName] == DBNull.Value ? false : Convert.ToBoolean(_entityObject[_camelName]);
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
            if (_entityObject != null && !string.IsNullOrEmpty(_camelName))
            {
                bool oldValue = _entityObject[_camelName] == DBNull.Value
                    ? false
                    : Convert.ToBoolean(_entityObject[_camelName]);

                _entityObject[_camelName] = Checked;

                if (oldValue != Checked) OnStateChanged(this, EventArgs.Empty);
            }
        }
    }
}
