using Lib.GuiCommander;
using Lib.GuiCommander.Controls;

namespace Gui.Desktop.Forms
{
    partial class EntityForm
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
            this.labelEntityName = new System.Windows.Forms.Label();
            this.labelPascalName = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBoxEntityName = new StringControl();
            this.textBoxPascalName = new StringControl();
            this.checkBoxIsDocument = new BoolControl();
            this.SuspendLayout();
            // 
            // labelEntityName
            // 
            this.labelEntityName.AutoSize = true;
            this.labelEntityName.Location = new System.Drawing.Point(12, 19);
            this.labelEntityName.Name = "labelEntityName";
            this.labelEntityName.Size = new System.Drawing.Size(77, 15);
            this.labelEntityName.TabIndex = 2;
            this.labelEntityName.Text = "Entity Name*";
            // 
            // labelPascalName
            // 
            this.labelPascalName.AutoSize = true;
            this.labelPascalName.Location = new System.Drawing.Point(12, 54);
            this.labelPascalName.Name = "labelPascalName";
            this.labelPascalName.Size = new System.Drawing.Size(80, 15);
            this.labelPascalName.TabIndex = 3;
            this.labelPascalName.Text = "Pascal Name*";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(247, 120);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxEntityName
            // 
            this.textBoxEntityName.ColumnName = null;
            this.textBoxEntityName.IsReadOnly = false;
            this.textBoxEntityName.IsRequired = false;
            this.textBoxEntityName.Length = 32767;
            this.textBoxEntityName.Location = new System.Drawing.Point(109, 16);
            this.textBoxEntityName.Name = "textBoxEntityName";
            this.textBoxEntityName.Size = new System.Drawing.Size(213, 23);
            this.textBoxEntityName.TabIndex = 7;
            // 
            // textBoxPascalName
            // 
            this.textBoxPascalName.ColumnName = null;
            this.textBoxPascalName.IsReadOnly = false;
            this.textBoxPascalName.IsRequired = false;
            this.textBoxPascalName.Length = 32767;
            this.textBoxPascalName.Location = new System.Drawing.Point(109, 51);
            this.textBoxPascalName.Name = "textBoxPascalName";
            this.textBoxPascalName.Size = new System.Drawing.Size(213, 23);
            this.textBoxPascalName.TabIndex = 8;
            // 
            // checkBoxIsDocument
            // 
            this.checkBoxIsDocument.AutoSize = true;
            this.checkBoxIsDocument.ColumnName = null;
            this.checkBoxIsDocument.Id = -1;
            this.checkBoxIsDocument.IsReadOnly = false;
            this.checkBoxIsDocument.IsRequired = false;
            this.checkBoxIsDocument.Location = new System.Drawing.Point(109, 85);
            this.checkBoxIsDocument.Name = "checkBoxIsDocument";
            this.checkBoxIsDocument.Size = new System.Drawing.Size(93, 19);
            this.checkBoxIsDocument.TabIndex = 9;
            this.checkBoxIsDocument.Text = "Is Document";
            this.checkBoxIsDocument.UseVisualStyleBackColor = true;
            // 
            // EntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 156);
            this.Controls.Add(this.checkBoxIsDocument);
            this.Controls.Add(this.textBoxPascalName);
            this.Controls.Add(this.textBoxEntityName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.labelPascalName);
            this.Controls.Add(this.labelEntityName);
            this.Name = "EntityForm";
            this.Text = "Entity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelEntityName;
        private Label labelPascalName;
        private Button btnCreate;
        private Button btnCancel;
        private StringControl textBoxEntityName;
        private StringControl textBoxPascalName;
        private BoolControl checkBoxIsDocument;
    }
}