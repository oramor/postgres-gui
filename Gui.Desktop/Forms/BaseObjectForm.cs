using Gui.Desktop.Dto;
using Lib.GuiCommander;
using Lib.Providers;
using System.ComponentModel;
using System.Data;

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

        protected bool IsModified { get; set; }

        /// <summary>
        /// Если форма вызвана с идентификатором (objId передается в конструктор),
        /// то будет обращение к базе, по результатам которого заполнено Dto.
        /// Иначе ограничимся только созданием объекта с контекстом формы.
        /// </summary>
        protected virtual void Init<T>() where T : BaseDto, new()
        {
            SetTitle();

            _dto = new T();
            LoadContext();
            BindControls(this);

            /// Заполняем GuiFormType, который так же является ключем для обращения
            /// к метадате
            /// 

            _ctx.PropertyChanged += C_PropertyChanged;
        }

        void LoadContext()
        {
            if (_objId.HasValue)
            {
                var funcName = "fn_get_" + _token + "_item_r";

                var cmd = new ApiCommand("api_admin", funcName);
                cmd.AddParam(new ApiParameter("p_id", _objId));
                var row = App.CallApiCommand<DataRow>(cmd);

                _ctx = new RecordContext(row);
            }
            else if (_dto != null)
            {
                _ctx = new RecordContext(_dto);
            }
            else
            {
                throw new Exception("Cannot load form context");
            }
        }

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

        private void FillDto()
        {
            if (_dto == null)
                return;

            foreach (var prop in _dto.GetType().GetProperties())
            {
                var camelName = prop.Name.LowFirstChar();
                prop.SetValue(_dto, _ctx?[camelName]);
            }
        }

        #region Actions

        void CreateObject()
        {
            FillDto();

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

        #region Handlers

        void C_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            IsModified = true;
        }

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
