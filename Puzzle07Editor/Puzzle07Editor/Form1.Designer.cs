namespace Puzzle07Editor
{
    partial class Pz_Main
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
            this.lbl_MainName = new System.Windows.Forms.Label();
            this.pBox_Main = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_MainName
            // 
            this.lbl_MainName.AutoSize = true;
            this.lbl_MainName.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MainName.Location = new System.Drawing.Point(144, 100);
            this.lbl_MainName.Name = "lbl_MainName";
            this.lbl_MainName.Size = new System.Drawing.Size(313, 46);
            this.lbl_MainName.TabIndex = 0;
            this.lbl_MainName.Text = "Puzzle07 Editor";
            // 
            // pBox_Main
            // 
            this.pBox_Main.Location = new System.Drawing.Point(144, 178);
            this.pBox_Main.Name = "pBox_Main";
            this.pBox_Main.Size = new System.Drawing.Size(312, 199);
            this.pBox_Main.TabIndex = 1;
            this.pBox_Main.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(250, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 65);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "temp text, image goes here";
            // 
            // Pz_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(582, 653);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pBox_Main);
            this.Controls.Add(this.lbl_MainName);
            this.Name = "Pz_Main";
            this.Text = "Puzzle07 Editor";
            this.Load += new System.EventHandler(this.Pz_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_MainName;
        private System.Windows.Forms.PictureBox pBox_Main;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

