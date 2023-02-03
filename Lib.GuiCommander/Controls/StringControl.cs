using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Lib.GuiCommander.Controls
{
    public partial class StringControl : TextBox, IBaseControl, IJsonControl<string?>
    {
        bool _isRequired;
        bool _readOnly;

        public StringControl()
        {
            InitializeComponent();
        }

        #region Bindable properties

        [Bindable(true), Category("Object properties")]
        public bool IsRequired
        {
            get => _isRequired;
            set {
                _isRequired = value;
                if (_readOnly)
                    BackColor = LibSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? LibSettings.ControlMandatoryColor : LibSettings.ControlBaseColor;
            }
        }

        /// <summary>
        /// Этот параметр заполняется вручную при добавлении контрола на форму
		/// и содержит название колонки во вью (camel_case).
        /// Соответственно, от лежит в Designer-классе. Именно CamelName является
        /// ключем, по которому выполняется привязка к значению. Само значение
        /// берется из <see cref="EntityObject"/> — объекта метадаты, который
		/// содержит все поля сущности и передается в метод <see cref="Init(EntityObject)"/>.
        /// </summary>
        [Browsable(true), Category("Object properties"), DefaultValue(null)]
        public string? BindingName { get; set; }

        [Bindable(true), Category("Object properties")]
        public bool IsReadOnly
        {
            get => _readOnly;
            set {
                _readOnly = value;
                base.ReadOnly = value;
                if (_readOnly)
                    BackColor = LibSettings.ControlReadOnlyColor;
                else
                    BackColor = _isRequired ? LibSettings.ControlMandatoryColor : LibSettings.ControlBaseColor;
            }
        }

        [Bindable(true), Category("Object properties")]
        public int Length
        {
            get => this.MaxLength;
            set => MaxLength = value;
        }

        [AllowNull]
        public override string Text
        {
            get => base.Text;
            set => CurrentValue = value;
        }

        #endregion

        public bool IsEmpty => string.IsNullOrEmpty(Text);
        public string CamelName => BindingName == null ? string.Empty : BindingName.LowFirstChar();
        public string PascalName => BindingName == null ? string.Empty : BindingName.UpFirstChar();

        public void Bind(IObservableContext ctx)
        {
            if (CamelName == null)
                return;

            if (ctx[CamelName] is string v)
            {
                CurrentValue = v;
            }
            else
            {
                ctx[CamelName] = CurrentValue;
            }

            /// Контекст получит оповещение, если значение
            /// контрола изменилось
            ControlValueChanged += ctx.ControlValueChangedEventHandler;

            /// Контрол сможет реагировать на изменение свойства,
            /// с которым он связан через BindingName
            ctx.ContextPropertyChanged += C_ContextPropertyChanged;
        }

        /// <summary>
        /// Событие можно сделать приватным (или напрямую добавлять в делегат),
        /// если работа с родительскими контролами так же будет строиться
        /// через отслеживание контекста
        /// </summary>
        public event ControlValueChangedEventHandler? ControlValueChanged;
        protected void OnControlValueChanged(IBaseControl sender, ControlValueChangedEventArgs e)
        {
            ControlValueChanged?.Invoke(sender, e);
        }

        public string? CurrentValue
        {
            get => base.Text;
            set {
                if (base.Text == value)
                    return;

                base.Text = value ?? string.Empty;
            }
        }

        #region Event Handlers

        /// <summary>
        /// Если состояние контекста формы изменяется (например, при изменении текущего
        /// объекта на форме), то контекст посылает оповещения обо всех измененных
        /// свойствах. Каждый контрол подписывается на эти оповещения в методе Bind()
        /// и может изменить свое состоение, если получит оповещение о новом значении
        /// свойства, от которого он зависит.
        /// </summary>
        public void C_ContextPropertyChanged(IObservableContext sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CamelName && sender[e.PropertyName] is string v)
            {
                CurrentValue = v;
            }
        }

        private void StringControl_TextChanged(object sender, EventArgs e)
        {
            /// При изменении оповещение получат все подписанные на данный
            /// контрол компоненты, а так же стейт, который подписывается
            /// на все компоненты формы, которые реализют интерфейс
            /// <see cref="IBaseControl"/>. При этом стейт самостоятельно
            /// сравнивает полученное от компонента значение и, если это
            /// значение отличается от текущего, генерирует событие
            /// о свобем обновлении.
            OnControlValueChanged(this, new ControlValueChangedEventArgs(Text));
        }

        private void StringControl_Enter(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        #endregion
    }
}

