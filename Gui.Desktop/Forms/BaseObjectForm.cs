using Gui.Desktop.Dto;
using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using Lib.Providers;
using System.Data;
using System.Reflection;

namespace Gui.Desktop.Forms
{
    public partial class BaseObjectForm : Form
    {
        readonly string _guiName;
        readonly string _token;
        readonly int? _objId;
        IRecordContext? _ctx;
        BaseDto? _dto;

        protected BaseObjectForm()
        {
            InitializeComponent();
        }

        public BaseObjectForm(string guiName, string token, int objId)
        {
            InitializeComponent();
            _guiName = guiName;
            _token = token;
            _objId = objId;
        }

        /// <summary>
        /// Возможно переопределение для более сложной логики инициализации
        /// В этом случае все равно должен быть вызван base.Init()
        /// </summary>
        //protected virtual void Init()
        //{
        //    SetTitle();

        //    if (_ctx != null)
        //    {

        //    }

        //    //BindControls(this);
        //}

        /// <summary>
        /// Если форма вызвана с идентификатором (objId передается в конструктор),
        /// то будет обращение к базе, по результатам которого заполнено Dto.
        /// Иначе ограничимся только созданием объекта с контекстом формы.
        /// </summary>
        protected virtual void Init<T>() where T : BaseDto, new()
        {
            SetTitle();

            _dto = new T();
            //SubscribeControls(this);
            //LoadIntoDto();

            /// Заполняем GuiFormType, который так же является ключем для обращения
            /// к метадате
        }

        /// <summary>
        /// Подписывает контролы на контекст формы. Соответственно, если
        /// контекст не создан, то и подписки не будет
        /// </summary>
        //void SubscribeControls(Control parentControl)
        //{
        //    if (_ctx == null)
        //        return;

        //    foreach (Control c in parentControl.Controls)
        //    {
        //        if (c is IPropertyChangeSubscriber bc)
        //        {
        //            if (bc != null)
        //            {
        //                // Подписываем на контекст
        //                _ctx.PropertyChanged += bc.C_PropertyChanged;
        //            }
        //            /// Здесь предполагаем, что кастомные контролы
        //            /// не могут иметь вложенных
        //        }
        //        else if (c.Controls.Count > 0)
        //        {
        //            SubscribeControls(c);
        //        }
        //    }
        //}

        void LoadContext()
        {
            if (_objId.HasValue)
            {
                var funcName = "fn_get_" + _token + "_item_r";

                var cmd = new ApiCommand("api_admin", funcName);
                cmd.AddParam(new ApiParameter("p_id", _objId));
                var row = App.CallApiCommand<DataRow>(cmd);

                _ctx = new IndexedContext(row);
            }
            else if (_ctx != null) { }
            {

            }
        }

        //void LoadIntoDto()
        //{
        //    if (_objId == null || _ctx == null)
        //        return;

        //    var funcName = "fn_get_" + _token + "_item_r";

        //    var cmd = new ApiCommand("api_admin", funcName);
        //    cmd.AddParam(new ApiParameter("p_id", _objId));
        //    var row = App.CallApiCommand<DataRow>(cmd);

        //    foreach (var prop in _ctx.GetType().GetProperties())
        //    {
        //        // Convert PascalCase to camel
        //        var colName = prop.Name.LowFirstChar();

        //        var isExists = row.Table.Columns.Contains(colName);

        //        if (isExists)
        //        {
        //            /// Каждый контрол, который подписан на контекст,
        //            /// получит оповещение
        //            _ctx.OnPropertyChanged(colName, row[colName]);
        //        }
        //    }
        //}

        /// <summary>
        /// Will bind all controls with current form context
        /// </summary>
        void BindControls(Control parentControl)
        {
            if (_ctx == null)
                return;

            foreach (Control c in parentControl.Controls)
            {
                if (parentControl is IBaseControl bc)
                {
                    bc.Bind(_ctx);
                }
                else if (c.Controls.Count > 0)
                {
                    BindControls(c);
                }
            }
        }

        void SetTitle()
        {
            Text = _objId.HasValue
                ? "Create " + _guiName
                : _guiName + " #" + _objId.ToString();
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
            cmd.AddParam(new ApiParameter("p_entity_id", ApiParameterDataType.Integer));
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
