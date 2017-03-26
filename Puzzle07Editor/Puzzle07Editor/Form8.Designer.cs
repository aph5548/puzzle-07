namespace Puzzle07Editor
{
    partial class Form8
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
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.bT_Finish = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.BackColor = System.Drawing.SystemColors.Control;
            this.pBar.ForeColor = System.Drawing.Color.Lime;
            this.pBar.Location = new System.Drawing.Point(93, 271);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(414, 44);
            this.pBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Making Document";
            // 
            // bT_Finish
            // 
            this.bT_Finish.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bT_Finish.Location = new System.Drawing.Point(253, 475);
            this.bT_Finish.Name = "bT_Finish";
            this.bT_Finish.Size = new System.Drawing.Size(94, 47);
            this.bT_Finish.TabIndex = 2;
            this.bT_Finish.Text = "Finish";
            this.bT_Finish.UseVisualStyleBackColor = true;
            this.bT_Finish.Click += new System.EventHandler(this.bT_Finish_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(253, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Make";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(468, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "Press Make to make file";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(582, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bT_Finish);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBar);
            this.Name = "Form8";
            this.Text = "Compiling";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bT_Finish;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}