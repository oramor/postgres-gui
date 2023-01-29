namespace Gui.Desktop.Forms
{
    partial class DbTableColumnFk
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
            this.dbTableFieldLabelControl = new Lib.GuiCommander.Controls.FieldLabelControl();
            this.dbTableComboBoxControl = new Lib.GuiCommander.Controls.ComboBoxControl();
            this.fkTableFieldLabelControl = new Lib.GuiCommander.Controls.FieldLabelControl();
            this.comboBoxControl1 = new Lib.GuiCommander.Controls.ComboBoxControl();
            this.snakeNameStringControl = new Lib.GuiCommander.Controls.StringControl();
            this.snakeNameFieldLabelControl = new Lib.GuiCommander.Controls.FieldLabelControl();
            this.defaultGuiNameStringControl = new Lib.GuiCommander.Controls.StringControl();
            this.defaultGuiNameFieldLabelControl1 = new Lib.GuiCommander.Controls.FieldLabelControl();
            this.defaultGuiShortNameStringControl = new Lib.GuiCommander.Controls.StringControl();
            this.defaultGuiShortNameFieldLabelControl1 = new Lib.GuiCommander.Controls.FieldLabelControl();
            this.logicalDataTypeIdComboBoxControl = new Lib.GuiCommander.Controls.ComboBoxControl();
            this.logicalTypeFieldLabelControl = new Lib.GuiCommander.Controls.FieldLabelControl();
            this.isReqiredBoolControl = new Lib.GuiCommander.BoolControl();
            this.defaultPriorityIntControl = new Lib.GuiCommander.Controls.IntControl();
            this.defaultPriorityFieldLabelControl = new Lib.GuiCommander.Controls.FieldLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPriorityIntControl)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(322, 226);
            this.saveButton.TabIndex = 8;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(241, 226);
            this.closeButton.TabIndex = 9;
            // 
            // dbTableFieldLabelControl
            // 
            this.dbTableFieldLabelControl.AutoSize = true;
            this.dbTableFieldLabelControl.Location = new System.Drawing.Point(12, 9);
            this.dbTableFieldLabelControl.Name = "dbTableFieldLabelControl";
            this.dbTableFieldLabelControl.Size = new System.Drawing.Size(52, 15);
            this.dbTableFieldLabelControl.TabIndex = 20;
            this.dbTableFieldLabelControl.Text = "Db Table";
            // 
            // dbTableComboBoxControl
            // 
            this.dbTableComboBoxControl.BackColor = System.Drawing.Color.LightBlue;
            this.dbTableComboBoxControl.CamelName = "dbTableId";
            this.dbTableComboBoxControl.CurrentValue = null;
            this.dbTableComboBoxControl.DataSourceRoutine = null;
            this.dbTableComboBoxControl.DisplayMember = "Title";
            this.dbTableComboBoxControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbTableComboBoxControl.FormattingEnabled = true;
            this.dbTableComboBoxControl.IsReadOnly = false;
            this.dbTableComboBoxControl.IsRequired = true;
            this.dbTableComboBoxControl.Location = new System.Drawing.Point(110, 6);
            this.dbTableComboBoxControl.Name = "dbTableComboBoxControl";
            this.dbTableComboBoxControl.Size = new System.Drawing.Size(287, 23);
            this.dbTableComboBoxControl.TabIndex = 1;
            this.dbTableComboBoxControl.ValueMember = "Id";
            // 
            // fkTableFieldLabelControl
            // 
            this.fkTableFieldLabelControl.AutoSize = true;
            this.fkTableFieldLabelControl.Location = new System.Drawing.Point(12, 38);
            this.fkTableFieldLabelControl.Name = "fkTableFieldLabelControl";
            this.fkTableFieldLabelControl.Size = new System.Drawing.Size(50, 15);
            this.fkTableFieldLabelControl.TabIndex = 21;
            this.fkTableFieldLabelControl.Text = "FK Table";
            // 
            // comboBoxControl1
            // 
            this.comboBoxControl1.BackColor = System.Drawing.Color.LightBlue;
            this.comboBoxControl1.CamelName = "FkTableId";
            this.comboBoxControl1.CurrentValue = null;
            this.comboBoxControl1.DataSourceRoutine = null;
            this.comboBoxControl1.DisplayMember = "Title";
            this.comboBoxControl1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxControl1.FormattingEnabled = true;
            this.comboBoxControl1.IsReadOnly = false;
            this.comboBoxControl1.IsRequired = true;
            this.comboBoxControl1.Location = new System.Drawing.Point(110, 35);
            this.comboBoxControl1.Name = "comboBoxControl1";
            this.comboBoxControl1.Size = new System.Drawing.Size(287, 23);
            this.comboBoxControl1.TabIndex = 2;
            this.comboBoxControl1.ValueMember = "Id";
            // 
            // snakeNameStringControl
            // 
            this.snakeNameStringControl.BackColor = System.Drawing.Color.LightBlue;
            this.snakeNameStringControl.CamelName = "snakeName";
            this.snakeNameStringControl.CurrentValue = "";
            this.snakeNameStringControl.IsReadOnly = false;
            this.snakeNameStringControl.IsRequired = true;
            this.snakeNameStringControl.Length = 32767;
            this.snakeNameStringControl.Location = new System.Drawing.Point(110, 64);
            this.snakeNameStringControl.Name = "snakeNameStringControl";
            this.snakeNameStringControl.Size = new System.Drawing.Size(287, 23);
            this.snakeNameStringControl.TabIndex = 3;
            // 
            // snakeNameFieldLabelControl
            // 
            this.snakeNameFieldLabelControl.AutoSize = true;
            this.snakeNameFieldLabelControl.Location = new System.Drawing.Point(12, 67);
            this.snakeNameFieldLabelControl.Name = "snakeNameFieldLabelControl";
            this.snakeNameFieldLabelControl.Size = new System.Drawing.Size(73, 15);
            this.snakeNameFieldLabelControl.TabIndex = 23;
            this.snakeNameFieldLabelControl.Text = "Snake Name";
            // 
            // defaultGuiNameStringControl
            // 
            this.defaultGuiNameStringControl.BackColor = System.Drawing.Color.LightBlue;
            this.defaultGuiNameStringControl.CamelName = "defaultGuiName";
            this.defaultGuiNameStringControl.CurrentValue = "";
            this.defaultGuiNameStringControl.IsReadOnly = false;
            this.defaultGuiNameStringControl.IsRequired = true;
            this.defaultGuiNameStringControl.Length = 32767;
            this.defaultGuiNameStringControl.Location = new System.Drawing.Point(110, 93);
            this.defaultGuiNameStringControl.Name = "defaultGuiNameStringControl";
            this.defaultGuiNameStringControl.Size = new System.Drawing.Size(287, 23);
            this.defaultGuiNameStringControl.TabIndex = 4;
            // 
            // defaultGuiNameFieldLabelControl1
            // 
            this.defaultGuiNameFieldLabelControl1.AutoSize = true;
            this.defaultGuiNameFieldLabelControl1.Location = new System.Drawing.Point(12, 96);
            this.defaultGuiNameFieldLabelControl1.Name = "defaultGuiNameFieldLabelControl1";
            this.defaultGuiNameFieldLabelControl1.Size = new System.Drawing.Size(61, 15);
            this.defaultGuiNameFieldLabelControl1.TabIndex = 24;
            this.defaultGuiNameFieldLabelControl1.Text = "GUI Name";
            // 
            // defaultGuiShortNameStringControl
            // 
            this.defaultGuiShortNameStringControl.BackColor = System.Drawing.Color.LightBlue;
            this.defaultGuiShortNameStringControl.CamelName = "defaultGuiShortName";
            this.defaultGuiShortNameStringControl.CurrentValue = "";
            this.defaultGuiShortNameStringControl.IsReadOnly = false;
            this.defaultGuiShortNameStringControl.IsRequired = true;
            this.defaultGuiShortNameStringControl.Length = 32767;
            this.defaultGuiShortNameStringControl.Location = new System.Drawing.Point(110, 122);
            this.defaultGuiShortNameStringControl.Name = "defaultGuiShortNameStringControl";
            this.defaultGuiShortNameStringControl.Size = new System.Drawing.Size(287, 23);
            this.defaultGuiShortNameStringControl.TabIndex = 5;
            // 
            // defaultGuiShortNameFieldLabelControl1
            // 
            this.defaultGuiShortNameFieldLabelControl1.AutoSize = true;
            this.defaultGuiShortNameFieldLabelControl1.Location = new System.Drawing.Point(12, 125);
            this.defaultGuiShortNameFieldLabelControl1.Name = "defaultGuiShortNameFieldLabelControl1";
            this.defaultGuiShortNameFieldLabelControl1.Size = new System.Drawing.Size(92, 15);
            this.defaultGuiShortNameFieldLabelControl1.TabIndex = 25;
            this.defaultGuiShortNameFieldLabelControl1.Text = "GUI Short Name";
            // 
            // logicalDataTypeIdComboBoxControl
            // 
            this.logicalDataTypeIdComboBoxControl.BackColor = System.Drawing.Color.LightBlue;
            this.logicalDataTypeIdComboBoxControl.CamelName = "logicalDataTypeId";
            this.logicalDataTypeIdComboBoxControl.CurrentValue = null;
            this.logicalDataTypeIdComboBoxControl.DataSourceRoutine = null;
            this.logicalDataTypeIdComboBoxControl.DisplayMember = "Title";
            this.logicalDataTypeIdComboBoxControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logicalDataTypeIdComboBoxControl.FormattingEnabled = true;
            this.logicalDataTypeIdComboBoxControl.IsReadOnly = false;
            this.logicalDataTypeIdComboBoxControl.IsRequired = true;
            this.logicalDataTypeIdComboBoxControl.Location = new System.Drawing.Point(110, 151);
            this.logicalDataTypeIdComboBoxControl.Name = "logicalDataTypeIdComboBoxControl";
            this.logicalDataTypeIdComboBoxControl.Size = new System.Drawing.Size(287, 23);
            this.logicalDataTypeIdComboBoxControl.TabIndex = 6;
            this.logicalDataTypeIdComboBoxControl.ValueMember = "Id";
            // 
            // logicalTypeFieldLabelControl
            // 
            this.logicalTypeFieldLabelControl.AutoSize = true;
            this.logicalTypeFieldLabelControl.Location = new System.Drawing.Point(12, 154);
            this.logicalTypeFieldLabelControl.Name = "logicalTypeFieldLabelControl";
            this.logicalTypeFieldLabelControl.Size = new System.Drawing.Size(72, 15);
            this.logicalTypeFieldLabelControl.TabIndex = 26;
            this.logicalTypeFieldLabelControl.Text = "Logical Type";
            // 
            // isReqiredBoolControl
            // 
            this.isReqiredBoolControl.AutoSize = true;
            this.isReqiredBoolControl.CamelName = "isRequired";
            this.isReqiredBoolControl.CurrentValue = false;
            this.isReqiredBoolControl.IsReadOnly = false;
            this.isReqiredBoolControl.IsRequired = false;
            this.isReqiredBoolControl.Location = new System.Drawing.Point(110, 209);
            this.isReqiredBoolControl.Name = "isReqiredBoolControl";
            this.isReqiredBoolControl.Size = new System.Drawing.Size(84, 19);
            this.isReqiredBoolControl.TabIndex = 7;
            this.isReqiredBoolControl.Text = "Is Required";
            this.isReqiredBoolControl.UseVisualStyleBackColor = true;
            // 
            // defaultPriorityIntControl
            // 
            this.defaultPriorityIntControl.CamelName = "defaultPriority";
            this.defaultPriorityIntControl.CurrentValue = 0;
            this.defaultPriorityIntControl.IsReadOnly = false;
            this.defaultPriorityIntControl.IsRequired = false;
            this.defaultPriorityIntControl.Location = new System.Drawing.Point(110, 180);
            this.defaultPriorityIntControl.Name = "defaultPriorityIntControl";
            this.defaultPriorityIntControl.Size = new System.Drawing.Size(84, 23);
            this.defaultPriorityIntControl.TabIndex = 27;
            this.defaultPriorityIntControl.ZeroAsNull = false;
            // 
            // defaultPriorityFieldLabelControl
            // 
            this.defaultPriorityFieldLabelControl.AutoSize = true;
            this.defaultPriorityFieldLabelControl.Location = new System.Drawing.Point(12, 184);
            this.defaultPriorityFieldLabelControl.Name = "defaultPriorityFieldLabelControl";
            this.defaultPriorityFieldLabelControl.Size = new System.Drawing.Size(86, 15);
            this.defaultPriorityFieldLabelControl.TabIndex = 28;
            this.defaultPriorityFieldLabelControl.Text = "Default Priority";
            // 
            // DbTableColumnFk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 261);
            this.Controls.Add(this.defaultPriorityFieldLabelControl);
            this.Controls.Add(this.defaultPriorityIntControl);
            this.Controls.Add(this.isReqiredBoolControl);
            this.Controls.Add(this.logicalTypeFieldLabelControl);
            this.Controls.Add(this.logicalDataTypeIdComboBoxControl);
            this.Controls.Add(this.defaultGuiShortNameFieldLabelControl1);
            this.Controls.Add(this.defaultGuiShortNameStringControl);
            this.Controls.Add(this.defaultGuiNameFieldLabelControl1);
            this.Controls.Add(this.defaultGuiNameStringControl);
            this.Controls.Add(this.snakeNameFieldLabelControl);
            this.Controls.Add(this.snakeNameStringControl);
            this.Controls.Add(this.comboBoxControl1);
            this.Controls.Add(this.fkTableFieldLabelControl);
            this.Controls.Add(this.dbTableComboBoxControl);
            this.Controls.Add(this.dbTableFieldLabelControl);
            this.Name = "DbTableColumnFk";
            this.Text = "DbTableColumnFk";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.dbTableFieldLabelControl, 0);
            this.Controls.SetChildIndex(this.dbTableComboBoxControl, 0);
            this.Controls.SetChildIndex(this.fkTableFieldLabelControl, 0);
            this.Controls.SetChildIndex(this.comboBoxControl1, 0);
            this.Controls.SetChildIndex(this.snakeNameStringControl, 0);
            this.Controls.SetChildIndex(this.snakeNameFieldLabelControl, 0);
            this.Controls.SetChildIndex(this.defaultGuiNameStringControl, 0);
            this.Controls.SetChildIndex(this.defaultGuiNameFieldLabelControl1, 0);
            this.Controls.SetChildIndex(this.defaultGuiShortNameStringControl, 0);
            this.Controls.SetChildIndex(this.defaultGuiShortNameFieldLabelControl1, 0);
            this.Controls.SetChildIndex(this.logicalDataTypeIdComboBoxControl, 0);
            this.Controls.SetChildIndex(this.logicalTypeFieldLabelControl, 0);
            this.Controls.SetChildIndex(this.isReqiredBoolControl, 0);
            this.Controls.SetChildIndex(this.defaultPriorityIntControl, 0);
            this.Controls.SetChildIndex(this.defaultPriorityFieldLabelControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.defaultPriorityIntControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lib.GuiCommander.Controls.FieldLabelControl dbTableFieldLabelControl;
        private Lib.GuiCommander.Controls.ComboBoxControl dbTableComboBoxControl;
        private Lib.GuiCommander.Controls.FieldLabelControl fkTableFieldLabelControl;
        private Lib.GuiCommander.Controls.ComboBoxControl comboBoxControl1;
        private Lib.GuiCommander.Controls.StringControl snakeNameStringControl;
        private Lib.GuiCommander.Controls.FieldLabelControl snakeNameFieldLabelControl;
        private Lib.GuiCommander.Controls.StringControl defaultGuiNameStringControl;
        private Lib.GuiCommander.Controls.FieldLabelControl defaultGuiNameFieldLabelControl1;
        private Lib.GuiCommander.Controls.StringControl defaultGuiShortNameStringControl;
        private Lib.GuiCommander.Controls.FieldLabelControl defaultGuiShortNameFieldLabelControl1;
        private Lib.GuiCommander.Controls.ComboBoxControl logicalDataTypeIdComboBoxControl;
        private Lib.GuiCommander.Controls.FieldLabelControl logicalTypeFieldLabelControl;
        private Lib.GuiCommander.BoolControl isReqiredBoolControl;
        private Lib.GuiCommander.Controls.IntControl defaultPriorityIntControl;
        private Lib.GuiCommander.Controls.FieldLabelControl defaultPriorityFieldLabelControl;
    }
}