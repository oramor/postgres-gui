using System.Security.AccessControl;

namespace Lib.GuiCommander.Controls
{
    public abstract class BaseGridWrapper
    {
        protected readonly GridControl _gridControl;
        protected readonly IDiContainer _di;


        public BaseGridWrapper(GridControl gridControl, IDiContainer di)
        {
            _gridControl = gridControl;
            _di = di;

            _gridControl.Wrapper = this;
        }


    }
}
