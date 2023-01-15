﻿using Lib.BusinessCommander;
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
            //OpenEntity();
            //Если был клик правой клавишей мыши
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
            var id = entityDataGridView.GetColumnIdValue();

            // Отображаем пункты меню
            openEntityContextMenuStrip.Visible = canOpen & (id > 0) & isClickOnCell;
            return entityContextMenuStrip;
        }

        private void openEntityContextMenuStrip_Click(object sender, EventArgs e)
        {
            OpenEntity();
        }

        private void OpenEntity()
        {
            var canOpen = true;
            var id = entityDataGridView.GetColumnIdValue();
            if (canOpen && id > 0)
            {
                MessageBox.Show(id.ToString());
            }
        }
    }
}
