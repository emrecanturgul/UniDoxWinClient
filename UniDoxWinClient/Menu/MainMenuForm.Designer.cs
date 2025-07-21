namespace UniDoxWinClient
{
    partial class MainMenuForm
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
            this.btn_credit_count = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_credit_count
            // 
            this.btn_credit_count.Location = new System.Drawing.Point(35, 71);
            this.btn_credit_count.Name = "btn_credit_count";
            this.btn_credit_count.Size = new System.Drawing.Size(183, 72);
            this.btn_credit_count.TabIndex = 1;
            this.btn_credit_count.Text = "Kredi Bilgi\r\n";
            this.btn_credit_count.UseVisualStyleBackColor = true;
            this.btn_credit_count.Click += new System.EventHandler(this.btn_credit_count_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(35, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 72);
            this.button3.TabIndex = 2;
            this.button3.Text = "Prefix";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 72);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send Invoice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 72);
            this.button2.TabIndex = 4;
            this.button2.Text = "UserQuery\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_credit_count);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_credit_count;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}