namespace KingAndKnightGUI
{
    partial class Form1
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
            canvas = new PictureBox();
            btnPrev = new Button();
            btnNext = new Button();
            lblStep = new Label();
            cbSolverType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Location = new Point(12, 12);
            canvas.Name = "canvas";
            canvas.Size = new Size(480, 480);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Click += canvas_Click;
            canvas.Paint += canvas_Paint;
            // 
            // btnPrev
            // 
            btnPrev.Font = new Font("Consolas", 20F);
            btnPrev.Location = new Point(12, 510);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(100, 50);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "<<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Consolas", 20F);
            btnNext.Location = new Point(392, 510);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(100, 50);
            btnNext.TabIndex = 2;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblStep
            // 
            lblStep.AutoSize = true;
            lblStep.Font = new Font("Consolas", 20F);
            lblStep.Location = new Point(180, 520);
            lblStep.Name = "lblStep";
            lblStep.Size = new Size(104, 32);
            lblStep.TabIndex = 3;
            lblStep.Text = "Step 0";
            // 
            // cbSolverType
            // 
            cbSolverType.Font = new Font("Consolas", 12F);
            cbSolverType.FormattingEnabled = true;
            cbSolverType.Items.AddRange(new object[] { "Simple Trial-Error", "Trial-Error with Restart and Depth-Bound (max depth: 10, rounds: 10000)", "Backtrack", "Backtrack with Circle Check", "Backtrack with Circle Check (max depth: 20)", "Backtrack with Circle Check (max depth: 9)", "Depth First", "Breadth First", "A*" });
            cbSolverType.Location = new Point(12, 580);
            cbSolverType.Name = "cbSolverType";
            cbSolverType.Size = new Size(480, 27);
            cbSolverType.TabIndex = 4;
            cbSolverType.SelectedIndexChanged += cbSolverType_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 621);
            Controls.Add(cbSolverType);
            Controls.Add(lblStep);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(canvas);
            Name = "Form1";
            Text = "King and Knight";
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.ComboBox cbSolverType;

    }
}
