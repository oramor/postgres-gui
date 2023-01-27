using System.ComponentModel;
using static Lib.GuiCommander.IBaseControl;

namespace Lib.GuiCommander.Controls
{
    public partial class IntControl : NumericUpDown, IBaseControl, IJsonControl<int?>
    {
        bool _isRequired;
        bool _isReadOnly;
        string _camelName = string.Empty;
        EntityObject? _entityObject;

        public IntControl()
        {
            InitializeComponent();
        }

        #region IBaseControl Members

        /// <summary>
        /// В этом варианте контрола нулевое значение считается пустым
        /// </summary>
        public bool IsEmpty => Value == 0;

        [Bindable(true), Category("Object properties")]
        public bool IsRequired
        {
            get => _isRequired;
            set {
                _isRequired = value;
                if (_isReadOnly)
                    BackColor = LibSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? LibSettings.ControlMandatoryColor : LibSettings.ControlBaseColor;
            }
        }

        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public string CamelName
        {
            get => _camelName;
            set => _camelName = value;
        }

        /// <summary>
        /// Если true, то CurrentValue вернет Null при значение 0
        /// </summary>
        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public bool ZeroAsNull { get; set; }

        [Bindable(true), Category("Object properties")]
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set {
                _isReadOnly = value;
                base.ReadOnly = value;
                if (_isReadOnly)
                    BackColor = LibSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? LibSettings.ControlMandatoryColor : LibSettings.ControlBaseColor;
            }
        }

        public int? CurrentValue
        {
            get {
                if (ZeroAsNull && Value == 0)
                {
                    return null;
                }
                return Convert.ToInt32(Value);
            }
        }

        public void Bind(EntityObject entityObject)
        {
            this._entityObject = entityObject;

            if (string.IsNullOrEmpty(_camelName))
                return;

            if (_entityObject != null && _entityObject[_camelName] != DBNull.Value)
                Value = Convert.ToDecimal(_entityObject[_camelName]);
        }

        public event ControlChangedEventHandler ControlChanged;
        protected void OnControlChanged(object sender, EventArgs e)
        {
            ControlChanged?.Invoke(sender, e);
        }

        #endregion

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ForeColor = Value < 0 ? LibSettings.ControlValueNegativeColor : LibSettings.ControlValuePositiveColor;

            if (string.IsNullOrEmpty(_camelName) || _entityObject == null)
                return;

            object prev = _entityObject[_camelName];
            _entityObject[_camelName] = Value;
            if (prev != _entityObject[_camelName])
                OnControlChanged(this, EventArgs.Empty);
        }

        public override void UpButton()
        {
            if (!_isReadOnly)
                base.UpButton();
        }

        public override void DownButton()
        {
            if (!_isReadOnly)
                base.DownButton();
        }

        private void IntControl_Enter(object sender, EventArgs e)
        {
            this.Select(0, 20);
        }
    }
}
