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
            this.labelPublicName = new System.Windows.Forms.Label();
            this.labelPascalName = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.stringControlPublicName = new Lib.GuiCommander.Controls.StringControl();
            this.stringControlPascalName = new Lib.GuiCommander.Controls.StringControl();
            this.checkBoxIsDocument = new Lib.GuiCommander.BoolControl();
            this.labelPublicCode = new System.Windows.Forms.Label();
            this.stringControlPublicCode = new Lib.GuiCommander.Controls.StringControl();
            this.SuspendLayout();
            // 
            // labelPublicName
            // 
            this.labelPublicName.AutoSize = true;
            this.labelPublicName.Location = new System.Drawing.Point(12, 53);
            this.labelPublicName.Name = "labelPublicName";
            this.labelPublicName.Size = new System.Drawing.Size(80, 15);
            this.labelPublicName.TabIndex = 2;
            this.labelPublicName.Text = "Public Name*";
            // 
            // labelPascalName
            // 
            this.labelPascalName.AutoSize = true;
            this.labelPascalName.Location = new System.Drawing.Point(12, 18);
            this.labelPascalName.Name = "labelPascalName";
            this.labelPascalName.Size = new System.Drawing.Size(80, 15);
            this.labelPascalName.TabIndex = 3;
            this.labelPascalName.Text = "Pascal Name*";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(247, 156);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // stringControlPublicName
            // 
            this.stringControlPublicName.BackColor = System.Drawing.Color.White;
            this.stringControlPublicName.CamelName = null;
            this.stringControlPublicName.IsReadOnly = false;
            this.stringControlPublicName.IsRequired = false;
            this.stringControlPublicName.Length = 32767;
            this.stringControlPublicName.Location = new System.Drawing.Point(109, 50);
            this.stringControlPublicName.Name = "stringControlPublicName";
            this.stringControlPublicName.Size = new System.Drawing.Size(213, 23);
            this.stringControlPublicName.TabIndex = 7;
            // 
            // stringControlPascalName
            // 
            this.stringControlPascalName.BackColor = System.Drawing.Color.White;
            this.stringControlPascalName.CamelName = null;
            this.stringControlPascalName.IsReadOnly = false;
            this.stringControlPascalName.IsRequired = false;
            this.stringControlPascalName.Length = 32767;
            this.stringControlPascalName.Location = new System.Drawing.Point(109, 15);
            this.stringControlPascalName.Name = "stringControlPascalName";
            this.stringControlPascalName.Size = new System.Drawing.Size(213, 23);
            this.stringControlPascalName.TabIndex = 8;
            // 
            // checkBoxIsDocument
            // 
            this.checkBoxIsDocument.AutoSize = true;
            this.checkBoxIsDocument.CamelName = null;
            this.checkBoxIsDocument.Id = -1;
            this.checkBoxIsDocument.IsReadOnly = false;
            this.checkBoxIsDocument.IsRequired = false;
            this.checkBoxIsDocument.Location = new System.Drawing.Point(109, 121);
            this.checkBoxIsDocument.Name = "checkBoxIsDocument";
            this.checkBoxIsDocument.Size = new System.Drawing.Size(93, 19);
            this.checkBoxIsDocument.TabIndex = 9;
            this.checkBoxIsDocument.Text = "Is Document";
            this.checkBoxIsDocument.UseVisualStyleBackColor = true;
            // 
            // labelPublicCode
            // 
            this.labelPublicCode.AutoSize = true;
            this.labelPublicCode.Location = new System.Drawing.Point(12, 89);
            this.labelPublicCode.Name = "labelPublicCode";
            this.labelPublicCode.Size = new System.Drawing.Size(71, 15);
            this.labelPublicCode.TabIndex = 10;
            this.labelPublicCode.Text = "Public Code";
            // 
            // stringControlPublicCode
            // 
            this.stringControlPublicCode.BackColor = System.Drawing.Color.White;
            this.stringControlPublicCode.CamelName = null;
            this.stringControlPublicCode.IsReadOnly = false;
            this.stringControlPublicCode.IsRequired = false;
            this.stringControlPublicCode.Length = 32767;
            this.stringControlPublicCode.Location = new System.Drawing.Point(109, 86);
            this.stringControlPublicCode.Name = "stringControlPublicCode";
            this.stringControlPublicCode.Size = new System.Drawing.Size(92, 23);
            this.stringControlPublicCode.TabIndex = 11;
            // 
            // EntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 191);
            this.Controls.Add(this.stringControlPublicCode);
            this.Controls.Add(this.labelPublicCode);
            this.Controls.Add(this.checkBoxIsDocument);
            this.Controls.Add(this.stringControlPascalName);
            this.Controls.Add(this.stringControlPublicName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.labelPascalName);
            this.Controls.Add(this.labelPublicName);
            this.Name = "EntityForm";
            this.Text = "Entity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelPublicName;
        private Label labelPascalName;
        private Button btnCreate;
        private Button btnCancel;
        private StringControl stringControlPublicName;
        private StringControl stringControlPascalName;
        private BoolControl checkBoxIsDocument;
        private Label labelPublicCode;
        private StringControl stringControlPublicCode;
    }
}