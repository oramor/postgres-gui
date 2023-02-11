namespace Lib.GuiCommander.Controls
{
    public partial class GridControl : DataGridView
    {
        public GridControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ссылка на декоратор, которая позволяет управлять
        /// гридом из формы, на которой он расположен (например,
        /// для сохранения настроек)
        /// </summary>
        public BaseGridWrapper? Wrapper { get; set; }
    }
}
