
namespace SimpleVectorGraphicViewer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPresetShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetViewzoomLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plot1 = new SimpleVectorGraphicViewer.Plan();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 727);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(838, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 20);
            this.toolStripStatusLabel1.Text = "Pointer: 0, 0";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShowShortcutKeys = false;
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.loadToolStripMenuItem.Text = "Load file";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleWindowToolStripMenuItem,
            this.showPresetShapesToolStripMenuItem,
            this.clearGraphToolStripMenuItem,
            this.resetViewzoomLevelToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // scaleWindowToolStripMenuItem
            // 
            this.scaleWindowToolStripMenuItem.Checked = true;
            this.scaleWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scaleWindowToolStripMenuItem.Name = "scaleWindowToolStripMenuItem";
            this.scaleWindowToolStripMenuItem.ShowShortcutKeys = false;
            this.scaleWindowToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.scaleWindowToolStripMenuItem.Text = "Scale with window";
            this.scaleWindowToolStripMenuItem.Click += new System.EventHandler(this.scaleWindowToolStripMenuItem_Click);
            // 
            // showPresetShapesToolStripMenuItem
            // 
            this.showPresetShapesToolStripMenuItem.Name = "showPresetShapesToolStripMenuItem";
            this.showPresetShapesToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.showPresetShapesToolStripMenuItem.Text = "Show preset shapes";
            this.showPresetShapesToolStripMenuItem.Click += new System.EventHandler(this.showPresetShapesToolStripMenuItem_Click);
            // 
            // clearGraphToolStripMenuItem
            // 
            this.clearGraphToolStripMenuItem.Name = "clearGraphToolStripMenuItem";
            this.clearGraphToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.clearGraphToolStripMenuItem.Text = "Clear graph";
            this.clearGraphToolStripMenuItem.Click += new System.EventHandler(this.clearGraphToolStripMenuItem_Click);
            // 
            // resetViewzoomLevelToolStripMenuItem
            // 
            this.resetViewzoomLevelToolStripMenuItem.Name = "resetViewzoomLevelToolStripMenuItem";
            this.resetViewzoomLevelToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.resetViewzoomLevelToolStripMenuItem.Text = "Reset view/zoom level";
            this.resetViewzoomLevelToolStripMenuItem.Click += new System.EventHandler(this.resetViewzoomLevelToolStripMenuItem_Click);
            // 
            // plot1
            // 
            this.plot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot1.Location = new System.Drawing.Point(0, 28);
            this.plot1.Name = "plot1";
            this.plot1.Size = new System.Drawing.Size(838, 699);
            this.plot1.TabIndex = 0;
            this.plot1.Text = "plot1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 753);
            this.Controls.Add(this.plot1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Simple Vector Graphic Viewer";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Plan plot1;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem scaleWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPresetShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetViewzoomLevelToolStripMenuItem;
    }
}

