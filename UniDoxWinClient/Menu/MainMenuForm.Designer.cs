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
            this.btnearsiv = new System.Windows.Forms.Button();
            this.btnefatura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnearsiv
            // 
            this.btnearsiv.Location = new System.Drawing.Point(101, 121);
            this.btnearsiv.Name = "btnearsiv";
            this.btnearsiv.Size = new System.Drawing.Size(232, 85);
            this.btnearsiv.TabIndex = 0;
            this.btnearsiv.Text = "EArşiv\r\n";
            this.btnearsiv.UseVisualStyleBackColor = true;
            this.btnearsiv.Click += new System.EventHandler(this.btnearsiv_Click);
            // 
            // btnefatura
            // 
            this.btnefatura.Location = new System.Drawing.Point(432, 121);
            this.btnefatura.Name = "btnefatura";
            this.btnefatura.Size = new System.Drawing.Size(232, 85);
            this.btnefatura.TabIndex = 1;
            this.btnefatura.Text = "EFatura\r\n";
            this.btnefatura.UseVisualStyleBackColor = true;
            this.btnefatura.Click += new System.EventHandler(this.btnefatura_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnefatura);
            this.Controls.Add(this.btnearsiv);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnearsiv;
        private System.Windows.Forms.Button btnefatura;
    }
}