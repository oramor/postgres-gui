namespace Lib.GuiCommander.Controls
{
    /// <summary>
    /// Реализует базовый функционал для управления формой со стейтом. Не важно,
    /// это форма одной записи или списка. Контекст, который принимает форма,
    /// готовится в конструкторе унеследованной формы. Форма так же не реализует
    /// работу с базой данный. Ее задача только в биндинге контродов и проверке
    /// состояния перед закрытием (запрос подтверждения, если какой-то из
    /// компонентов был изменен).
    /// </summary>
    public partial class ContextFormControl : Form
    {
        IRecordContext? _ctx;

        protected ContextFormControl()
        {
            InitializeComponent();
        }

        public ContextFormControl(IRecordContext ctx)
        {
            _ctx = ctx;
            BindControls(this);
            SetTitle();
        }

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

        protected virtual void SetTitle()
        {
            if (_ctx == null)
                return;

            Text = _ctx["title"] as string ?? string.Empty;
        }
    }
}
