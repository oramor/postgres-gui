using Gui.Desktop.Dto;
using Lib.GuiCommander;
using Lib.Providers;
using Lib.Providers.JsonProvider;
using System.ComponentModel;
using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class BaseObjectForm : Form
    {
        bool _isModified;
        protected bool _keyDownHandled;
        readonly string? _dataDomainName;
        readonly string? _token;
        readonly int? _dataRecordId;
        IObservableContext? _ctx;
        BaseFormDto? _dto;

        #region Constructrs

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
        protected virtual void Init<T>() where T : BaseFormDto, new()
        {
            _dto = new T();
            _ctx = MakeContext();
            BindControls(this);
            /// Форма подписывается на обновление контекста, который, в свою очередь,
            /// обновляют контролы, либо внутренние события самой формы (например,
            /// загрузка данных из базы)
            _ctx.ContextPropertyChanged += C_ContextPropertyChanged;
            SetTitle();
        }

        IObservableContext MakeContext()
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

        JsonParameter MakeJsonParameter()
        {
            if (_ctx == null)
                throw new Exception("Form context should be defined before JSON parameter cooking");


            if (_dto == null)
                throw new Exception("Metadata should be defined before JSON parameter cooking");

            var jp = new JsonParameter();

            /// Объект метаданных указывает, какие проперти нужно получить.
            /// Мы не можем пройтись по индексным проперям.
            foreach (var prop in _dto.GetType().GetProperties())
            {
                var camelName = prop.Name.LowFirstChar();
                jp.Add(camelName, _ctx[camelName]);
            }

            /// TODO Copy from _ctx.DataTables the values from grid controls

            return jp;
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

        #region Checks

        /// <summary>
        /// Обязательно сохранить, если форма была модифицирована, либо
        /// ее текущий статус отличается от целевого
        /// </summary>
        protected virtual bool SaveRequired(DataRecordState targetState)
        {
            return State != targetState || IsModified;
        }

        #endregion

        #region Actions

        void CreateAction()
        {
            var jp = MakeJsonParameter();

            var procName = "pr_" + _token + "_create_n";

            var cmd = new ApiCommand("api_admin", procName);
            cmd.AddParam(new ApiParameter("p_id", ApiParameterDataType.Integer));
            cmd.AddParam(new ApiParameter(jp));
            var result = App.CallApiCommand<int>(cmd);

            App.Logger.GuiReport($"Created {_dataDomainName} with id {result}");

            IsModified = false;
        }

        void SaveAction()
        {
            if (_dataRecordId > 0)
            {
                var procName = "pr_" + _token + "_update_";
            }
            IsModified = false;
        }

        void DeleteAction()
        {
            if (_dataRecordId > 0 && (MessageBox.Show("Delete this object from Database? You will not undo this action!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK))
            {
                var procName = "pr_" + _token + "_remove_";

                var cmd = new ApiCommand("api_admin", procName);
                cmd.AddParam(new ApiParameter("p_id", _dataRecordId));
                var result = App.CallApiCommand<int>(cmd);

                App.Logger.GuiReport($"{_dataDomainName} with id {result} REMOVED");

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
            if (MessageBox.Show("Not saved! Continue close?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Handlers

        void C_ContextPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            IsModified = true;
        }

        void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void saveButton_Click(object sender, EventArgs e)
        {
            if (_dataRecordId.HasValue)
            {
                SaveAction();
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
                if (e.KeyCode == Keys.Left)
                {
                    //TabControl tabControl1 = FindControlByName(this, "tabControl1") as TabControl;
                    //if (tabControl1 != null && tabControl1.SelectedIndex > 0)
                    //    tabControl1.SelectedIndex--;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    //TabControl tabControl1 = FindControlByName(this, "tabControl1") as TabControl;
                    //if (tabControl1 != null && tabControl1.SelectedIndex < tabControl1.TabPages.Count - 1)
                    //    tabControl1.SelectedIndex++;
                }
                else if (e.KeyCode == Keys.Enter && saveButton.Enabled)
                {
                    ActiveControl = saveButton;
                    saveButton_Click(saveButton, EventArgs.Empty);
                }
                //else if (e.KeyCode == Keys.S && saveToolStripButton.Enabled)
                //{
                //    ActiveControl = FindControlByName(this, "tabControl1");
                //    saveToolStripButton_Click(saveToolStripButton, EventArgs.Empty);
                //}
            }
        }

        #endregion
    }
}
