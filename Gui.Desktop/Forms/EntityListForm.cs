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

                dataGridView1.DataSource = result;
            }
        }
    }
}
