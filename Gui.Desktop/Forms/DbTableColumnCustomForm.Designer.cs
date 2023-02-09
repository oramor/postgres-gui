namespace Gui.Desktop.Forms
{
    partial class DbTableColumnCustomForm
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
            this.dbTableLabel = new System.Windows.Forms.Label();
            this.snakeNameStringControl = new Lib.GuiCommander.Controls.StringControl();
            this.snakeNameLabel = new System.Windows.Forms.Label();
            this.guiNameStringControl = new Lib.GuiCommander.Controls.StringControl();
            this.guiNameLabel = new System.Windows.Forms.Label();
            this.guiShortNameStringControl = new Lib.GuiCommander.Controls.StringControl();
            this.guiShortNameLabel = new System.Windows.Forms.Label();
            this.logicalDataTypeLabel = new System.Windows.Forms.Label();
            this.isRequiredBoolControl = new Lib.GuiCommander.BoolControl();
            this.defaultPriorityLabel = new System.Windows.Forms.Label();
            this.defaultSizeLabel = new System.Windows.Forms.Label();
            this.logicalTypeComboBoxControl = new Lib.GuiCommander.Controls.ComboBoxControl();
            this.dbTableComboBoxControl = new Lib.GuiCommander.Controls.ComboBoxControl();
            this.defaultPriorityIntControl = new Lib.GuiCommander.Controls.IntControl();
            this.defaultSizeIntControl = new Lib.GuiCommander.Controls.IntControl();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPriorityIntControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultSizeIntControl)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(322, 246);
            this.saveButton.TabIndex = 9;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(241, 246);
            this.closeButton.TabIndex = 10;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(160, 246);
            // 
            // dbTableLabel
            // 
            this.dbTableLabel.AutoSize = true;
            this.dbTableLabel.Location = new System.Drawing.Point(12, 15);
            this.dbTableLabel.Name = "dbTableLabel";
            this.dbTableLabel.Size = new System.Drawing.Size(57, 15);
            this.dbTableLabel.TabIndex = 20;
            this.dbTableLabel.Text = "DB Table*";
            // 
            // snakeNameStringControl
            // 
            this.snakeNameStringControl.BackColor = System.Drawing.Color.LightYellow;
            this.snakeNameStringControl.BindingName = "snakeName";
            this.snakeNameStringControl.CurrentValue = "";
            this.snakeNameStringControl.IsReadOnly = false;
            this.snakeNameStringControl.IsRequired = true;
            this.snakeNameStringControl.Length = 32767;
            this.snakeNameStringControl.Location = new System.Drawing.Point(113, 41);
            this.snakeNameStringControl.Name = "snakeNameStringControl";
            this.snakeNameStringControl.Size = new System.Drawing.Size(284, 23);
            this.snakeNameStringControl.TabIndex = 2;
            // 
            // snakeNameLabel
            // 
            this.snakeNameLabel.AutoSize = true;
            this.snakeNameLabel.Location = new System.Drawing.Point(12, 44);
            this.snakeNameLabel.Name = "snakeNameLabel";
            this.snakeNameLabel.Size = new System.Drawing.Size(78, 15);
            this.snakeNameLabel.TabIndex = 21;
            this.snakeNameLabel.Text = "Snake Name*";
            // 
            // guiNameStringControl
            // 
            this.guiNameStringControl.BackColor = System.Drawing.Color.LightYellow;
            this.guiNameStringControl.BindingName = "defaultGuiName";
            this.guiNameStringControl.CurrentValue = "";
            this.guiNameStringControl.IsReadOnly = false;
            this.guiNameStringControl.IsRequired = true;
            this.guiNameStringControl.Length = 32767;
            this.guiNameStringControl.Location = new System.Drawing.Point(113, 70);
            this.guiNameStringControl.Name = "guiNameStringControl";
            this.guiNameStringControl.Size = new System.Drawing.Size(284, 23);
            this.guiNameStringControl.TabIndex = 3;
            // 
            // guiNameLabel
            // 
            this.guiNameLabel.AutoSize = true;
            this.guiNameLabel.Location = new System.Drawing.Point(12, 73);
            this.guiNameLabel.Name = "guiNameLabel";
            this.guiNameLabel.Size = new System.Drawing.Size(66, 15);
            this.guiNameLabel.TabIndex = 22;
            this.guiNameLabel.Text = "GUI Name*";
            // 
            // guiShortNameStringControl
            // 
            this.guiShortNameStringControl.BackColor = System.Drawing.Color.LightYellow;
            this.guiShortNameStringControl.BindingName = "defaultGuiShortName";
            this.guiShortNameStringControl.CurrentValue = "";
            this.guiShortNameStringControl.IsReadOnly = false;
            this.guiShortNameStringControl.IsRequired = true;
            this.guiShortNameStringControl.Length = 32767;
            this.guiShortNameStringControl.Location = new System.Drawing.Point(113, 99);
            this.guiShortNameStringControl.Name = "guiShortNameStringControl";
            this.guiShortNameStringControl.Size = new System.Drawing.Size(284, 23);
            this.guiShortNameStringControl.TabIndex = 4;
            // 
            // guiShortNameLabel
            // 
            this.guiShortNameLabel.AutoSize = true;
            this.guiShortNameLabel.Location = new System.Drawing.Point(12, 102);
            this.guiShortNameLabel.Name = "guiShortNameLabel";
            this.guiShortNameLabel.Size = new System.Drawing.Size(92, 15);
            this.guiShortNameLabel.TabIndex = 23;
            this.guiShortNameLabel.Text = "GUI Short Name";
            // 
            // logicalDataTypeLabel
            // 
            this.logicalDataTypeLabel.AutoSize = true;
            this.logicalDataTypeLabel.Location = new System.Drawing.Point(12, 131);
            this.logicalDataTypeLabel.Name = "logicalDataTypeLabel";
            this.logicalDataTypeLabel.Size = new System.Drawing.Size(77, 15);
            this.logicalDataTypeLabel.TabIndex = 24;
            this.logicalDataTypeLabel.Text = "Logical Type*";
            // 
            // isRequiredBoolControl
            // 
            this.isRequiredBoolControl.AutoSize = true;
            this.isRequiredBoolControl.BindingName = "isRequired";
            this.isRequiredBoolControl.CurrentValue = false;
            this.isRequiredBoolControl.IsReadOnly = false;
            this.isRequiredBoolControl.IsRequired = false;
            this.isRequiredBoolControl.Location = new System.Drawing.Point(113, 216);
            this.isRequiredBoolControl.Name = "isRequiredBoolControl";
            this.isRequiredBoolControl.Size = new System.Drawing.Size(84, 19);
            this.isRequiredBoolControl.TabIndex = 8;
            this.isRequiredBoolControl.Text = "Is Required";
            this.isRequiredBoolControl.UseVisualStyleBackColor = true;
            // 
            // defaultPriorityLabel
            // 
            this.defaultPriorityLabel.AutoSize = true;
            this.defaultPriorityLabel.Location = new System.Drawing.Point(12, 161);
            this.defaultPriorityLabel.Name = "defaultPriorityLabel";
            this.defaultPriorityLabel.Size = new System.Drawing.Size(91, 15);
            this.defaultPriorityLabel.TabIndex = 26;
            this.defaultPriorityLabel.Text = "Default priority*";
            // 
            // defaultSizeLabel
            // 
            this.defaultSizeLabel.AutoSize = true;
            this.defaultSizeLabel.Location = new System.Drawing.Point(12, 191);
            this.defaultSizeLabel.Name = "defaultSizeLabel";
            this.defaultSizeLabel.Size = new System.Drawing.Size(73, 15);
            this.defaultSizeLabel.TabIndex = 27;
            this.defaultSizeLabel.Text = "Default Size*";
            // 
            // logicalTypeComboBoxControl
            // 
            this.logicalTypeComboBoxControl.BackColor = System.Drawing.Color.LightYellow;
            this.logicalTypeComboBoxControl.BindingName = "logicalDataTypeId";
            this.logicalTypeComboBoxControl.CurrentValue = null;
            this.logicalTypeComboBoxControl.DataSourceRoutine = null;
            this.logicalTypeComboBoxControl.DisplayMember = "DisplayMember";
            this.logicalTypeComboBoxControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logicalTypeComboBoxControl.FormattingEnabled = true;
            this.logicalTypeComboBoxControl.IsReadOnly = false;
            this.logicalTypeComboBoxControl.IsRequired = true;
            this.logicalTypeComboBoxControl.Location = new System.Drawing.Point(113, 128);
            this.logicalTypeComboBoxControl.Name = "logicalTypeComboBoxControl";
            this.logicalTypeComboBoxControl.Size = new System.Drawing.Size(284, 23);
            this.logicalTypeComboBoxControl.TabIndex = 5;
            this.logicalTypeComboBoxControl.ValueMember = "ValueMember";
            // 
            // dbTableComboBoxControl
            // 
            this.dbTableComboBoxControl.BackColor = System.Drawing.Color.LightYellow;
            this.dbTableComboBoxControl.BindingName = "dbTableId";
            this.dbTableComboBoxControl.CurrentValue = null;
            this.dbTableComboBoxControl.DataSourceRoutine = null;
            this.dbTableComboBoxControl.DisplayMember = "Title";
            this.dbTableComboBoxControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbTableComboBoxControl.FormattingEnabled = true;
            this.dbTableComboBoxControl.IsReadOnly = false;
            this.dbTableComboBoxControl.IsRequired = true;
            this.dbTableComboBoxControl.Location = new System.Drawing.Point(113, 12);
            this.dbTableComboBoxControl.Name = "dbTableComboBoxControl";
            this.dbTableComboBoxControl.Size = new System.Drawing.Size(284, 23);
            this.dbTableComboBoxControl.TabIndex = 1;
            this.dbTableComboBoxControl.ValueMember = "Id";
            // 
            // defaultPriorityIntControl
            // 
            this.defaultPriorityIntControl.BackColor = System.Drawing.Color.LightYellow;
            this.defaultPriorityIntControl.BindingName = "defaultPriority";
            this.defaultPriorityIntControl.CurrentValue = null;
            this.defaultPriorityIntControl.IsReadOnly = false;
            this.defaultPriorityIntControl.IsRequired = true;
            this.defaultPriorityIntControl.Location = new System.Drawing.Point(113, 158);
            this.defaultPriorityIntControl.Name = "defaultPriorityIntControl";
            this.defaultPriorityIntControl.Size = new System.Drawing.Size(84, 23);
            this.defaultPriorityIntControl.TabIndex = 6;
            this.defaultPriorityIntControl.ZeroAsNull = true;
            // 
            // defaultSizeIntControl
            // 
            this.defaultSizeIntControl.BackColor = System.Drawing.Color.White;
            this.defaultSizeIntControl.BindingName = "defaultSize";
            this.defaultSizeIntControl.CurrentValue = 0;
            this.defaultSizeIntControl.IsReadOnly = false;
            this.defaultSizeIntControl.IsRequired = false;
            this.defaultSizeIntControl.Location = new System.Drawing.Point(113, 187);
            this.defaultSizeIntControl.Name = "defaultSizeIntControl";
            this.defaultSizeIntControl.Size = new System.Drawing.Size(84, 23);
            this.defaultSizeIntControl.TabIndex = 7;
            this.defaultSizeIntControl.ZeroAsNull = false;
            // 
            // DbTableColumnCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 281);
            this.Controls.Add(this.defaultSizeIntControl);
            this.Controls.Add(this.defaultPriorityIntControl);
            this.Controls.Add(this.dbTableComboBoxControl);
            this.Controls.Add(this.logicalTypeComboBoxControl);
            this.Controls.Add(this.defaultSizeLabel);
            this.Controls.Add(this.defaultPriorityLabel);
            this.Controls.Add(this.isRequiredBoolControl);
            this.Controls.Add(this.logicalDataTypeLabel);
            this.Controls.Add(this.guiShortNameLabel);
            this.Controls.Add(this.guiShortNameStringControl);
            this.Controls.Add(this.guiNameLabel);
            this.Controls.Add(this.guiNameStringControl);
            this.Controls.Add(this.snakeNameLabel);
            this.Controls.Add(this.snakeNameStringControl);
            this.Controls.Add(this.dbTableLabel);
            this.Name = "DbTableColumnCustom";
            this.Text = "EntityColumnForm";
            this.Controls.SetChildIndex(this.deleteButton, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.dbTableLabel, 0);
            this.Controls.SetChildIndex(this.snakeNameStringControl, 0);
            this.Controls.SetChildIndex(this.snakeNameLabel, 0);
            this.Controls.SetChildIndex(this.guiNameStringControl, 0);
            this.Controls.SetChildIndex(this.guiNameLabel, 0);
            this.Controls.SetChildIndex(this.guiShortNameStringControl, 0);
            this.Controls.SetChildIndex(this.guiShortNameLabel, 0);
            this.Controls.SetChildIndex(this.logicalDataTypeLabel, 0);
            this.Controls.SetChildIndex(this.isRequiredBoolControl, 0);
            this.Controls.SetChildIndex(this.defaultPriorityLabel, 0);
            this.Controls.SetChildIndex(this.defaultSizeLabel, 0);
            this.Controls.SetChildIndex(this.logicalTypeComboBoxControl, 0);
            this.Controls.SetChildIndex(this.dbTableComboBoxControl, 0);
            this.Controls.SetChildIndex(this.defaultPriorityIntControl, 0);
            this.Controls.SetChildIndex(this.defaultSizeIntControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.defaultPriorityIntControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultSizeIntControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label dbTableLabel;
        private Lib.GuiCommander.Controls.StringControl snakeNameStringControl;
        private Label snakeNameLabel;
        private Lib.GuiCommander.Controls.StringControl guiNameStringControl;
        private Label guiNameLabel;
        private Lib.GuiCommander.Controls.StringControl guiShortNameStringControl;
        private Label guiShortNameLabel;
        private Label logicalDataTypeLabel;
        private Lib.GuiCommander.BoolControl isRequiredBoolControl;
        private Label defaultPriorityLabel;
        private Label defaultSizeLabel;
        private Lib.GuiCommander.Controls.ComboBoxControl logicalTypeComboBoxControl;
        private Lib.GuiCommander.Controls.ComboBoxControl dbTableComboBoxControl;
        private Lib.GuiCommander.Controls.IntControl defaultPriorityIntControl;
        private Lib.GuiCommander.Controls.IntControl defaultSizeIntControl;
    }
}