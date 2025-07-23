namespace UniDoxWinClient
{
    partial class Form1
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.loginContainer = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.usernamePanel = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.connectionDot = new System.Windows.Forms.Label();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.featuresLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.loginContainer.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.usernamePanel.SuspendLayout();
            this.passwordPanel.SuspendLayout();
            this.connectionPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.mainPanel.Controls.Add(this.loginContainer);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(67, 62, 67, 62);
            this.mainPanel.Size = new System.Drawing.Size(1333, 738);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // loginContainer
            // 
            this.loginContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.loginContainer.Controls.Add(this.logoPanel);
            this.loginContainer.Controls.Add(this.titleLabel);
            this.loginContainer.Controls.Add(this.subtitleLabel);
            this.loginContainer.Controls.Add(this.usernamePanel);
            this.loginContainer.Controls.Add(this.passwordPanel);
            this.loginContainer.Controls.Add(this.loginButton);
            this.loginContainer.Controls.Add(this.statusLabel);
            this.loginContainer.Controls.Add(this.connectionPanel);
            this.loginContainer.Controls.Add(this.footerPanel);
            this.loginContainer.Location = new System.Drawing.Point(400, 92);
            this.loginContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loginContainer.Name = "loginContainer";
            this.loginContainer.Padding = new System.Windows.Forms.Padding(53, 49, 53, 49);
            this.loginContainer.Size = new System.Drawing.Size(533, 554);
            this.loginContainer.TabIndex = 0;
            this.loginContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.loginContainer_Paint);
            // 
            // logoPanel
            // 
            this.logoPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.logoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.logoPanel.Controls.Add(this.logoLabel);
            this.logoPanel.Location = new System.Drawing.Point(213, 25);
            this.logoPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(107, 98);
            this.logoPanel.TabIndex = 0;
            this.logoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.logoPanel_Paint);
            // 
            // logoLabel
            // 
            this.logoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(0, 0);
            this.logoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(107, 98);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "UD";
            this.logoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.titleLabel.Location = new System.Drawing.Point(53, 135);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(427, 49);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Emrecan";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.subtitleLabel.Location = new System.Drawing.Point(53, 185);
            this.subtitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(427, 25);
            this.subtitleLabel.TabIndex = 2;
            this.subtitleLabel.Text = "E-Fatura & E-Arşiv Entegrasyon Sistemi";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernamePanel
            // 
            this.usernamePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usernamePanel.Controls.Add(this.usernameLabel);
            this.usernamePanel.Controls.Add(this.txtusername);
            this.usernamePanel.Location = new System.Drawing.Point(53, 234);
            this.usernamePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usernamePanel.Name = "usernamePanel";
            this.usernamePanel.Size = new System.Drawing.Size(427, 62);
            this.usernamePanel.TabIndex = 3;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.usernameLabel.Location = new System.Drawing.Point(0, 0);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(96, 20);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Kullanıcı Adı";
            // 
            // txtusername
            // 
            this.txtusername.BackColor = System.Drawing.Color.White;
            this.txtusername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtusername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtusername.Location = new System.Drawing.Point(7, 25);
            this.txtusername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(413, 27);
            this.txtusername.TabIndex = 1;
            this.txtusername.Enter += new System.EventHandler(this.txtusername_Enter);
            this.txtusername.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // passwordPanel
            // 
            this.passwordPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordPanel.Controls.Add(this.passwordLabel);
            this.passwordPanel.Controls.Add(this.txtpassword);
            this.passwordPanel.Location = new System.Drawing.Point(53, 308);
            this.passwordPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(427, 62);
            this.passwordPanel.TabIndex = 4;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.passwordLabel.Location = new System.Drawing.Point(0, 0);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(41, 20);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "Şifre";
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.Color.White;
            this.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtpassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtpassword.Location = new System.Drawing.Point(7, 25);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '●';
            this.txtpassword.Size = new System.Drawing.Size(413, 27);
            this.txtpassword.TabIndex = 1;
            this.txtpassword.Enter += new System.EventHandler(this.txtpassword_Enter);
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave);
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(53, 394);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(427, 55);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Sisteme Giriş Yap";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            this.loginButton.Paint += new System.Windows.Forms.PaintEventHandler(this.loginButton_Paint);
            this.loginButton.MouseEnter += new System.EventHandler(this.loginButton_MouseEnter);
            this.loginButton.MouseLeave += new System.EventHandler(this.loginButton_MouseLeave);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusLabel.Location = new System.Drawing.Point(53, 462);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(427, 25);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statusLabel.Visible = false;
            // 
            // connectionPanel
            // 
            this.connectionPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.connectionPanel.Controls.Add(this.connectionDot);
            this.connectionPanel.Controls.Add(this.connectionLabel);
            this.connectionPanel.Location = new System.Drawing.Point(53, 486);
            this.connectionPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(427, 25);
            this.connectionPanel.TabIndex = 7;
            // 
            // connectionDot
            // 
            this.connectionDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.connectionDot.Location = new System.Drawing.Point(167, 7);
            this.connectionDot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionDot.Name = "connectionDot";
            this.connectionDot.Size = new System.Drawing.Size(11, 10);
            this.connectionDot.TabIndex = 0;
            this.connectionDot.Paint += new System.Windows.Forms.PaintEventHandler(this.connectionDot_Paint);
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.connectionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.connectionLabel.Location = new System.Drawing.Point(187, 4);
            this.connectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(148, 19);
            this.connectionLabel.TabIndex = 1;
            this.connectionLabel.Text = "Sunucu Bağlantısı Aktif";
            // 
            // footerPanel
            // 
            this.footerPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.footerPanel.Controls.Add(this.versionLabel);
            this.footerPanel.Controls.Add(this.featuresLabel);
            this.footerPanel.Location = new System.Drawing.Point(53, 517);
            this.footerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(427, 31);
            this.footerPanel.TabIndex = 8;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.versionLabel.Location = new System.Drawing.Point(140, 0);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(156, 15);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "UniDox Windows Client v2.1";
            // 
            // featuresLabel
            // 
            this.featuresLabel.AutoSize = true;
            this.featuresLabel.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.featuresLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.featuresLabel.Location = new System.Drawing.Point(113, 15);
            this.featuresLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.featuresLabel.Name = "featuresLabel";
            this.featuresLabel.Size = new System.Drawing.Size(286, 15);
            this.featuresLabel.TabIndex = 1;
            this.featuresLabel.Text = "🔐 SSL Güvenli  📊 E-Fatura Ready  🗂️ E-Arşiv Support";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 738);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniDox - Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainPanel.ResumeLayout(false);
            this.loginContainer.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.usernamePanel.ResumeLayout(false);
            this.usernamePanel.PerformLayout();
            this.passwordPanel.ResumeLayout(false);
            this.passwordPanel.PerformLayout();
            this.connectionPanel.ResumeLayout(false);
            this.connectionPanel.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel loginContainer;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel usernamePanel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.Label connectionDot;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label featuresLabel;
    }
}