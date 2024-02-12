namespace MVP.UI
{
    partial class Part1Form
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
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.resultTextBox1 = new System.Windows.Forms.TextBox();
            this.result1Label = new System.Windows.Forms.Label();
            this.startPart1 = new System.Windows.Forms.Button();
            this.mValueTextBox = new System.Windows.Forms.TextBox();
            this.input1label = new System.Windows.Forms.Label();
            this.Description1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.startPart2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.startPart3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.statusBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusBar.Location = new System.Drawing.Point(0, 344);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusBar.Size = new System.Drawing.Size(600, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel1.Text = "Готов к работе!";
            // 
            // menuBar
            // 
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuBar.Size = new System.Drawing.Size(600, 24);
            this.menuBar.TabIndex = 2;
            this.menuBar.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 318);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.resultTextBox1);
            this.tabPage1.Controls.Add(this.result1Label);
            this.tabPage1.Controls.Add(this.startPart1);
            this.tabPage1.Controls.Add(this.mValueTextBox);
            this.tabPage1.Controls.Add(this.input1label);
            this.tabPage1.Controls.Add(this.Description1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(592, 292);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // resultTextBox1
            // 
            this.resultTextBox1.Location = new System.Drawing.Point(8, 77);
            this.resultTextBox1.Multiline = true;
            this.resultTextBox1.Name = "resultTextBox1";
            this.resultTextBox1.ReadOnly = true;
            this.resultTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox1.Size = new System.Drawing.Size(576, 154);
            this.resultTextBox1.TabIndex = 5;
            // 
            // result1Label
            // 
            this.result1Label.AutoSize = true;
            this.result1Label.Location = new System.Drawing.Point(8, 61);
            this.result1Label.Name = "result1Label";
            this.result1Label.Size = new System.Drawing.Size(40, 13);
            this.result1Label.TabIndex = 4;
            this.result1Label.Text = "Result:";
            // 
            // startPart1
            // 
            this.startPart1.Location = new System.Drawing.Point(11, 237);
            this.startPart1.Name = "startPart1";
            this.startPart1.Size = new System.Drawing.Size(199, 52);
            this.startPart1.TabIndex = 3;
            this.startPart1.Text = "Start";
            this.startPart1.UseVisualStyleBackColor = true;
            // 
            // mValueTextBox
            // 
            this.mValueTextBox.Location = new System.Drawing.Point(41, 38);
            this.mValueTextBox.Name = "mValueTextBox";
            this.mValueTextBox.Size = new System.Drawing.Size(192, 20);
            this.mValueTextBox.TabIndex = 2;
            // 
            // input1label
            // 
            this.input1label.AutoSize = true;
            this.input1label.Location = new System.Drawing.Point(8, 41);
            this.input1label.Name = "input1label";
            this.input1label.Size = new System.Drawing.Size(27, 13);
            this.input1label.TabIndex = 1;
            this.input1label.Text = "m = ";
            // 
            // Description1
            // 
            this.Description1.AutoSize = true;
            this.Description1.Location = new System.Drawing.Point(8, 0);
            this.Description1.Name = "Description1";
            this.Description1.Size = new System.Drawing.Size(331, 26);
            this.Description1.TabIndex = 0;
            this.Description1.Text = "Напишите программу, выводящую все простые числа, которые\r\nменьше m.";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.startPart2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(592, 292);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // startPart2
            // 
            this.startPart2.Location = new System.Drawing.Point(3, 235);
            this.startPart2.Name = "startPart2";
            this.startPart2.Size = new System.Drawing.Size(195, 54);
            this.startPart2.TabIndex = 0;
            this.startPart2.Text = "button1";
            this.startPart2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.startPart3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(592, 292);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // startPart3
            // 
            this.startPart3.Location = new System.Drawing.Point(3, 227);
            this.startPart3.Name = "startPart3";
            this.startPart3.Size = new System.Drawing.Size(200, 62);
            this.startPart3.TabIndex = 0;
            this.startPart3.Text = "button1";
            this.startPart3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(592, 292);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(592, 292);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Part1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Part1Form";
            this.Text = "Part1Form";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label Description1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox mValueTextBox;
        private System.Windows.Forms.Label input1label;
        private System.Windows.Forms.Label result1Label;
        private System.Windows.Forms.Button startPart1;
        private System.Windows.Forms.Button startPart2;
        private System.Windows.Forms.Button startPart3;
        private System.Windows.Forms.TextBox resultTextBox1;
    }
}