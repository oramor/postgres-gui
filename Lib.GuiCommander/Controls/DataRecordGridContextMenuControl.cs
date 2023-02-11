using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.GuiCommander.Controls.DataRecordGrid;

namespace Lib.GuiCommander.Controls
{
    public partial class DataRecordGridContextMenuControl : ContextMenuStrip
    {
        readonly IDataRecordGridWrapper? _wrapper;

        protected DataRecordGridContextMenuControl()
        {
            InitializeComponent();
        }

        public DataRecordGridContextMenuControl(IDataRecordGridWrapper wrapper)
            : base()
        {
            _wrapper = wrapper;

            var reloadItem = new ToolStripMenuItem("Reload");
            reloadItem.Click += ReloadClickHandler;
            Items.Add(reloadItem);

            var openItem = new ToolStripMenuItem("Open");
            openItem.Click += OpenDataRecordFormHandler;
            openItem.Visible = true;
            Items.Add(openItem);
        }

        void ClearSeparators()
        {

        }

        void ReloadClickHandler(object? sender, EventArgs e)
        {

            MessageBox.Show("Обновлено!");
        }

        void OpenDataRecordFormHandler(object? sender, EventArgs e)
        {
            if (_wrapper == null)
                return;

            var id = _wrapper.GetSelectedRowId();

            if (id.HasValue)
            {

            }

        }
    }
}
