using Gui.Desktop.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui.Desktop.Controls
{
    public partial class BoolControl : CheckBox, IBindableControl
    {
        bool _isRequired;
        string _columnName;
        string _jsonName;
        bool _readOnly;
        BizObject _bizObject;

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

        public void Bind(BizObject bizObject)
        {
            this._bizObject = bizObject;

            if (_bizObject != null && !string.IsNullOrEmpty(_columnName))
            {
                this.Checked = _bizObject[_columnName] == DBNull.Value ? false : Convert.ToBoolean(_bizObject[_columnName]);
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
            if (_bizObject != null && !string.IsNullOrEmpty(_columnName))
            {
                bool oldValue = _bizObject[_columnName] == DBNull.Value
                    ? false
                    : Convert.ToBoolean(_bizObject[_columnName]);
                
                _bizObject[_columnName] = Checked;
                
                if (oldValue != Checked) OnStateChanged(this, EventArgs.Empty);
            }
        }
    }
}
