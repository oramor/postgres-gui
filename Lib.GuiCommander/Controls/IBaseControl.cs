namespace Lib.GuiCommander
{
    public interface IBaseControl
    {
        /// <summary>
        /// Событие ловится на форме <see cref="EntityItemForm"/> и обновляет статус
        /// формы на changed, что влияет на вопрос перед ее закрытием
        /// </summary>
        public delegate void ControlChangedEventHandler(object sender, EventArgs e);

        public interface IBindableControl
        {
            bool IsEmpty { get; }
            bool IsRequired { get; set; }
            bool IsReadOnly { get; set; }
            void Bind(EntityObject obj);
            event ControlChangedEventHandler ControlChanged;
        }
    }
}
