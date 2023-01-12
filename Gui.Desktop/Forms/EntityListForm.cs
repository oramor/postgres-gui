using Lib.Wf;
using System.Data;

namespace Gui.Desktop.Forms
{
    public partial class EntityListForm : Form
    {
        public EntityListForm()
        {
            InitializeComponent();

            var db = App.DbProvider;
            if (db.IsConnected)
            {
                var cmd = ApiAdmin.GetEntityList();
                var result = db.Execute<DataTable>(cmd);

                entityDataGridView.DataSource = result;
            }
        }

        private void entityDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            // Если был клик правой клавишей мыши
            if (e.Button == MouseButtons.Right)
            {
                var isClickOnCell = entityDataGridView.DataGridViewCellClicked(MousePosition);
                GetContextMenuStripForEntityDataGridView(isClickOnCell).Show(entityDataGridView, e.Location);
            }
        }

        ContextMenuStrip GetContextMenuStripForEntityDataGridView(bool isClickOnCell)
        {
            // Здесь запрос прав доступа
            var canOpen = true;

            // Отображаем пункты меню
            openEntityContextMenuStrip.Visible = canOpen & isClickOnCell;
            return entityContextMenuStrip;
        }

        private void openEntityContextMenuStrip_Click(object sender, EventArgs e)
        {
            OpenEntity();
        }

        private void OpenEntity()
        {
            var canOpen = true;
            if (canOpen && entityDataGridView.SelectedRows.Count == 1)
            {
                DataGridViewRow selected = entityDataGridView.SelectedRows[0];
                var dto = selected.DataBoundItem as EntityDto;
                if (dto != null)
                {
                    MessageBox.Show(dto.PublicName);
                }
            }
        }
    }
}
