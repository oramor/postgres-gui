namespace Gui.Desktop.Forms
{
    public partial class EntityForm : BaseObjectForm
    {
        protected EntityForm() : base()
        {
            InitializeComponent();
        }

        public EntityForm(int? entityId) : base("entity", "entity", entityId)
        {
            InitializeComponent();
            Init<EntityDto>();
        }
    }
}
