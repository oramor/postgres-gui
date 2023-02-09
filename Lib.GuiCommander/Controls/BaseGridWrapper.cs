namespace Lib.GuiCommander.Controls
{
    public abstract class BaseGridWrapper
    {
        protected readonly GridControl _gridControl;

        public BaseGridWrapper(GridControl gridControl)
        {
            _gridControl = gridControl;
            _gridControl.Wrapper = this;
        }
    }
}
