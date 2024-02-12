namespace MVP.UI
{
    partial class Part3Form
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Ex1 = new System.Windows.Forms.TabPage();
            this.Ex2 = new System.Windows.Forms.TabPage();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.Ex3 = new System.Windows.Forms.TabPage();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Ex1);
            this.tabControl1.Controls.Add(this.Ex2);
            this.tabControl1.Controls.Add(this.Ex3);
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 391);
            this.tabControl1.TabIndex = 0;
            // 
            // Ex1
            // 
            this.Ex1.Location = new System.Drawing.Point(4, 25);
            this.Ex1.Name = "Ex1";
            this.Ex1.Padding = new System.Windows.Forms.Padding(3);
            this.Ex1.Size = new System.Drawing.Size(792, 362);
            this.Ex1.TabIndex = 0;
            this.Ex1.Text = "1";
            this.Ex1.UseVisualStyleBackColor = true;
            // 
            // Ex2
            // 
            this.Ex2.Location = new System.Drawing.Point(4, 25);
            this.Ex2.Name = "Ex2";
            this.Ex2.Padding = new System.Windows.Forms.Padding(3);
            this.Ex2.Size = new System.Drawing.Size(792, 366);
            this.Ex2.TabIndex = 1;
            this.Ex2.Text = "2";
            this.Ex2.UseVisualStyleBackColor = true;
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusBar.Location = new System.Drawing.Point(0, 425);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(800, 25);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuBar
            // 
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(800, 28);
            this.menuBar.TabIndex = 2;
            this.menuBar.Text = "menuStrip1";
            // 
            // Ex3
            // 
            this.Ex3.Location = new System.Drawing.Point(4, 25);
            this.Ex3.Name = "Ex3";
            this.Ex3.Size = new System.Drawing.Size(792, 366);
            this.Ex3.TabIndex = 2;
            this.Ex3.Text = "3";
            this.Ex3.UseVisualStyleBackColor = true;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // Part1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuBar;
            this.Name = "Part1Form";
            this.Text = "Part1Form";
            this.tabControl1.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Ex1;
        private System.Windows.Forms.TabPage Ex2;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.TabPage Ex3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}