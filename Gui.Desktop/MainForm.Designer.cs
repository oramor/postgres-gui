namespace Gui.Desktop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDbTableColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDbTableColumnFkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTablePartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablePartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dTOsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLastCommandReport = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuControl1 = new Lib.GuiCommander.Controls.MainMenuControl();
            this.weweweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weweeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mainMenuControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createToolStripMenuItem,
            this.listsToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 24);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            this.mainMenu.Visible = true;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.connectToolStripMenuItem.Text = "Postgres connection";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEntityToolStripMenuItem,
            this.newDbTableColumnToolStripMenuItem,
            this.newDbTableColumnFkToolStripMenuItem,
            this.newTablePartToolStripMenuItem,
            this.newDTOToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // newEntityToolStripMenuItem
            // 
            this.newEntityToolStripMenuItem.Name = "newEntityToolStripMenuItem";
            this.newEntityToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newEntityToolStripMenuItem.Text = "New Entity...";
            this.newEntityToolStripMenuItem.Click += new System.EventHandler(this.newEntityToolStripMenuItem_Click);
            // 
            // newDbTableColumnToolStripMenuItem
            // 
            this.newDbTableColumnToolStripMenuItem.Name = "newDbTableColumnToolStripMenuItem";
            this.newDbTableColumnToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newDbTableColumnToolStripMenuItem.Text = "New DB Table Column...";
            this.newDbTableColumnToolStripMenuItem.Click += new System.EventHandler(this.newEntityColumnToolStripMenuItem_Click);
            // 
            // newDbTableColumnFkToolStripMenuItem
            // 
            this.newDbTableColumnFkToolStripMenuItem.Name = "newDbTableColumnFkToolStripMenuItem";
            this.newDbTableColumnFkToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newDbTableColumnFkToolStripMenuItem.Text = "New DB Table Column (FK)...";
            this.newDbTableColumnFkToolStripMenuItem.Click += new System.EventHandler(this.newDbTableColumnFkToolStripMenuItem_Click);
            // 
            // newTablePartToolStripMenuItem
            // 
            this.newTablePartToolStripMenuItem.Name = "newTablePartToolStripMenuItem";
            this.newTablePartToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newTablePartToolStripMenuItem.Text = "New Table Part....";
            // 
            // newDTOToolStripMenuItem
            // 
            this.newDTOToolStripMenuItem.Name = "newDTOToolStripMenuItem";
            this.newDTOToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newDTOToolStripMenuItem.Text = "New DTO";
            // 
            // listsToolStripMenuItem
            // 
            this.listsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entitiesToolStripMenuItem,
            this.tablePartsToolStripMenuItem,
            this.dTOsToolStripMenuItem});
            this.listsToolStripMenuItem.Name = "listsToolStripMenuItem";
            this.listsToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.listsToolStripMenuItem.Text = "Lists";
            // 
            // entitiesToolStripMenuItem
            // 
            this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            this.entitiesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.entitiesToolStripMenuItem.Text = "Entities";
            this.entitiesToolStripMenuItem.Click += new System.EventHandler(this.entitiesToolStripMenuItem_Click);
            // 
            // tablePartsToolStripMenuItem
            // 
            this.tablePartsToolStripMenuItem.Name = "tablePartsToolStripMenuItem";
            this.tablePartsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.tablePartsToolStripMenuItem.Text = "Table Parts";
            // 
            // dTOsToolStripMenuItem
            // 
            this.dTOsToolStripMenuItem.Name = "dTOsToolStripMenuItem";
            this.dTOsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.dTOsToolStripMenuItem.Text = "DTOs";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLastCommandReport});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLastCommandReport
            // 
            this.toolStripStatusLastCommandReport.Name = "toolStripStatusLastCommandReport";
            this.toolStripStatusLastCommandReport.Size = new System.Drawing.Size(197, 17);
            this.toolStripStatusLastCommandReport.Text = "toolStripStatusLastCommandReport";
            // 
            // mainMenuControl1
            // 
            this.mainMenuControl1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weweweToolStripMenuItem});
            this.mainMenuControl1.Location = new System.Drawing.Point(0, 0);
            this.mainMenuControl1.Name = "mainMenuControl1";
            this.mainMenuControl1.Size = new System.Drawing.Size(800, 24);
            this.mainMenuControl1.TabIndex = 2;
            this.mainMenuControl1.Text = "mainMenuControl1";
            // 
            // weweweToolStripMenuItem
            // 
            this.weweweToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weweeToolStripMenuItem});
            this.weweweToolStripMenuItem.Name = "weweweToolStripMenuItem";
            this.weweweToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.weweweToolStripMenuItem.Text = "wewewe";
            // 
            // weweeToolStripMenuItem
            // 
            this.weweeToolStripMenuItem.Name = "weweeToolStripMenuItem";
            this.weweeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.weweeToolStripMenuItem.Text = "wewee";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.mainMenuControl1);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Postgres Gui";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainMenuControl1.ResumeLayout(false);
            this.mainMenuControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem createToolStripMenuItem;
        private ToolStripMenuItem listsToolStripMenuItem;
        private ToolStripMenuItem windowsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem newEntityToolStripMenuItem;
        private ToolStripMenuItem newTablePartToolStripMenuItem;
        private ToolStripMenuItem newDTOToolStripMenuItem;
        private ToolStripMenuItem entitiesToolStripMenuItem;
        private ToolStripMenuItem tablePartsToolStripMenuItem;
        private ToolStripMenuItem dTOsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLastCommandReport;
        private ToolStripMenuItem newDbTableColumnToolStripMenuItem;
        private ToolStripMenuItem newDbTableColumnFkToolStripMenuItem;
        private Lib.GuiCommander.Controls.MainMenuControl mainMenuControl1;
        private ToolStripMenuItem weweweToolStripMenuItem;
        private ToolStripMenuItem weweeToolStripMenuItem;
    }
}