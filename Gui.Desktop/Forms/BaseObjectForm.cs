using Lib.GuiCommander;
using System.Reflection;

namespace Gui.Desktop.Forms
{
    public partial class BaseObjectForm : Form
    {
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
            foreach (var control in parentControl.Controls)
            {
                var jc = control as IJsonControl<int?>;
                if (jc != null && dto != null)
                {
                    var dtoType = dto.GetType();
                    var propName = UpFirst(jc!.CamelName);
                    PropertyInfo? dtoProp = dtoType.GetProperty(propName!);

                    var controlPropType = jc.GetType()?.GetProperty("CurrentValue")?.PropertyType;
                    var dtoPropType = dtoProp?.PropertyType;

                    if (controlPropType == dtoPropType)
                    {
                        MessageBox.Show("Ok");
                    }

                    dtoProp?.SetValue(dto, jc.CurrentValue);
                }
            }

            return dto;
        }

        static string? UpFirst(string str)
        {
            if (str == null) return null;

            if (str.Length == 0)
            {
                return string.Empty;
            }

            return char.ToUpper(str[0]) + str[1..];
        }
    }
}
