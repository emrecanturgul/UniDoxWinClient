using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniDoxWinClient
{
    public partial class Form1 : Form
    {
        public static string username = "admin_008678";
        public static string password = "FFb8rB(Z";

        // Simple state variables
        private bool isLoading = false;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Otomatik değerleri ata
            txtusername.Text = username;
            txtpassword.Text = password;
            txtusername.Enabled = false;
            txtpassword.Enabled = false;

            // Form ayarları
            this.BackColor = Color.FromArgb(102, 126, 234);

            // Container normal opacity
            loginContainer.BackColor = Color.FromArgb(250, 250, 250);

            // TextBox'ları güzelleştir
            SetupTextBoxes();
        }

        private void SetupTextBoxes()
        {
            // Username TextBox styling
            txtusername.BackColor = Color.FromArgb(248, 249, 250);
            txtusername.ForeColor = Color.FromArgb(108, 117, 125);

            // Password TextBox styling
            txtpassword.BackColor = Color.FromArgb(248, 249, 250);
            txtpassword.ForeColor = Color.FromArgb(108, 117, 125);
        }

        #region Paint Events - Visual Effects

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            // Static gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                mainPanel.ClientRectangle,
                Color.FromArgb(102, 126, 234),
                Color.FromArgb(118, 75, 162),
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, mainPanel.ClientRectangle);
            }

            // Static decorative shapes
            DrawStaticShapes(e.Graphics);
        }

        private void DrawStaticShapes(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
            {
                // Static shape positions
                g.FillEllipse(brush, 50, 80, 120, 120);
                g.FillEllipse(brush, mainPanel.Width - 200, mainPanel.Height - 150, 80, 80);
                g.FillEllipse(brush, 100, mainPanel.Height - 120, 60, 60);
            }
        }

        private void loginContainer_Paint(object sender, PaintEventArgs e)
        {
            // Rounded rectangle with shadow effect
            Rectangle rect = new Rectangle(0, 0, loginContainer.Width - 1, loginContainer.Height - 1);

            // Shadow
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                Rectangle shadowRect = new Rectangle(rect.X + 3, rect.Y + 3, rect.Width, rect.Height);
                DrawRoundedRectangle(e.Graphics, shadowBrush, shadowRect, 20);
            }

            // Main container
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(250, 250, 250)))
            {
                DrawRoundedRectangle(e.Graphics, brush, rect, 20);
            }

            // Border
            using (Pen pen = new Pen(Color.FromArgb(50, 255, 255, 255), 1))
            {
                DrawRoundedRectangle(e.Graphics, pen, rect, 20);
            }
        }

        private void logoPanel_Paint(object sender, PaintEventArgs e)
        {
            // Static circular logo with gradient and shadow
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, logoPanel.Width, logoPanel.Height);

            // Shadow
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
            {
                Rectangle shadowRect = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height);
                e.Graphics.FillEllipse(shadowBrush, shadowRect);
            }

            // Gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(102, 126, 234),
                Color.FromArgb(118, 75, 162),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillEllipse(brush, rect);
            }
        }

        private void loginButton_Paint(object sender, PaintEventArgs e)
        {
            // Custom gradient button
            Rectangle rect = new Rectangle(0, 0, loginButton.Width - 1, loginButton.Height - 1);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(102, 126, 234),
                Color.FromArgb(118, 75, 162),
                LinearGradientMode.Vertical))
            {
                DrawRoundedRectangle(e.Graphics, brush, rect, 12);
            }

            // Text
            string text = isLoading ? "Giriş yapılıyor..." : loginButton.Text;
            using (SolidBrush textBrush = new SolidBrush(loginButton.ForeColor))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(text, loginButton.Font, textBrush, rect, sf);
            }
        }

        private void connectionDot_Paint(object sender, PaintEventArgs e)
        {
            // Static connection dot
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(40, 167, 69)))
            {
                e.Graphics.FillEllipse(brush, 0, 0, connectionDot.Width, connectionDot.Height);
            }
        }

        #endregion

        #region Helper Methods

        private void DrawRoundedRectangle(Graphics g, Brush brush, Rectangle rect, int radius)
        {
            using (GraphicsPath path = GetRoundedRectPath(rect, radius))
            {
                g.FillPath(brush, path);
            }
        }

        private void DrawRoundedRectangle(Graphics g, Pen pen, Rectangle rect, int radius)
        {
            using (GraphicsPath path = GetRoundedRectPath(rect, radius))
            {
                g.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        #endregion

        #region Control Events

        private void txtusername_Enter(object sender, EventArgs e)
        {
            AnimateTextBoxFocus(txtusername, true);
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            AnimateTextBoxFocus(txtusername, false);
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            AnimateTextBoxFocus(txtpassword, true);
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            AnimateTextBoxFocus(txtpassword, false);
        }

        private void AnimateTextBoxFocus(TextBox textBox, bool focused)
        {
            if (focused)
            {
                textBox.BackColor = Color.White;
                textBox.Parent.BackColor = Color.FromArgb(102, 126, 234);
            }
            else
            {
                textBox.BackColor = Color.FromArgb(248, 249, 250);
                textBox.Parent.BackColor = Color.Transparent;
            }
        }

        private void loginButton_MouseEnter(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                loginButton.BackColor = Color.FromArgb(92, 116, 224);
                Cursor = Cursors.Hand;
            }
        }

        private void loginButton_MouseLeave(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                loginButton.BackColor = Color.FromArgb(102, 126, 234);
                Cursor = Cursors.Default;
            }
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            await PerformLogin();
        }

        // Legacy method for compatibility
        private async void login_Click(object sender, EventArgs e)
        {
            await PerformLogin();
        }

        private async Task PerformLogin()
        {
            if (isLoading) return;

            // Start loading animation
            isLoading = true;
            loginButton.Enabled = false;
            loginButton.BackColor = Color.FromArgb(150, 150, 150);

            // Hide any previous status
            statusLabel.Visible = false;

            // Simulate loading time
            await Task.Delay(2000);

            // Show success message
            statusLabel.Text = "Giriş başarılı! Ana menüye yönlendiriliyorsunuz...";
            statusLabel.ForeColor = Color.FromArgb(21, 87, 36);
            statusLabel.BackColor = Color.FromArgb(212, 237, 218);
            statusLabel.Visible = true;

            await Task.Delay(1500);

            // Open main menu and hide current form
            try
            {
                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // If MainMenuForm doesn't exist, show message
                MessageBox.Show($"Ana menü açılacak...\n\nGeliştirici notu: MainMenuForm sınıfı oluşturulmalı.\n\nHata: {ex.Message}",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset login state
                isLoading = false;
                loginButton.Enabled = true;
                loginButton.BackColor = Color.FromArgb(102, 126, 234);
                statusLabel.Visible = false;
            }
        }

        #endregion

        #region Form Events

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Prevent default background painting for better performance
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Center the login container
            if (loginContainer != null)
            {
                loginContainer.Left = (this.Width - loginContainer.Width) / 2;
                loginContainer.Top = (this.Height - loginContainer.Height) / 2;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // No timers to clean up
            base.OnFormClosed(e);
        }

        #endregion
    }
}