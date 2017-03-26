namespace Puzzle07Editor
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Room = new System.Windows.Forms.Label();
            this.bT_Water = new System.Windows.Forms.Button();
            this.bT_Stealth = new System.Windows.Forms.Button();
            this.bT_Lever = new System.Windows.Forms.Button();
            this.bT_Sequence = new System.Windows.Forms.Button();
            this.bT_Light = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bT_Next = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Settings";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_Room
            // 
            this.lb_Room.AutoSize = true;
            this.lb_Room.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Room.Location = new System.Drawing.Point(192, 120);
            this.lb_Room.Name = "lb_Room";
            this.lb_Room.Size = new System.Drawing.Size(216, 32);
            this.lb_Room.TabIndex = 1;
            this.lb_Room.Text = "Choose Room 1";
            // 
            // bT_Water
            // 
            this.bT_Water.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bT_Water.Location = new System.Drawing.Point(160, 180);
            this.bT_Water.Name = "bT_Water";
            this.bT_Water.Size = new System.Drawing.Size(100, 50);
            this.bT_Water.TabIndex = 2;
            this.bT_Water.Text = "Water Room";
            this.bT_Water.UseVisualStyleBackColor = true;
            this.bT_Water.Click += new System.EventHandler(this.bT_Water_Click);
            // 
            // bT_Stealth
            // 
            this.bT_Stealth.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bT_Stealth.Location = new System.Drawing.Point(348, 180);
            this.bT_Stealth.Name = "bT_Stealth";
            this.bT_Stealth.Size = new System.Drawing.Size(100, 50);
            this.bT_Stealth.TabIndex = 3;
            this.bT_Stealth.Text = "Stealth Room";
            this.bT_Stealth.UseVisualStyleBackColor = true;
            this.bT_Stealth.Click += new System.EventHandler(this.bT_Stealth_Click);
            // 
            // bT_Lever
            // 
            this.bT_Lever.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bT_Lever.Location = new System.Drawing.Point(160, 273);
            this.bT_Lever.Name = "bT_Lever";
            this.bT_Lever.Size = new System.Drawing.Size(100, 50);
            this.bT_Lever.TabIndex = 4;
            this.bT_Lever.Text = "Lever Room";
            this.bT_Lever.UseVisualStyleBackColor = true;
            this.bT_Lever.Click += new System.EventHandler(this.bT_Lever_Click);
            // 
            // bT_Sequence
            // 
            this.bT_Sequence.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bT_Sequence.Location = new System.Drawing.Point(348, 273);
            this.bT_Sequence.Name = "bT_Sequence";
            this.bT_Sequence.Size = new System.Drawing.Size(100, 50);
            this.bT_Sequence.TabIndex = 5;
            this.bT_Sequence.Text = "Sequence Room";
            this.bT_Sequence.UseVisualStyleBackColor = true;
            this.bT_Sequence.Click += new System.EventHandler(this.bT_Sequence_Click);
            // 
            // bT_Light
            // 
            this.bT_Light.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bT_Light.Location = new System.Drawing.Point(255, 355);
            this.bT_Light.Name = "bT_Light";
            this.bT_Light.Size = new System.Drawing.Size(100, 50);
            this.bT_Light.TabIndex = 6;
            this.bT_Light.Text = "Light\r\n Room";
            this.bT_Light.UseVisualStyleBackColor = true;
            this.bT_Light.Click += new System.EventHandler(this.bT_Light_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 495);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(296, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // bT_Next
            // 
            this.bT_Next.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bT_Next.Location = new System.Drawing.Point(255, 551);
            this.bT_Next.Name = "bT_Next";
            this.bT_Next.Size = new System.Drawing.Size(100, 50);
            this.bT_Next.TabIndex = 8;
            this.bT_Next.Text = "Next";
            this.bT_Next.UseVisualStyleBackColor = true;
            this.bT_Next.Click += new System.EventHandler(this.bT_Next_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(192, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Enter File Name";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(582, 653);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bT_Next);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bT_Light);
            this.Controls.Add(this.bT_Sequence);
            this.Controls.Add(this.bT_Lever);
            this.Controls.Add(this.bT_Stealth);
            this.Controls.Add(this.bT_Water);
            this.Controls.Add(this.lb_Room);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Puzzle 07 Editor: Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Pz_Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Room;
        private System.Windows.Forms.Button bT_Water;
        private System.Windows.Forms.Button bT_Stealth;
        private System.Windows.Forms.Button bT_Lever;
        private System.Windows.Forms.Button bT_Sequence;
        private System.Windows.Forms.Button bT_Light;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bT_Next;
        private System.Windows.Forms.Label label3;
    }
}