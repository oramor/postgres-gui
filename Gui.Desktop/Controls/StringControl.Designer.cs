﻿namespace Gui.Desktop.Controls
{
    partial class StringControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //components = new System.ComponentModel.Container();
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.SuspendLayout();
            // 
            // StringControl
            // 
            this.Size = new System.Drawing.Size(250, 20);
            this.TextChanged += new System.EventHandler(this.StringControl_TextChanged);
            this.Enter += new System.EventHandler(this.StringControl_Enter);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
