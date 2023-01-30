using Lib.GuiCommander;
using Lib.Providers;
using System.Reflection;

namespace Gui.Desktop.Forms
{
    public partial class BaseObjectForm : Form
    {
        readonly object _dto;
        readonly string _guiName;
        readonly string _token;
        readonly int? _objId;

        protected BaseObjectForm()
        {
            InitializeComponent();
        }

        public BaseObjectForm(object dto, string guiName, string token, int objId)
        {
            InitializeComponent();
            _dto = dto;
            _guiName = guiName;
            _token = token;
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

        void BindControls(Control parentControl)
        {
            if (_dto == null)
                return;

            foreach (Control c in parentControl.Controls)
            {
                if (parentControl is IBaseControl bc)
                {
                    /// Если контрол был определен как соответствующий интерфейсу
                    /// <see cref="IBaseControl"/> он может получить все базовые настройки
                    /// из объекта метадаты
                    bc.Bind(_dto);

                    if (!string.IsNullOrWhiteSpace(bc.BindingName) && columns.ContainsKey(bc.ColumnName))
                    {
                        MetadataElement columnElement = columns[bc.ColumnName];
                        columnElement.JsonName = bc.JsonName;
                        bc.IsMandatory = columnElement.NotNull;
                        c.Visible = columnElement.Actions.HasFlag(MetadataPermissions.Select);

                        if (ObjectId == 0)
                            bc.IsReadOnly = !columnElement.Actions.HasFlag(MetadataPermissions.Insert);
                        else
                            bc.IsReadOnly = !(canUpdate && columnElement.Actions.HasFlag(MetadataPermissions.Update));
                    }

                    bc.StateChanged += new ControlStateChangedEventHandler(ControlStateChanged);
                }
                else if (jc != null)
                {
                    if (!string.IsNullOrWhiteSpace(jc.JsonName) && tables.ContainsKey(jc.JsonName))
                    {
                        MetadataElement tableElement = tables[jc.JsonName];
                        tableElement.JsonName = jc.JsonName;
                        tableElement.Control = jc;
                    }
                }
                else if (c.Controls.Count > 0)
                {
                    BindControls(c);
                }
            }
        }

        void SetTitle()
        {
            this.Text = _objId == 0
                ? "Create " + _guiName
                : _guiName + " # " + _objId.ToString();
        }

        void Grab(Control parentControl)
        {
            foreach (var control in parentControl.Controls)
            {
                switch (control)
                {
                    case IJsonControl<int?> jc: AddValueToDto<int?>(jc); break;
                    case IJsonControl<int> jc: AddValueToDto<int>(jc); break;
                    case IJsonControl<string> jc: AddValueToDto<string>(jc); break;
                    case IJsonControl<bool> jc: AddValueToDto<bool>(jc); break;
                    default: break;
                }
            }
        }

        void AddValueToDto<T>(IJsonControl<T> jc)
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

        #region Actions

        void CreateObject()
        {
            Grab(this);

            var procName = "pr_" + _token + "_create_n";

            var cmd = new ApiCommand("api_admin", procName);
            cmd.AddParam(new ApiParameter("p_entity_id", ApiParameterDataType.Number));
            cmd.AddParam(new ApiParameter("p_obj", _dto));
            var result = App.CallApiCommand<int>(cmd);

            App.Logger.GuiReport($"Created {_guiName} with id {result}");

            Close();
        }

        void SaveObject()
        {
            if (_objId == null || _objId == 0)
                return;

            var procName = "pr_" + _token + "_update_";
        }

        void RemoveObject()
        {
            if (_objId == null || _objId == 0)
                return;

            var procName = "pr_" + _token + "_remove_";

            var cmd = new ApiCommand("api_admin", procName);
            cmd.AddParam(new ApiParameter("p_id", _objId));
            var result = App.CallApiCommand<int>(cmd);

            App.Logger.GuiReport($"{_guiName} with id {result} REMOVED");

            Close();
        }

        #endregion

        #region Events

        void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void saveButton_Click(object sender, EventArgs e)
        {
            if (_objId.HasValue)
            {
                SaveObject();
            }
            else
            {
                CreateObject();
            }
        }

        #endregion
    }
}
