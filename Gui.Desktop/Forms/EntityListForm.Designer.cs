namespace Gui.Desktop.Forms
{
    partial class EntityListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.entityDataGridView = new System.Windows.Forms.DataGridView();
            this.entityContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openEntityContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.entityDataGridView)).BeginInit();
            this.entityContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // entityDataGridView
            // 
            this.entityDataGridView.AllowDrop = true;
            this.entityDataGridView.AllowUserToAddRows = false;
            this.entityDataGridView.AllowUserToDeleteRows = false;
            this.entityDataGridView.AllowUserToResizeRows = false;
            this.entityDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.entityDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.entityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entityDataGridView.ContextMenuStrip = this.entityContextMenuStrip;
            this.entityDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityDataGridView.Location = new System.Drawing.Point(0, 0);
            this.entityDataGridView.Name = "entityDataGridView";
            this.entityDataGridView.ReadOnly = true;
            this.entityDataGridView.RowHeadersVisible = false;
            this.entityDataGridView.RowTemplate.Height = 26;
            this.entityDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.entityDataGridView.Size = new System.Drawing.Size(738, 418);
            this.entityDataGridView.TabIndex = 0;
            this.entityDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.entityDataGridView_MouseUp);
            // 
            // entityContextMenuStrip
            // 
            this.entityContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openEntityContextMenuStrip});
            this.entityContextMenuStrip.Name = "contextMenuStrip1";
            this.entityContextMenuStrip.Size = new System.Drawing.Size(181, 48);
            // 
            // openEntityContextMenuStrip
            // 
            this.openEntityContextMenuStrip.Name = "openEntityContextMenuStrip";
            this.openEntityContextMenuStrip.Size = new System.Drawing.Size(180, 22);
            this.openEntityContextMenuStrip.Text = "Open";
            this.openEntityContextMenuStrip.Click += new System.EventHandler(this.openEntityContextMenuStrip_Click);
            // 
            // EntityListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 418);
            this.Controls.Add(this.entityDataGridView);
            this.Name = "EntityListForm";
            this.Text = "EntityListForm";
            ((System.ComponentModel.ISupportInitialize)(this.entityDataGridView)).EndInit();
            this.entityContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView entityDataGridView;
        private ContextMenuStrip entityContextMenuStrip;
        private ToolStripMenuItem openEntityContextMenuStrip;
    }
}