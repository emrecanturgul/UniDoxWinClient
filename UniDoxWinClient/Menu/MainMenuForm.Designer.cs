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
            this.components = new System.ComponentModel.Container();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.btn_user_query = new System.Windows.Forms.Button();
            this.rightTitleLabel = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btn_send_invoice = new System.Windows.Forms.Button();
            this.btn_prefix = new System.Windows.Forms.Button();
            this.btn_credit_count = new System.Windows.Forms.Button();
            this.leftTitleLabel = new System.Windows.Forms.Label();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.headerPanel.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.headerPanel.Controls.Add(this.logoPanel);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1200, 120);
            this.headerPanel.TabIndex = 0;
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.logoPanel.Location = new System.Drawing.Point(30, 20);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(80, 80);
            this.logoPanel.TabIndex = 2;
            this.logoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.logoPanel_Paint);
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.subtitleLabel.Location = new System.Drawing.Point(147, 82);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(358, 28);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Profesyonel E-Fatura Yönetim Platformu";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(140, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(516, 62);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Emrecan E-Fatura Hub";
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.mainContentPanel.Controls.Add(this.rightPanel);
            this.mainContentPanel.Controls.Add(this.leftPanel);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(0, 120);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Padding = new System.Windows.Forms.Padding(30);
            this.mainContentPanel.Size = new System.Drawing.Size(1200, 580);
            this.mainContentPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.White;
            this.rightPanel.Controls.Add(this.btn_user_query);
            this.rightPanel.Controls.Add(this.rightTitleLabel);
            this.rightPanel.Location = new System.Drawing.Point(580, 50);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(570, 480);
            this.rightPanel.TabIndex = 1;
            this.rightPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // btn_user_query
            // 
            this.btn_user_query.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_user_query.FlatAppearance.BorderSize = 0;
            this.btn_user_query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btn_user_query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(170)))), ((int)(((byte)(237)))));
            this.btn_user_query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_user_query.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btn_user_query.ForeColor = System.Drawing.Color.White;
            this.btn_user_query.Location = new System.Drawing.Point(40, 150);
            this.btn_user_query.Name = "btn_user_query";
            this.btn_user_query.Size = new System.Drawing.Size(490, 200);
            this.btn_user_query.TabIndex = 1;
            this.btn_user_query.Text = "👥 Kullanıcı Sorguları\r\n\r\n• Fatura durumu sorgulama\r\n• Kullanıcı bilgileri\r\n• Sis" +
    "tem raporları\r\n• Detaylı analizler";
            this.btn_user_query.UseVisualStyleBackColor = false;
            this.btn_user_query.Click += new System.EventHandler(this.button2_Click);
            this.btn_user_query.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_user_query.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // rightTitleLabel
            // 
            this.rightTitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.rightTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.rightTitleLabel.Location = new System.Drawing.Point(30, 30);
            this.rightTitleLabel.Name = "rightTitleLabel";
            this.rightTitleLabel.Size = new System.Drawing.Size(510, 40);
            this.rightTitleLabel.TabIndex = 0;
            this.rightTitleLabel.Text = "🔍 Sorgulama İşlemleri";
            this.rightTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.White;
            this.leftPanel.Controls.Add(this.btn_send_invoice);
            this.leftPanel.Controls.Add(this.btn_prefix);
            this.leftPanel.Controls.Add(this.btn_credit_count);
            this.leftPanel.Controls.Add(this.leftTitleLabel);
            this.leftPanel.Location = new System.Drawing.Point(50, 50);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(500, 480);
            this.leftPanel.TabIndex = 0;
            this.leftPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // btn_send_invoice
            // 
            this.btn_send_invoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btn_send_invoice.FlatAppearance.BorderSize = 0;
            this.btn_send_invoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btn_send_invoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(109)))), ((int)(((byte)(96)))));
            this.btn_send_invoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_send_invoice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btn_send_invoice.ForeColor = System.Drawing.Color.White;
            this.btn_send_invoice.Location = new System.Drawing.Point(40, 300);
            this.btn_send_invoice.Name = "btn_send_invoice";
            this.btn_send_invoice.Size = new System.Drawing.Size(420, 80);
            this.btn_send_invoice.TabIndex = 3;
            this.btn_send_invoice.Text = "📤 Fatura Gönder\r\nToplu fatura gönderimi (26 adet)";
            this.btn_send_invoice.UseVisualStyleBackColor = false;
            this.btn_send_invoice.Click += new System.EventHandler(this.button1_Click);
            this.btn_send_invoice.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_send_invoice.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btn_prefix
            // 
            this.btn_prefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btn_prefix.FlatAppearance.BorderSize = 0;
            this.btn_prefix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btn_prefix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(122)))), ((int)(((byte)(197)))));
            this.btn_prefix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prefix.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btn_prefix.ForeColor = System.Drawing.Color.White;
            this.btn_prefix.Location = new System.Drawing.Point(40, 200);
            this.btn_prefix.Name = "btn_prefix";
            this.btn_prefix.Size = new System.Drawing.Size(420, 80);
            this.btn_prefix.TabIndex = 2;
            this.btn_prefix.Text = "🏷️ Prefix Yönetimi\r\nFatura seri numarası ayarları";
            this.btn_prefix.UseVisualStyleBackColor = false;
            this.btn_prefix.Click += new System.EventHandler(this.button3_Click);
            this.btn_prefix.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_prefix.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btn_credit_count
            // 
            this.btn_credit_count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_credit_count.FlatAppearance.BorderSize = 0;
            this.btn_credit_count.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_credit_count.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(230)))), ((int)(((byte)(127)))));
            this.btn_credit_count.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_credit_count.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btn_credit_count.ForeColor = System.Drawing.Color.White;
            this.btn_credit_count.Location = new System.Drawing.Point(40, 100);
            this.btn_credit_count.Name = "btn_credit_count";
            this.btn_credit_count.Size = new System.Drawing.Size(420, 80);
            this.btn_credit_count.TabIndex = 1;
            this.btn_credit_count.Text = "💳 Kredi Bilgileri\r\nKontör durumu ve kredi bakiyesi";
            this.btn_credit_count.UseVisualStyleBackColor = false;
            this.btn_credit_count.Click += new System.EventHandler(this.btn_credit_count_Click);
            this.btn_credit_count.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btn_credit_count.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // leftTitleLabel
            // 
            this.leftTitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.leftTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.leftTitleLabel.Location = new System.Drawing.Point(30, 30);
            this.leftTitleLabel.Name = "leftTitleLabel";
            this.leftTitleLabel.Size = new System.Drawing.Size(440, 40);
            this.leftTitleLabel.TabIndex = 0;
            this.leftTitleLabel.Text = "🚀 Fatura İşlemleri";
            this.leftTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.statusPanel.Controls.Add(this.connectionStatusLabel);
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusPanel.Location = new System.Drawing.Point(0, 700);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(1200, 50);
            this.statusPanel.TabIndex = 2;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.connectionStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.connectionStatusLabel.Location = new System.Drawing.Point(1000, 15);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(152, 23);
            this.connectionStatusLabel.TabIndex = 1;
            this.connectionStatusLabel.Text = "🟢 Bağlantı Aktif";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.statusLabel.Location = new System.Drawing.Point(20, 15);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(333, 23);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "© 2025 UniDox - E-Fatura Yönetim Sistemi";
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 50;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniDox E-Fatura Management System";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Label leftTitleLabel;
        private System.Windows.Forms.Label rightTitleLabel;
        private System.Windows.Forms.Button btn_credit_count;
        private System.Windows.Forms.Button btn_prefix;
        private System.Windows.Forms.Button btn_send_invoice;
        private System.Windows.Forms.Button btn_user_query;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.Timer animationTimer;
    }
}