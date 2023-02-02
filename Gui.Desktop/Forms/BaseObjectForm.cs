using Gui.Desktop.Dto;
using Lib.GuiCommander;
using Lib.Providers;
using System.ComponentModel;
using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class BaseObjectForm : Form
    {
        readonly string? _dataDomainName;
        readonly string? _token;
        readonly int? _dataRecordId;
        IDataContext? _ctx;
        BaseFormDto? _dto;

        protected BaseObjectForm()
        {
            InitializeComponent();
        }

        public BaseObjectForm(string dataDomainName, string token, int? dataRecordId)
        {
            InitializeComponent();
            _dataDomainName = dataDomainName;
            _dataRecordId = dataRecordId;
            _token = token;
        }

        /// <summary>
        /// При любом изменении контекста формы (кроме его инициализации),
        /// форма будет считаться модифицированной
        /// </summary>
        protected bool IsModified { get; set; }

        /// <summary>
        /// Если форма вызвана с идентификатором (dataRecordId передается в конструктор),
        /// то будет обращение к базе, по результатам которого заполнено Dto.
        /// Иначе ограничимся только созданием объекта с контекстом формы.
        /// </summary>
        protected virtual void Init<T>() where T : BaseFormDto, new()
        {
            SetTitle();

            _dto = new T();
            _ctx = MakeContext();
            BindControls(this);

            /// Заполняем GuiFormType, который так же является ключем для обращения
            /// к метадате
            /// 

            _ctx.PropertyChanged += C_PropertyChanged;
        }

        IDataContext MakeContext()
        {
            if (_dataRecordId.HasValue)
            {
                var funcName = "fn_get_" + _token + "_item_r";

                var cmd = new ApiCommand("api_admin", funcName);
                cmd.AddParam(new ApiParameter("p_id", _dataRecordId));
                var row = App.CallApiCommand<DataRow>(cmd);

                return new RecordContext(row);
            }
            else if (_dto != null)
            {
                return new RecordContext(_dto);
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
                if (c is IBaseControl bc)
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
            Text = _dataRecordId.HasValue
                ? "Create " + _dataDomainName
                : _dataDomainName + " #" + _dataRecordId.ToString();
        }

        /// <summary>
        /// Переносит в DTO данные из текущего состояния контекста.
        /// </summary>
        void FillDto()
        {
            if (_dto == null || _ctx == null)
                return;

            foreach (var prop in _dto.GetType().GetProperties())
            {
                var camelName = prop.Name.LowFirstChar();
                var ctxValue = _ctx[camelName] == DBNull.Value ? null : _ctx[camelName];
                prop.SetValue(_dto, ctxValue);
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

            App.Logger.GuiReport($"Created {_dataDomainName} with id {result}");

            Close();
        }

        void SaveObject()
        {
            if (_dataRecordId == null || _dataRecordId == 0)
                return;

            var procName = "pr_" + _token + "_update_";
        }

        void RemoveObject()
        {
            if (_dataRecordId == null || _dataRecordId == 0)
                return;

            var procName = "pr_" + _token + "_remove_";

            var cmd = new ApiCommand("api_admin", procName);
            cmd.AddParam(new ApiParameter("p_id", _dataRecordId));
            var result = App.CallApiCommand<int>(cmd);

            App.Logger.GuiReport($"{_dataDomainName} with id {result} REMOVED");

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
            if (_dataRecordId.HasValue)
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
