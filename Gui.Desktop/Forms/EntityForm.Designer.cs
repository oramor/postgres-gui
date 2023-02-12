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
            this.stringControlPublicName = new Lib.GuiCommander.Controls.StringControl();
            this.stringControlPascalName = new Lib.GuiCommander.Controls.StringControl();
            this.checkBoxIsDocument = new Lib.GuiCommander.BoolControl();
            this.stringControlPublicCode = new Lib.GuiCommander.Controls.StringControl();
            this.pascalNameFieldLabelControl = new Lib.GuiCommander.Controls.FieldLabelControl();
            this.publicNameFieldLabelControl = new Lib.GuiCommander.Controls.FieldLabelControl();
            this.publicCodeFieldLabelControl = new Lib.GuiCommander.Controls.FieldLabelControl();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(271, 131);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(190, 131);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(109, 131);
            // 
            // stringControlPublicName
            // 
            this.stringControlPublicName.BackColor = System.Drawing.Color.LightYellow;
            this.stringControlPublicName.BindingName = "publicName";
            this.stringControlPublicName.CurrentValue = "";
            this.stringControlPublicName.IsReadOnly = false;
            this.stringControlPublicName.IsRequired = true;
            this.stringControlPublicName.Length = 32767;
            this.stringControlPublicName.Location = new System.Drawing.Point(109, 44);
            this.stringControlPublicName.Name = "stringControlPublicName";
            this.stringControlPublicName.Size = new System.Drawing.Size(237, 23);
            this.stringControlPublicName.TabIndex = 7;
            // 
            // stringControlPascalName
            // 
            this.stringControlPascalName.BackColor = System.Drawing.Color.LightYellow;
            this.stringControlPascalName.BindingName = "pascalName";
            this.stringControlPascalName.CurrentValue = "";
            this.stringControlPascalName.IsReadOnly = false;
            this.stringControlPascalName.IsRequired = true;
            this.stringControlPascalName.Length = 32767;
            this.stringControlPascalName.Location = new System.Drawing.Point(109, 15);
            this.stringControlPascalName.Name = "stringControlPascalName";
            this.stringControlPascalName.Size = new System.Drawing.Size(237, 23);
            this.stringControlPascalName.TabIndex = 8;
            // 
            // checkBoxIsDocument
            // 
            this.checkBoxIsDocument.AutoSize = true;
            this.checkBoxIsDocument.BindingName = "isDocument";
            this.checkBoxIsDocument.CurrentValue = false;
            this.checkBoxIsDocument.IsReadOnly = false;
            this.checkBoxIsDocument.IsRequired = false;
            this.checkBoxIsDocument.Location = new System.Drawing.Point(109, 102);
            this.checkBoxIsDocument.Name = "checkBoxIsDocument";
            this.checkBoxIsDocument.Size = new System.Drawing.Size(93, 19);
            this.checkBoxIsDocument.TabIndex = 9;
            this.checkBoxIsDocument.Text = "Is Document";
            this.checkBoxIsDocument.UseVisualStyleBackColor = true;
            // 
            // stringControlPublicCode
            // 
            this.stringControlPublicCode.BackColor = System.Drawing.Color.White;
            this.stringControlPublicCode.BindingName = "publicCode";
            this.stringControlPublicCode.CurrentValue = "";
            this.stringControlPublicCode.IsReadOnly = false;
            this.stringControlPublicCode.IsRequired = false;
            this.stringControlPublicCode.Length = 32767;
            this.stringControlPublicCode.Location = new System.Drawing.Point(109, 73);
            this.stringControlPublicCode.Name = "stringControlPublicCode";
            this.stringControlPublicCode.Size = new System.Drawing.Size(92, 23);
            this.stringControlPublicCode.TabIndex = 11;
            // 
            // pascalNameFieldLabelControl
            // 
            this.pascalNameFieldLabelControl.AutoSize = true;
            this.pascalNameFieldLabelControl.Location = new System.Drawing.Point(12, 18);
            this.pascalNameFieldLabelControl.Name = "pascalNameFieldLabelControl";
            this.pascalNameFieldLabelControl.Size = new System.Drawing.Size(75, 15);
            this.pascalNameFieldLabelControl.TabIndex = 12;
            this.pascalNameFieldLabelControl.Text = "Pascal Name";
            // 
            // publicNameFieldLabelControl
            // 
            this.publicNameFieldLabelControl.AutoSize = true;
            this.publicNameFieldLabelControl.Location = new System.Drawing.Point(12, 47);
            this.publicNameFieldLabelControl.Name = "publicNameFieldLabelControl";
            this.publicNameFieldLabelControl.Size = new System.Drawing.Size(75, 15);
            this.publicNameFieldLabelControl.TabIndex = 13;
            this.publicNameFieldLabelControl.Text = "Public Name";
            // 
            // publicCodeFieldLabelControl
            // 
            this.publicCodeFieldLabelControl.AutoSize = true;
            this.publicCodeFieldLabelControl.Location = new System.Drawing.Point(12, 76);
            this.publicCodeFieldLabelControl.Name = "publicCodeFieldLabelControl";
            this.publicCodeFieldLabelControl.Size = new System.Drawing.Size(71, 15);
            this.publicCodeFieldLabelControl.TabIndex = 14;
            this.publicCodeFieldLabelControl.Text = "Public Code";
            // 
            // EntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 166);
            this.Controls.Add(this.publicCodeFieldLabelControl);
            this.Controls.Add(this.publicNameFieldLabelControl);
            this.Controls.Add(this.pascalNameFieldLabelControl);
            this.Controls.Add(this.stringControlPublicCode);
            this.Controls.Add(this.checkBoxIsDocument);
            this.Controls.Add(this.stringControlPascalName);
            this.Controls.Add(this.stringControlPublicName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EntityForm";
            this.Text = "Entity";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.deleteButton, 0);
            this.Controls.SetChildIndex(this.stringControlPublicName, 0);
            this.Controls.SetChildIndex(this.stringControlPascalName, 0);
            this.Controls.SetChildIndex(this.checkBoxIsDocument, 0);
            this.Controls.SetChildIndex(this.stringControlPublicCode, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.pascalNameFieldLabelControl, 0);
            this.Controls.SetChildIndex(this.publicNameFieldLabelControl, 0);
            this.Controls.SetChildIndex(this.publicCodeFieldLabelControl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private StringControl stringControlPublicName;
        private StringControl stringControlPascalName;
        private BoolControl checkBoxIsDocument;
        private StringControl stringControlPublicCode;
        private FieldLabelControl pascalNameFieldLabelControl;
        private FieldLabelControl publicNameFieldLabelControl;
        private FieldLabelControl publicCodeFieldLabelControl;
    }
}