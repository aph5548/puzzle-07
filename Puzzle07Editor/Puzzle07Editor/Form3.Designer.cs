namespace Puzzle07Editor
{
    partial class Form3
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
            this.label2 = new System.Windows.Forms.Label();
            this.tB_Int3 = new System.Windows.Forms.TextBox();
            this.tB_Int1 = new System.Windows.Forms.TextBox();
            this.tB_Int2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_Error = new System.Windows.Forms.Label();
            this.bT_Validate = new System.Windows.Forms.Button();
            this.bT_Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Water Room";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 115);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter 3 integers between 1-10:\r\n\r\nInteger 1 should be greater than Integer 2\r\n\r\nI" +
    "nteger 3 should be smaller than Integer 1\r\n";
            // 
            // tB_Int3
            // 
            this.tB_Int3.Location = new System.Drawing.Point(187, 373);
            this.tB_Int3.Name = "tB_Int3";
            this.tB_Int3.Size = new System.Drawing.Size(40, 22);
            this.tB_Int3.TabIndex = 4;
            this.tB_Int3.TextChanged += new System.EventHandler(this.tB_Int3_TextChanged);
            // 
            // tB_Int1
            // 
            this.tB_Int1.Location = new System.Drawing.Point(187, 273);
            this.tB_Int1.Name = "tB_Int1";
            this.tB_Int1.Size = new System.Drawing.Size(40, 22);
            this.tB_Int1.TabIndex = 2;
            this.tB_Int1.TextChanged += new System.EventHandler(this.tB_Int1_TextChanged);
            // 
            // tB_Int2
            // 
            this.tB_Int2.Location = new System.Drawing.Point(187, 324);
            this.tB_Int2.Name = "tB_Int2";
            this.tB_Int2.Size = new System.Drawing.Size(40, 22);
            this.tB_Int2.TabIndex = 3;
            this.tB_Int2.TextChanged += new System.EventHandler(this.tB_Int2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(116, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Int 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(116, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Int 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(116, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Int 3";
            // 
            // lb_Error
            // 
            this.lb_Error.AutoSize = true;
            this.lb_Error.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Error.ForeColor = System.Drawing.Color.Red;
            this.lb_Error.Location = new System.Drawing.Point(255, 273);
            this.lb_Error.Name = "lb_Error";
            this.lb_Error.Size = new System.Drawing.Size(256, 80);
            this.lb_Error.TabIndex = 8;
            this.lb_Error.Text = "Integers 1 and 2 can\'t both be even\r\nand have to be relatively prime.\r\n(common de" +
    "nominator of 1)\r\nMust be between 1-10\r\n\r\n";
            this.lb_Error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lb_Error.Visible = false;
            // 
            // bT_Validate
            // 
            this.bT_Validate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bT_Validate.Location = new System.Drawing.Point(314, 347);
            this.bT_Validate.Name = "bT_Validate";
            this.bT_Validate.Size = new System.Drawing.Size(125, 48);
            this.bT_Validate.TabIndex = 9;
            this.bT_Validate.Text = "Validate";
            this.bT_Validate.UseVisualStyleBackColor = true;
            this.bT_Validate.Click += new System.EventHandler(this.bT_Validate_Click);
            // 
            // bT_Next
            // 
            this.bT_Next.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bT_Next.Location = new System.Drawing.Point(237, 500);
            this.bT_Next.Name = "bT_Next";
            this.bT_Next.Size = new System.Drawing.Size(125, 48);
            this.bT_Next.TabIndex = 10;
            this.bT_Next.Text = "Next";
            this.bT_Next.UseVisualStyleBackColor = true;
            this.bT_Next.Click += new System.EventHandler(this.bT_Next_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(582, 653);
            this.Controls.Add(this.bT_Next);
            this.Controls.Add(this.bT_Validate);
            this.Controls.Add(this.lb_Error);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tB_Int2);
            this.Controls.Add(this.tB_Int1);
            this.Controls.Add(this.tB_Int3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Puzzle07 Editor: Water Puzzle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tB_Int3;
        private System.Windows.Forms.TextBox tB_Int1;
        private System.Windows.Forms.TextBox tB_Int2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_Error;
        private System.Windows.Forms.Button bT_Validate;
        private System.Windows.Forms.Button bT_Next;
    }
}