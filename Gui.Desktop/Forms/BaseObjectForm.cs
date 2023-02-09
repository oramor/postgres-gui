using Gui.Desktop.Dto;
using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using Lib.Providers;
using Lib.Providers.JsonProvider;
using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class BaseObjectForm : Form // BaseRecordForm
    {
        bool _isModified;
        protected bool _keyDownHandled;
        readonly string? _dataDomainName;
        readonly string? _token;
        readonly Dictionary<string, IBaseControl> _baseControls = new();
        ParentTabControl? _parentTabControl;

        /// <summary>
        /// Идентификатор объекта, с которым форма могла быть загружена. Если
        /// не определен, форма считается открытой в режиме создания новой записи.
        /// При создании записи будет создан контекст и Id созданной сущности
        /// будет помещен уже в _ctx.Id, поэтому _initRecordId создан
        /// с модификатором readonly
        /// </summary>
        readonly int? _initRecordId;
        IDataRecordContext? _ctx;
        BaseFormDto? _dto;

        #region Constructrs

        protected BaseObjectForm()
        {
            InitializeComponent();
        }

        public BaseObjectForm(string dataDomainName, string token, int? dataRecordId)
            : this()
        {
            _dataDomainName = dataDomainName;
            _initRecordId = dataRecordId;
            _token = token;
        }

        #endregion

        /// <summary>
        /// При любом изменении контекста формы (кроме его инициализации),
        /// форма будет считаться модифицированной
        /// </summary>
        protected bool IsModified
        {
            get => _isModified;
            set {
                if (_isModified == value) return;

                _isModified = value;

                if (Text.Length > 0)
                {
                    char lastChar = Text[^1];
                    var modifiedSymbol = "*";

                    if (_isModified && !lastChar.Equals(modifiedSymbol))
                    {
                        Text += modifiedSymbol;
                    }

                    if (!_isModified && lastChar.Equals(modifiedSymbol))
                    {
                        Text += Text.Remove(Text.Length - 1);
                    }
                }
            }
        }

        /// <summary>
        /// Если форма вызвана с идентификатором (dataRecordId передается в конструктор),
        /// то будет обращение к базе, по результатам которого заполнено Dto.
        /// Иначе ограничимся только созданием объекта с контекстом формы.
        /// </summary>
        /// 
        protected virtual void Init<T>() where T : BaseFormDto, new()
        {
            _dto = new T();
            _ctx = MakeContext();
            GrabControls(this);
            BindControls();
            BindButtons();

            /// Форма подписывается на изменение контекста, которое
            /// инициировано со стороны пользователя
            _ctx.ContextChangedByUser += C_ContextChangedByUser;
            SetTitle();
        }

        IDataRecordContext MakeContext()
        {
            if (Id.HasValue)
            {
                var funcName = "fn_get_" + _token + "_item_r";

                var cmd = new ApiCommand("api_admin", funcName);
                cmd.AddParam(new ApiParameter("p_id", Id));
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

        void GrabControls(Control parentControl)
        {
            foreach (Control c in parentControl.Controls)
            {
                if (c is IBaseControl bc && bc.PascalName != null)
                {
                    _baseControls.Add(bc.PascalName, bc);
                }
                else if (c is ParentTabControl tc)
                {
                    _parentTabControl = tc;
                }
                else if (c.Controls.Count > 0)
                {
                    GrabControls(c);
                }
            }
        }

        void BindControls()
        {
            if (_ctx == null)
                return;

            foreach (IBaseControl bc in _baseControls.Values)
            {
                bc.Bind(_ctx);
            }
        }

        protected virtual void BindButtons()
        {
            deleteButton.Enabled = Id.HasValue;
        }

        void SetTitle()
        {
            Text = Id.HasValue
                ? "Create " + _dataDomainName
                : _dataDomainName + " #" + Id.ToString();
        }

        JsonParameter MakeJsonParameter()
        {
            if (_ctx == null)
                throw new Exception("Form context should be defined before JSON parameter cooking");


            if (_dto == null)
                throw new Exception("Metadata should be defined before JSON parameter cooking");

            var jp = new JsonParameter();

            /// 
            /// Объект метаданных указывает, какие проперти нужно получить.
            /// Мы не можем пройтись по индексным проперям.
            /// 
            foreach (var prop in _dto.GetType().GetProperties())
            {
                var camelName = prop.Name.LowFirstChar();
                jp.Add(camelName, _ctx[camelName]);
            }

            /// TODO Copy from _ctx.DataTables the values from grid controls

            return jp;
        }

        #region Record Properties

        public int? Id
        {
            get {
                if (_ctx != null)
                {
                    return _ctx.Id == 0 ? null : _ctx.Id;
                }
                return _initRecordId;
            }
            set {
                if (_ctx != null && value != null)
                {
                    _ctx.Id = (int)value;
                }
            }
        }

        public int Version
        {
            get => _ctx == null ? 0 : _ctx.Version;
            set {
                if (_ctx != null)
                {
                    _ctx.Version = value;
                }
            }
        }

        public DataRecordState State
        {
            get {
                if (_ctx == null)
                    return DataRecordState.None;

                return _ctx.State;
            }
            set {
                if (_ctx == null)
                    return;

                _ctx.State = value;
            }
        }

        #endregion

        #region Checks

        protected virtual bool CheckPermit(RecordActionPermitEnum permit)
        {
            return true;
        }

        /// <summary>
        /// Проверяет лишь те поля, которые явно заданы обязательными.
        /// Это не отменяет проверки обязательности на стороне сервера,
        /// поэтому события OnPropertyInvalidated могут быть вызвани
        /// из обработчика результатов ответа
        /// </summary>
        bool CheckRequiredFields()
        {
            var isValid = true;

            foreach (var k in _baseControls.Keys)
            {
                IBaseControl bc = _baseControls[k];

                if (bc.IsRequired && bc.IsEmpty)
                {
                    if (_ctx != null)
                    {
                        var args = new PropertyInvalidatedEventArgs(k, "Is required", true);
                        _ctx.OnPropertyInvalidated(args);
                    }
                    else
                    {
                        MessageBox.Show($"Field {k} is required");
                        break;
                    }

                    isValid = false;
                }
            }

            return isValid;
        }

        #endregion

        #region Actions

        protected virtual void CreateAction()
        {
            if (!CheckPermit(RecordActionPermitEnum.Insert))
            {
                throw new Exception("Forbidden!");
            }

            var jp = MakeJsonParameter();

            var procName = "pr_" + _token + "_create_n";

            var cmd = new ApiCommand("api_admin", procName);
            cmd.AddParam(new ApiParameter("p_id", ApiParameterDataType.Integer));
            cmd.AddParam(new ApiParameter(jp));
            var id = App.CallApiCommand<int>(cmd);

            App.Logger.GuiReport($"Created {_dataDomainName} with id {id}");

            IsModified = false;
            Id = id;
            Version = 1;

        }

        protected virtual void UpdateAction()
        {
            if (!CheckPermit(RecordActionPermitEnum.Update))
            {
                throw new Exception("Forbidden!");
            }

            if (Id > 0)
            {
                CheckRequiredFields();

                var jp = MakeJsonParameter();

                var procName = "pr_" + _token + "_update_";

                var cmd = new ApiCommand("api_admin", procName);
                cmd.AddParam(new ApiParameter("p_ver", ApiParameterDataType.Integer));
                cmd.AddParam(new ApiParameter(jp));
                var ver = App.CallApiCommand<int>(cmd);

                App.Logger.GuiReport($"Updated {_dataDomainName} with id {Id} (version {ver})");

                IsModified = false;
                Version = ver;
            }
        }

        protected virtual void DeleteAction()
        {
            if (!CheckPermit(RecordActionPermitEnum.Delete))
            {
                throw new Exception("Forbidden!");
            }

            if (Id > 0 && (MessageBox.Show("Delete this object from Database? You will not undo this action!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK))
            {
                var procName = "pr_" + _token + "_remove_";

                var cmd = new ApiCommand("api_admin", procName);
                cmd.AddParam(new ApiParameter("p_id", Id));
                App.CallApiCommandVoid(cmd);

                App.Logger.GuiReport($"{_dataDomainName} with id {Id} REMOVED");

                IsModified = false;
            }
        }

        #endregion

        #region Overrides

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // So that registered delegates receive the event
            base.OnFormClosing(e);

            // Do not hinder shutdown
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            if (IsModified && MessageBox.Show("Not saved! Continue close?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Handlers

        void C_ContextChangedByUser(IObservableContext sender, EventArgs e)
        {
            IsModified = true;
        }

        void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void saveButton_Click(object sender, EventArgs e)
        {
            if (!CheckRequiredFields()) return;

            if (Id.HasValue)
            {
                UpdateAction();
            }
            else
            {
                CreateAction();
            }
            Close();
        }

        void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteAction();
            Close();
        }

        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (_keyDownHandled)
            {
                _keyDownHandled = false;
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                ActiveControl = closeButton;
                closeButton_Click(closeButton, EventArgs.Empty);
            }
            else if (e.Control && e.Alt)
            {
                //ActiveControl = toolStrip;
                //toolStrip.Items[0].Select();
            }
            else if (e.Control)
            {
                /// Управление главным контролом, если он создан на форме
                if (_parentTabControl != null)
                {
                    if (e.KeyCode == Keys.Left && _parentTabControl.SelectedIndex > 0)
                    {
                        _parentTabControl.SelectedIndex--;
                    }
                    else if (e.KeyCode == Keys.Right && _parentTabControl.SelectedIndex < _parentTabControl.TabPages.Count - 1)
                    {
                        _parentTabControl.SelectedIndex++;
                    }
                }

                /// Сохранение по Ctrl+Enter
                if (e.KeyCode == Keys.Enter && saveButton.Enabled)
                {
                    ActiveControl = saveButton;
                    saveButton_Click(saveButton, EventArgs.Empty);
                }
            }
        }

        #endregion
    }
}
