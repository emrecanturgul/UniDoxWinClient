namespace UniDoxWinClient
{
    partial class EArchiveMenuForm
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
            this.btnFaturaServisi = new System.Windows.Forms.Button();
            this.btnRaporServisi = new System.Windows.Forms.Button();
            this.btnYuklemeServisi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFaturaServisi
            // 
            this.btnFaturaServisi.Location = new System.Drawing.Point(82, 75);
            this.btnFaturaServisi.Name = "btnFaturaServisi";
            this.btnFaturaServisi.Size = new System.Drawing.Size(180, 121);
            this.btnFaturaServisi.TabIndex = 0;
            this.btnFaturaServisi.Text = "EArşiv Fatura Servisi";
            this.btnFaturaServisi.UseVisualStyleBackColor = true;
            this.btnFaturaServisi.Click += new System.EventHandler(this.btnFaturaServisi_Click);
            // 
            // btnRaporServisi
            // 
            this.btnRaporServisi.Location = new System.Drawing.Point(310, 165);
            this.btnRaporServisi.Name = "btnRaporServisi";
            this.btnRaporServisi.Size = new System.Drawing.Size(180, 121);
            this.btnRaporServisi.TabIndex = 1;
            this.btnRaporServisi.Text = "EArşiv Rapor Servisi\r\n";
            this.btnRaporServisi.UseVisualStyleBackColor = true;
            this.btnRaporServisi.Click += new System.EventHandler(this.btnRaporServisi_Click);
            // 
            // btnYuklemeServisi
            // 
            this.btnYuklemeServisi.Location = new System.Drawing.Point(558, 258);
            this.btnYuklemeServisi.Name = "btnYuklemeServisi";
            this.btnYuklemeServisi.Size = new System.Drawing.Size(180, 121);
            this.btnYuklemeServisi.TabIndex = 2;
            this.btnYuklemeServisi.Text = "EArşiv Fatura Yükleme Servisi\r\n";
            this.btnYuklemeServisi.UseVisualStyleBackColor = true;
            this.btnYuklemeServisi.Click += new System.EventHandler(this.btnYuklemeServisi_Click);
            // 
            // EArchiveMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnYuklemeServisi);
            this.Controls.Add(this.btnRaporServisi);
            this.Controls.Add(this.btnFaturaServisi);
            this.Name = "EArchiveMenuForm";
            this.Text = "EArchiveMenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFaturaServisi;
        private System.Windows.Forms.Button btnRaporServisi;
        private System.Windows.Forms.Button btnYuklemeServisi;
    }
}