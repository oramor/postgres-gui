using Lib.GuiCommander;
using System.Reflection;

namespace Gui.Desktop.Forms
{
    public partial class BaseObjectForm : Form
    {
        object _dto;
        string _objName;
        int _objId;

        protected BaseObjectForm()
        {
            InitializeComponent();
        }

        public BaseObjectForm(string objName, int objId)
        {
            InitializeComponent();
            _objName = objName;
            _objId = objId;
        }

        /// <summary>
        /// Возможно переопределение для более сложной логики инициализации
        /// В этом случае все равно должен быть вызван base.Init()
        /// </summary>
        protected virtual void Init()
        {
            SetTitle();
        }

        void SetTitle()
        {
            this.Text = _objId == 0
                ? "Create " + _objName
                : _objName + " # " + _objId.ToString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected object? Grab(Control parentControl, object dto)
        {
            _dto = dto;

            foreach (var control in parentControl.Controls)
            {
                switch (control)
                {
                    case IJsonControl<int?> jc: SetValueToDto<int?>(jc); break;
                    case IJsonControl<int> jc: SetValueToDto<int>(jc); break;
                    case IJsonControl<string> jc: SetValueToDto<string>(jc); break;
                    case IJsonControl<bool> jc: SetValueToDto<bool>(jc); break;
                    default: break;
                }
            }

            return _dto;
        }

        private void SetValueToDto<T>(IJsonControl<T> jc)
        {
            var dtoType = _dto.GetType();
            var jcPascalName = jc.CamelName?.UpFirstChar();

            if (string.IsNullOrEmpty(jcPascalName)) return;

            PropertyInfo? dtoProp = dtoType.GetProperty(jcPascalName);

            if (dtoProp == null) return;

            if (dtoProp.PropertyType == typeof(T))
            {
                dtoProp.SetValue(_dto, jc.CurrentValue);
            }
        }
    }
}
