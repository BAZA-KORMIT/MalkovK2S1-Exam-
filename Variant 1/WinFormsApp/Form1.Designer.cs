namespace WinFormsApp
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
            lbl_M = new Label();
            lbl_N = new Label();
            txt_timeA = new TextBox();
            txt_timeB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lbl_M
            // 
            lbl_M.AutoSize = true;
            lbl_M.Location = new Point(20, 16);
            lbl_M.Name = "lbl_M";
            lbl_M.Size = new Size(18, 15);
            lbl_M.TabIndex = 0;
            lbl_M.Text = "M";
            // 
            // lbl_N
            // 
            lbl_N.AutoSize = true;
            lbl_N.Location = new Point(20, 51);
            lbl_N.Name = "lbl_N";
            lbl_N.Size = new Size(16, 15);
            lbl_N.TabIndex = 1;
            lbl_N.Text = "N";
            // 
            // txt_timeA
            // 
            txt_timeA.Location = new Point(608, 16);
            txt_timeA.Name = "txt_timeA";
            txt_timeA.Size = new Size(170, 23);
            txt_timeA.TabIndex = 2;
            // 
            // txt_timeB
            // 
            txt_timeB.Location = new Point(608, 51);
            txt_timeB.Name = "txt_timeB";
            txt_timeB.Size = new Size(170, 23);
            txt_timeB.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(546, 19);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 4;
            label1.Text = "Время:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(546, 59);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 5;
            label2.Text = "Время:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_timeB);
            Controls.Add(txt_timeA);
            Controls.Add(lbl_N);
            Controls.Add(lbl_M);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_M;
        private Label lbl_N;
        private TextBox txt_timeA;
        private TextBox txt_timeB;
        private Label label1;
        private Label label2;
    }
}