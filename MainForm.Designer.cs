namespace MazeGenerator
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recursiveBacktrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbMaze = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nupWidth = new System.Windows.Forms.NumericUpDown();
            this.nupHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(366, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseAlgorithmToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // chooseAlgorithmToolStripMenuItem
            // 
            this.chooseAlgorithmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recursiveBacktrackerToolStripMenuItem,
            this.ellerToolStripMenuItem});
            this.chooseAlgorithmToolStripMenuItem.Name = "chooseAlgorithmToolStripMenuItem";
            this.chooseAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.chooseAlgorithmToolStripMenuItem.Text = "Choose Algorithm";
            // 
            // recursiveBacktrackerToolStripMenuItem
            // 
            this.recursiveBacktrackerToolStripMenuItem.Checked = true;
            this.recursiveBacktrackerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.recursiveBacktrackerToolStripMenuItem.Name = "recursiveBacktrackerToolStripMenuItem";
            this.recursiveBacktrackerToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.recursiveBacktrackerToolStripMenuItem.Text = "Recursive Backtracker";
            this.recursiveBacktrackerToolStripMenuItem.Click += new System.EventHandler(this.recursiveBacktrackerToolStripMenuItem_Click);
            // 
            // ellerToolStripMenuItem
            // 
            this.ellerToolStripMenuItem.Name = "ellerToolStripMenuItem";
            this.ellerToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ellerToolStripMenuItem.Text = "Eller";
            this.ellerToolStripMenuItem.Click += new System.EventHandler(this.ellerToolStripMenuItem_Click);
            // 
            // gbMaze
            // 
            this.gbMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMaze.Location = new System.Drawing.Point(13, 28);
            this.gbMaze.Name = "gbMaze";
            this.gbMaze.Size = new System.Drawing.Size(604, 398);
            this.gbMaze.TabIndex = 2;
            this.gbMaze.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width:";
            // 
            // nupWidth
            // 
            this.nupWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nupWidth.Location = new System.Drawing.Point(56, 435);
            this.nupWidth.Name = "nupWidth";
            this.nupWidth.Size = new System.Drawing.Size(120, 20);
            this.nupWidth.TabIndex = 5;
            this.nupWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // nupHeight
            // 
            this.nupHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nupHeight.Location = new System.Drawing.Point(240, 435);
            this.nupHeight.Name = "nupHeight";
            this.nupHeight.Size = new System.Drawing.Size(120, 20);
            this.nupHeight.TabIndex = 7;
            this.nupHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Height:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 467);
            this.Controls.Add(this.nupHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nupWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbMaze);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recursiveBacktrackerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellerToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbMaze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupWidth;
        private System.Windows.Forms.NumericUpDown nupHeight;
        private System.Windows.Forms.Label label2;
    }
}

