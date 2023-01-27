namespace Gui.Desktop.Forms
{
    partial class EntityColumnForm
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
            this.entityLabel = new System.Windows.Forms.Label();
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
            this.entityComboBoxControl = new Lib.GuiCommander.Controls.ComboBoxControl();
            this.defaultPriorityIntControl = new Lib.GuiCommander.Controls.IntControl();
            this.defaultSizeIntControl = new Lib.GuiCommander.Controls.IntControl();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPriorityIntControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultSizeIntControl)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(267, 246);
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(186, 246);
            // 
            // entityLabel
            // 
            this.entityLabel.AutoSize = true;
            this.entityLabel.Location = new System.Drawing.Point(12, 15);
            this.entityLabel.Name = "entityLabel";
            this.entityLabel.Size = new System.Drawing.Size(42, 15);
            this.entityLabel.TabIndex = 20;
            this.entityLabel.Text = "Entity*";
            // 
            // snakeNameStringControl
            // 
            this.snakeNameStringControl.BackColor = System.Drawing.Color.White;
            this.snakeNameStringControl.CamelName = "snakeName";
            this.snakeNameStringControl.IsReadOnly = false;
            this.snakeNameStringControl.IsRequired = false;
            this.snakeNameStringControl.Length = 32767;
            this.snakeNameStringControl.Location = new System.Drawing.Point(113, 41);
            this.snakeNameStringControl.Name = "snakeNameStringControl";
            this.snakeNameStringControl.Size = new System.Drawing.Size(229, 23);
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
            this.guiNameStringControl.BackColor = System.Drawing.Color.White;
            this.guiNameStringControl.CamelName = "defaultGuiName";
            this.guiNameStringControl.IsReadOnly = false;
            this.guiNameStringControl.IsRequired = false;
            this.guiNameStringControl.Length = 32767;
            this.guiNameStringControl.Location = new System.Drawing.Point(113, 70);
            this.guiNameStringControl.Name = "guiNameStringControl";
            this.guiNameStringControl.Size = new System.Drawing.Size(229, 23);
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
            this.guiShortNameStringControl.BackColor = System.Drawing.Color.White;
            this.guiShortNameStringControl.CamelName = "defaultGuiShortName";
            this.guiShortNameStringControl.IsReadOnly = false;
            this.guiShortNameStringControl.IsRequired = false;
            this.guiShortNameStringControl.Length = 32767;
            this.guiShortNameStringControl.Location = new System.Drawing.Point(113, 99);
            this.guiShortNameStringControl.Name = "guiShortNameStringControl";
            this.guiShortNameStringControl.Size = new System.Drawing.Size(229, 23);
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
            this.isRequiredBoolControl.CamelName = "isRequired";
            this.isRequiredBoolControl.Id = -1;
            this.isRequiredBoolControl.IsReadOnly = false;
            this.isRequiredBoolControl.IsRequired = false;
            this.isRequiredBoolControl.Location = new System.Drawing.Point(113, 216);
            this.isRequiredBoolControl.Name = "isRequiredBoolControl";
            this.isRequiredBoolControl.Size = new System.Drawing.Size(84, 19);
            this.isRequiredBoolControl.TabIndex = 6;
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
            this.logicalTypeComboBoxControl.BackColor = System.Drawing.Color.White;
            this.logicalTypeComboBoxControl.CamelName = "logicalDataType";
            this.logicalTypeComboBoxControl.DataSourceRoutine = null;
            this.logicalTypeComboBoxControl.DisplayMember = "DisplayMember";
            this.logicalTypeComboBoxControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logicalTypeComboBoxControl.FormattingEnabled = true;
            this.logicalTypeComboBoxControl.IsReadOnly = false;
            this.logicalTypeComboBoxControl.IsRequired = false;
            this.logicalTypeComboBoxControl.Location = new System.Drawing.Point(113, 128);
            this.logicalTypeComboBoxControl.Name = "logicalTypeComboBoxControl";
            this.logicalTypeComboBoxControl.Size = new System.Drawing.Size(229, 23);
            this.logicalTypeComboBoxControl.TabIndex = 5;
            this.logicalTypeComboBoxControl.ValueMember = "ValueMember";
            // 
            // entityComboBoxControl
            // 
            this.entityComboBoxControl.BackColor = System.Drawing.Color.White;
            this.entityComboBoxControl.CamelName = "entityId";
            this.entityComboBoxControl.DataSourceRoutine = null;
            this.entityComboBoxControl.DisplayMember = "Title";
            this.entityComboBoxControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entityComboBoxControl.FormattingEnabled = true;
            this.entityComboBoxControl.IsReadOnly = false;
            this.entityComboBoxControl.IsRequired = false;
            this.entityComboBoxControl.Location = new System.Drawing.Point(113, 12);
            this.entityComboBoxControl.Name = "entityComboBoxControl";
            this.entityComboBoxControl.Size = new System.Drawing.Size(229, 23);
            this.entityComboBoxControl.TabIndex = 1;
            this.entityComboBoxControl.ValueMember = "Id";
            // 
            // defaultPriorityIntControl
            // 
            this.defaultPriorityIntControl.CamelName = "defaultPriority";
            this.defaultPriorityIntControl.IsReadOnly = false;
            this.defaultPriorityIntControl.IsRequired = false;
            this.defaultPriorityIntControl.Location = new System.Drawing.Point(113, 158);
            this.defaultPriorityIntControl.Name = "defaultPriorityIntControl";
            this.defaultPriorityIntControl.Size = new System.Drawing.Size(84, 23);
            this.defaultPriorityIntControl.TabIndex = 6;
            this.defaultPriorityIntControl.ZeroAsNull = false;
            // 
            // defaultSizeIntControl
            // 
            this.defaultSizeIntControl.CamelName = "defaultSize";
            this.defaultSizeIntControl.IsReadOnly = false;
            this.defaultSizeIntControl.IsRequired = false;
            this.defaultSizeIntControl.Location = new System.Drawing.Point(113, 187);
            this.defaultSizeIntControl.Name = "defaultSizeIntControl";
            this.defaultSizeIntControl.Size = new System.Drawing.Size(84, 23);
            this.defaultSizeIntControl.TabIndex = 7;
            this.defaultSizeIntControl.ZeroAsNull = false;
            // 
            // EntityColumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 281);
            this.Controls.Add(this.defaultSizeIntControl);
            this.Controls.Add(this.defaultPriorityIntControl);
            this.Controls.Add(this.entityComboBoxControl);
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
            this.Controls.Add(this.entityLabel);
            this.Name = "EntityColumnForm";
            this.Text = "EntityColumnForm";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.entityLabel, 0);
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
            this.Controls.SetChildIndex(this.entityComboBoxControl, 0);
            this.Controls.SetChildIndex(this.defaultPriorityIntControl, 0);
            this.Controls.SetChildIndex(this.defaultSizeIntControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.defaultPriorityIntControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultSizeIntControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label entityLabel;
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
        private Lib.GuiCommander.Controls.ComboBoxControl entityComboBoxControl;
        private Lib.GuiCommander.Controls.IntControl defaultPriorityIntControl;
        private Lib.GuiCommander.Controls.IntControl defaultSizeIntControl;
    }
}