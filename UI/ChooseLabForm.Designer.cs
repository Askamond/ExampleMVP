using System.Windows.Forms;

namespace MVP.UI
{
    partial class ChooseLabForm
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
        private TreeView LabList;
        private StatusStrip statusBar;
        private ToolStripStatusLabel StatusInfo;
        private Button leftButton;
        private Button startButton;
        private Button rightButton;
        private GroupBox LabInfoBox;
        private TextBox textBox1;
        private Panel MainModule;

        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Часть 1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Часть 2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Часть 3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Часть 4");
            this.MainModule = new System.Windows.Forms.Panel();
            this.LabList = new System.Windows.Forms.TreeView();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.StatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.leftButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.LabInfoBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainModule.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.LabInfoBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainModule
            // 
            this.MainModule.Controls.Add(this.LabList);
            this.MainModule.Location = new System.Drawing.Point(12, 12);
            this.MainModule.Name = "MainModule";
            this.MainModule.Size = new System.Drawing.Size(262, 455);
            this.MainModule.TabIndex = 1;
            // 
            // LabList
            // 
            this.LabList.Location = new System.Drawing.Point(3, 19);
            this.LabList.Name = "LabList";
            treeNode1.Name = "Part1";
            treeNode1.Text = "Часть 1";
            treeNode2.Name = "Part2";
            treeNode2.Text = "Часть 2";
            treeNode3.Name = "Part3";
            treeNode3.Text = "Часть 3";
            treeNode4.Name = "Part 4";
            treeNode4.Text = "Часть 4";
            this.LabList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.LabList.Size = new System.Drawing.Size(256, 433);
            this.LabList.TabIndex = 2;
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusInfo});
            this.statusBar.Location = new System.Drawing.Point(0, 475);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(813, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // StatusInfo
            // 
            this.StatusInfo.Name = "StatusInfo";
            this.StatusInfo.Size = new System.Drawing.Size(91, 17);
            this.StatusInfo.Text = "Готов к работе!";
            // 
            // leftButton
            // 
            this.leftButton.Enabled = false;
            this.leftButton.Location = new System.Drawing.Point(6, 397);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(166, 36);
            this.leftButton.TabIndex = 3;
            this.leftButton.Text = "Предыдущая лаба <-";
            this.leftButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(178, 397);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(166, 36);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Запустить";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(350, 397);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(166, 36);
            this.rightButton.TabIndex = 5;
            this.rightButton.Text = "Следущая лаба ->";
            this.rightButton.UseVisualStyleBackColor = true;
            // 
            // LabInfoBox
            // 
            this.LabInfoBox.Controls.Add(this.textBox1);
            this.LabInfoBox.Controls.Add(this.rightButton);
            this.LabInfoBox.Controls.Add(this.leftButton);
            this.LabInfoBox.Controls.Add(this.startButton);
            this.LabInfoBox.Location = new System.Drawing.Point(280, 31);
            this.LabInfoBox.Name = "LabInfoBox";
            this.LabInfoBox.Size = new System.Drawing.Size(529, 438);
            this.LabInfoBox.TabIndex = 6;
            this.LabInfoBox.TabStop = false;
            this.LabInfoBox.Text = "Информация о лабораторной";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(510, 370);
            this.textBox1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // ChooseLabForm
            // 
            this.ClientSize = new System.Drawing.Size(813, 497);
            this.Controls.Add(this.LabInfoBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.MainModule);
            this.Name = "ChooseLabForm";
            this.Text = "Лабораторная работа 1";
            this.MainModule.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.LabInfoBox.ResumeLayout(false);
            this.LabInfoBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutMenuItem;
    }
}