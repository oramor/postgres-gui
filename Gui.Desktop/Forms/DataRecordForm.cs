using Lib.GuiCommander;
using Lib.GuiCommander.Controls;

namespace Gui.Desktop.Forms
{
    public partial class DataRecordForm : Form // BaseRecordForm
    {
        bool _isModified;
        protected bool _keyDownHandled;
        readonly Dictionary<string, IBaseControl> _baseControls = new();
        ParentTabControl? _parentTabControl;
        readonly IDataRecordContext? _ctx;

        #region Constructrs

        protected DataRecordForm()
        {
            InitializeComponent();
        }

        public DataRecordForm(IDataRecordContext ctx)
            : this()
        {
            _ctx = ctx;

            /// Форма подписывается на изменение контекста, которое
            /// инициировано со стороны пользователя
            _ctx.ContextChangedByUser += C_ContextChangedByUser;
            _ctx.ActionSucceed += ActionSucceedHandler;
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
        protected virtual void Init()
        {
            GrabControls(this);
            BindControls();
            BindButtons();
            SetTitle();
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
            var id = _ctx?.Id ?? 0;
            deleteButton.Enabled = id > 0;
        }

        void SetTitle()
        {
            var dataDomainName = _ctx?.DataDomainName ?? "<Not found context>";

            Text = Id.HasValue
                ? "Create " + dataDomainName
: dataDomainName + " #" + Id.ToString();
        }

        #region Record Properties Views

        public int? Id
        {
            get {
                if (_ctx != null)
                {
                    return _ctx.Id == 0 ? null : _ctx.Id;
                }
                return null;
            }
        }

        #endregion

        #region Checks

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

        /// <summary>
        /// Если статус поменялся, отсчет обновления начинается заново, флаг снимаем
        /// </summary>
        void ActionSucceedHandler(object? sender, EventArgs e)
        {
            IsModified = false;
        }

        void C_ContextChangedByUser(IDataRecordContext sender, EventArgs e)
        {
            IsModified = true;
        }

        void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void saveButton_Click(object sender, EventArgs e)
        {
            if (_ctx == null)
                return;

            if (!CheckRequiredFields()) return;

            if (Id.HasValue)
            {
                _ctx.Update();
            }
            else
            {
                _ctx.Create();
            }
            Close();
        }

        void deleteButton_Click(object sender, EventArgs e)
        {
            if (_ctx == null)
                return;

            _ctx.Delete();
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
