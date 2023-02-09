namespace Gui.Desktop.Forms
{
    partial class DataRecordListForm
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
            this.gridControl = new Lib.GuiCommander.Controls.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.AllowDrop = true;
            this.gridControl.AllowUserToAddRows = false;
            this.gridControl.AllowUserToDeleteRows = false;
            this.gridControl.AllowUserToResizeColumns = false;
            this.gridControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.Name = "gridControl";
            this.gridControl.ReadOnly = true;
            this.gridControl.RowHeadersVisible = false;
            this.gridControl.RowTemplate.Height = 26;
            this.gridControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridControl.Size = new System.Drawing.Size(800, 450);
            this.gridControl.TabIndex = 0;
            this.gridControl.Wrapper = null;
            // 
            // ObjectListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl);
            this.Name = "ObjectListForm";
            this.Text = "ObjectListForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Lib.GuiCommander.Controls.GridControl gridControl;
    }
}