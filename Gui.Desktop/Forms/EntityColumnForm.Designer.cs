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
            this.label1 = new System.Windows.Forms.Label();
            this.stringControlSnakeName = new Lib.GuiCommander.Controls.StringControl();
            this.labelSnakeName = new System.Windows.Forms.Label();
            this.stringControlGuiName = new Lib.GuiCommander.Controls.StringControl();
            this.labelGuiName = new System.Windows.Forms.Label();
            this.stringControlGuiShortName = new Lib.GuiCommander.Controls.StringControl();
            this.labelGuiShortName = new System.Windows.Forms.Label();
            this.labelLogicalDataType = new System.Windows.Forms.Label();
            this.boolControlIsRequired = new Lib.GuiCommander.BoolControl();
            this.numericControlDefaultPriority = new Lib.GuiCommander.Controls.NumericControl();
            this.labelDefaultPriority = new System.Windows.Forms.Label();
            this.labelDefaultSize = new System.Windows.Forms.Label();
            this.numericControlDefaultSize = new Lib.GuiCommander.Controls.NumericControl();
            this.comboBoxControlLogicalType = new Lib.GuiCommander.Controls.ComboBoxControl();
            this.comboBoxControlEntity = new Lib.GuiCommander.Controls.ComboBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.numericControlDefaultPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericControlDefaultSize)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Entity*";
            // 
            // stringControlSnakeName
            // 
            this.stringControlSnakeName.BackColor = System.Drawing.Color.White;
            this.stringControlSnakeName.ColumnName = null;
            this.stringControlSnakeName.IsReadOnly = false;
            this.stringControlSnakeName.IsRequired = false;
            this.stringControlSnakeName.Length = 32767;
            this.stringControlSnakeName.Location = new System.Drawing.Point(113, 41);
            this.stringControlSnakeName.Name = "stringControlSnakeName";
            this.stringControlSnakeName.Size = new System.Drawing.Size(229, 23);
            this.stringControlSnakeName.TabIndex = 2;
            // 
            // labelSnakeName
            // 
            this.labelSnakeName.AutoSize = true;
            this.labelSnakeName.Location = new System.Drawing.Point(12, 44);
            this.labelSnakeName.Name = "labelSnakeName";
            this.labelSnakeName.Size = new System.Drawing.Size(78, 15);
            this.labelSnakeName.TabIndex = 21;
            this.labelSnakeName.Text = "Snake Name*";
            // 
            // stringControlGuiName
            // 
            this.stringControlGuiName.BackColor = System.Drawing.Color.White;
            this.stringControlGuiName.ColumnName = null;
            this.stringControlGuiName.IsReadOnly = false;
            this.stringControlGuiName.IsRequired = false;
            this.stringControlGuiName.Length = 32767;
            this.stringControlGuiName.Location = new System.Drawing.Point(113, 70);
            this.stringControlGuiName.Name = "stringControlGuiName";
            this.stringControlGuiName.Size = new System.Drawing.Size(229, 23);
            this.stringControlGuiName.TabIndex = 3;
            // 
            // labelGuiName
            // 
            this.labelGuiName.AutoSize = true;
            this.labelGuiName.Location = new System.Drawing.Point(12, 73);
            this.labelGuiName.Name = "labelGuiName";
            this.labelGuiName.Size = new System.Drawing.Size(66, 15);
            this.labelGuiName.TabIndex = 22;
            this.labelGuiName.Text = "GUI Name*";
            // 
            // stringControlGuiShortName
            // 
            this.stringControlGuiShortName.BackColor = System.Drawing.Color.White;
            this.stringControlGuiShortName.ColumnName = null;
            this.stringControlGuiShortName.IsReadOnly = false;
            this.stringControlGuiShortName.IsRequired = false;
            this.stringControlGuiShortName.Length = 32767;
            this.stringControlGuiShortName.Location = new System.Drawing.Point(113, 99);
            this.stringControlGuiShortName.Name = "stringControlGuiShortName";
            this.stringControlGuiShortName.Size = new System.Drawing.Size(229, 23);
            this.stringControlGuiShortName.TabIndex = 4;
            // 
            // labelGuiShortName
            // 
            this.labelGuiShortName.AutoSize = true;
            this.labelGuiShortName.Location = new System.Drawing.Point(12, 102);
            this.labelGuiShortName.Name = "labelGuiShortName";
            this.labelGuiShortName.Size = new System.Drawing.Size(92, 15);
            this.labelGuiShortName.TabIndex = 23;
            this.labelGuiShortName.Text = "GUI Short Name";
            // 
            // labelLogicalDataType
            // 
            this.labelLogicalDataType.AutoSize = true;
            this.labelLogicalDataType.Location = new System.Drawing.Point(12, 131);
            this.labelLogicalDataType.Name = "labelLogicalDataType";
            this.labelLogicalDataType.Size = new System.Drawing.Size(77, 15);
            this.labelLogicalDataType.TabIndex = 24;
            this.labelLogicalDataType.Text = "Logical Type*";
            // 
            // boolControlIsRequired
            // 
            this.boolControlIsRequired.AutoSize = true;
            this.boolControlIsRequired.ColumnName = null;
            this.boolControlIsRequired.Id = -1;
            this.boolControlIsRequired.IsReadOnly = false;
            this.boolControlIsRequired.IsRequired = false;
            this.boolControlIsRequired.Location = new System.Drawing.Point(113, 216);
            this.boolControlIsRequired.Name = "boolControlIsRequired";
            this.boolControlIsRequired.Size = new System.Drawing.Size(84, 19);
            this.boolControlIsRequired.TabIndex = 6;
            this.boolControlIsRequired.Text = "Is Required";
            this.boolControlIsRequired.UseVisualStyleBackColor = true;
            // 
            // numericControlDefaultPriority
            // 
            this.numericControlDefaultPriority.BackColor = System.Drawing.Color.White;
            this.numericControlDefaultPriority.ColumnName = "";
            this.numericControlDefaultPriority.IsReadOnly = false;
            this.numericControlDefaultPriority.IsRequired = false;
            this.numericControlDefaultPriority.JsonName = "";
            this.numericControlDefaultPriority.Location = new System.Drawing.Point(113, 157);
            this.numericControlDefaultPriority.Name = "numericControlDefaultPriority";
            this.numericControlDefaultPriority.Size = new System.Drawing.Size(84, 23);
            this.numericControlDefaultPriority.TabIndex = 25;
            // 
            // labelDefaultPriority
            // 
            this.labelDefaultPriority.AutoSize = true;
            this.labelDefaultPriority.Location = new System.Drawing.Point(12, 161);
            this.labelDefaultPriority.Name = "labelDefaultPriority";
            this.labelDefaultPriority.Size = new System.Drawing.Size(91, 15);
            this.labelDefaultPriority.TabIndex = 26;
            this.labelDefaultPriority.Text = "Default priority*";
            // 
            // labelDefaultSize
            // 
            this.labelDefaultSize.AutoSize = true;
            this.labelDefaultSize.Location = new System.Drawing.Point(12, 191);
            this.labelDefaultSize.Name = "labelDefaultSize";
            this.labelDefaultSize.Size = new System.Drawing.Size(73, 15);
            this.labelDefaultSize.TabIndex = 27;
            this.labelDefaultSize.Text = "Default Size*";
            // 
            // numericControlDefaultSize
            // 
            this.numericControlDefaultSize.BackColor = System.Drawing.Color.White;
            this.numericControlDefaultSize.ColumnName = "";
            this.numericControlDefaultSize.IsReadOnly = false;
            this.numericControlDefaultSize.IsRequired = false;
            this.numericControlDefaultSize.JsonName = "";
            this.numericControlDefaultSize.Location = new System.Drawing.Point(113, 187);
            this.numericControlDefaultSize.Name = "numericControlDefaultSize";
            this.numericControlDefaultSize.Size = new System.Drawing.Size(84, 23);
            this.numericControlDefaultSize.TabIndex = 7;
            // 
            // comboBoxControlLogicalType
            // 
            this.comboBoxControlLogicalType.BackColor = System.Drawing.Color.White;
            this.comboBoxControlLogicalType.ColumnName = "";
            this.comboBoxControlLogicalType.DataSourceRoutine = null;
            this.comboBoxControlLogicalType.DisplayMember = "DisplayMember";
            this.comboBoxControlLogicalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxControlLogicalType.FormattingEnabled = true;
            this.comboBoxControlLogicalType.IsReadOnly = false;
            this.comboBoxControlLogicalType.IsRequired = false;
            this.comboBoxControlLogicalType.JsonName = "";
            this.comboBoxControlLogicalType.Location = new System.Drawing.Point(113, 128);
            this.comboBoxControlLogicalType.Name = "comboBoxControlLogicalType";
            this.comboBoxControlLogicalType.Size = new System.Drawing.Size(229, 23);
            this.comboBoxControlLogicalType.TabIndex = 5;
            this.comboBoxControlLogicalType.ValueMember = "ValueMember";
            // 
            // comboBoxControlEntity
            // 
            this.comboBoxControlEntity.ColumnName = "";
            this.comboBoxControlEntity.DataSourceRoutine = null;
            this.comboBoxControlEntity.DisplayMember = "Title";
            this.comboBoxControlEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxControlEntity.FormattingEnabled = true;
            this.comboBoxControlEntity.IsReadOnly = false;
            this.comboBoxControlEntity.IsRequired = false;
            this.comboBoxControlEntity.JsonName = "";
            this.comboBoxControlEntity.Location = new System.Drawing.Point(113, 12);
            this.comboBoxControlEntity.Name = "comboBoxControlEntity";
            this.comboBoxControlEntity.Size = new System.Drawing.Size(229, 23);
            this.comboBoxControlEntity.TabIndex = 1;
            this.comboBoxControlEntity.ValueMember = "Id";
            // 
            // EntityColumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 281);
            this.Controls.Add(this.comboBoxControlEntity);
            this.Controls.Add(this.comboBoxControlLogicalType);
            this.Controls.Add(this.numericControlDefaultSize);
            this.Controls.Add(this.labelDefaultSize);
            this.Controls.Add(this.labelDefaultPriority);
            this.Controls.Add(this.numericControlDefaultPriority);
            this.Controls.Add(this.boolControlIsRequired);
            this.Controls.Add(this.labelLogicalDataType);
            this.Controls.Add(this.labelGuiShortName);
            this.Controls.Add(this.stringControlGuiShortName);
            this.Controls.Add(this.labelGuiName);
            this.Controls.Add(this.stringControlGuiName);
            this.Controls.Add(this.labelSnakeName);
            this.Controls.Add(this.stringControlSnakeName);
            this.Controls.Add(this.label1);
            this.Name = "EntityColumnForm";
            this.Text = "EntityColumnForm";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.stringControlSnakeName, 0);
            this.Controls.SetChildIndex(this.labelSnakeName, 0);
            this.Controls.SetChildIndex(this.stringControlGuiName, 0);
            this.Controls.SetChildIndex(this.labelGuiName, 0);
            this.Controls.SetChildIndex(this.stringControlGuiShortName, 0);
            this.Controls.SetChildIndex(this.labelGuiShortName, 0);
            this.Controls.SetChildIndex(this.labelLogicalDataType, 0);
            this.Controls.SetChildIndex(this.boolControlIsRequired, 0);
            this.Controls.SetChildIndex(this.numericControlDefaultPriority, 0);
            this.Controls.SetChildIndex(this.labelDefaultPriority, 0);
            this.Controls.SetChildIndex(this.labelDefaultSize, 0);
            this.Controls.SetChildIndex(this.numericControlDefaultSize, 0);
            this.Controls.SetChildIndex(this.comboBoxControlLogicalType, 0);
            this.Controls.SetChildIndex(this.comboBoxControlEntity, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericControlDefaultPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericControlDefaultSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Lib.GuiCommander.Controls.StringControl stringControlSnakeName;
        private Label labelSnakeName;
        private Lib.GuiCommander.Controls.StringControl stringControlGuiName;
        private Label labelGuiName;
        private Lib.GuiCommander.Controls.StringControl stringControlGuiShortName;
        private Label labelGuiShortName;
        private Label labelLogicalDataType;
        private Lib.GuiCommander.BoolControl boolControlIsRequired;
        private Lib.GuiCommander.Controls.NumericControl numericControlDefaultPriority;
        private Label labelDefaultPriority;
        private Label labelDefaultSize;
        private Lib.GuiCommander.Controls.NumericControl numericControlDefaultSize;
        private Lib.GuiCommander.Controls.ComboBoxControl comboBoxControlLogicalType;
        private Lib.GuiCommander.Controls.ComboBoxControl comboBoxControlEntity;
    }
}