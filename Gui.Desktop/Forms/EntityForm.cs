﻿namespace Gui.Desktop.Forms
{
    public partial class EntityForm : GuiObjectForm
    {
        private EntityDto _dao = new();

        public EntityForm() : base()
        {
            InitializeComponent();
        }

        public EntityForm(EntityDto? dao) : base()
        {
            InitializeComponent();

            if (dao != null)
            {
                _dao = dao;
                SetFieldValues();
            }
        }

        private void SetFieldValues()
        {
            _dao.PublicName = this.textBoxEntityName.Text;
            _dao.PascalName = this.textBoxPascalName.Text;
            _dao.IsDocument = this.checkBoxIsDocument.Checked;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SetFieldValues();
            var apiCmd = ApiAdmin.CreateEntity(_dao);
            var entityId = CallApiCommand<int>(apiCmd);
            App.Logger.GuiOperationReport("Created Entity with Id " + entityId);
            this.Close();
        }
    }
}
