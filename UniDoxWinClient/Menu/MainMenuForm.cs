using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Cache;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniDoxWinClient.InvoiceWS;
using UniDoxWinClient.Menu;
using UniDoxWinClient.Methods;

namespace UniDoxWinClient
{
    public partial class MainMenuForm : Form
    {
        private int animationStep = 0;
        private Color[] gradientColors = {
            Color.FromArgb(41, 128, 185),
            Color.FromArgb(52, 152, 219),
            Color.FromArgb(155, 89, 182),
            Color.FromArgb(142, 68, 173)
        };

        public MainMenuForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            // Animasyon timer'ını başlat
            animationTimer.Start();

            // Custom title bar butonlarını ekle
            AddCustomTitleBarButtons();

            // Modern efektler
            ApplyModernEffects();
        }

        private void logoPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Circular logo background
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(52, 152, 219)))
            {
                g.FillEllipse(brush, 5, 5, 70, 70);
            }

            // Logo text "UD"
            using (Font font = new Font("Segoe UI", 20, FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString("UD", font, textBrush, new RectangleF(5, 5, 70, 70), sf);
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Modern shadow effect
            Rectangle shadowRect = new Rectangle(3, 3, panel.Width - 6, panel.Height - 6);
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
            {
                g.FillRectangle(shadowBrush, shadowRect);
            }

            // Main panel background with rounded corners
            Rectangle mainRect = new Rectangle(0, 0, panel.Width - 3, panel.Height - 3);
            using (SolidBrush mainBrush = new SolidBrush(Color.White))
            {
                g.FillRectangle(mainBrush, mainRect);
            }

            // Subtle border
            using (Pen borderPen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                g.DrawRectangle(borderPen, mainRect);
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Cursor = Cursors.Hand;

            // Hover animasyonu
            Timer hoverTimer = new Timer();
            hoverTimer.Interval = 30;
            int step = 0;
            Point originalLocation = btn.Location;
            Size originalSize = btn.Size;

            hoverTimer.Tick += (s, args) =>
            {
                step++;
                if (step <= 3)
                {
                    btn.Location = new Point(originalLocation.X - step, originalLocation.Y - step);
                    btn.Size = new Size(originalSize.Width + (step * 2), originalSize.Height + (step * 2));
                }
                else
                {
                    hoverTimer.Stop();
                    hoverTimer.Dispose();
                }
            };
            hoverTimer.Start();
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Cursor = Cursors.Default;

            // Original position'a dön
            Timer leaveTimer = new Timer();
            leaveTimer.Interval = 30;
            int step = 3;

            leaveTimer.Tick += (s, args) =>
            {
                step--;
                if (step >= 0)
                {
                    // Reset to original positions based on button
                    if (btn == btn_credit_count)
                    {
                        btn.Location = new Point(40 - step, 100 - step);
                        btn.Size = new Size(420 + (step * 2), 80 + (step * 2));
                    }
                    else if (btn == btn_prefix)
                    {
                        btn.Location = new Point(40 - step, 200 - step);
                        btn.Size = new Size(420 + (step * 2), 80 + (step * 2));
                    }
                    else if (btn == btn_send_invoice)
                    {
                        btn.Location = new Point(40 - step, 300 - step);
                        btn.Size = new Size(420 + (step * 2), 80 + (step * 2));
                    }
                    else if (btn == btn_user_query)
                    {
                        btn.Location = new Point(40 - step, 150 - step);
                        btn.Size = new Size(490 + (step * 2), 200 + (step * 2));
                    }
                }
                else
                {
                    leaveTimer.Stop();
                    leaveTimer.Dispose();
                }
            };
            leaveTimer.Start();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            animationStep++;

            // Header renk animasyonu
            int colorIndex = (animationStep / 100) % gradientColors.Length;
            int nextColorIndex = (colorIndex + 1) % gradientColors.Length;

            float factor = (animationStep % 100) / 100f;
            Color currentColor = InterpolateColor(gradientColors[colorIndex], gradientColors[nextColorIndex], factor);

            headerPanel.BackColor = currentColor;

            // Connection status animasyonu
            if (animationStep % 60 == 0)
            {
                connectionStatusLabel.ForeColor = connectionStatusLabel.ForeColor == Color.FromArgb(46, 204, 113)
                    ? Color.FromArgb(52, 152, 219)
                    : Color.FromArgb(46, 204, 113);
            }
        }

        private Color InterpolateColor(Color color1, Color color2, float factor)
        {
            int r = (int)(color1.R + factor * (color2.R - color1.R));
            int g = (int)(color1.G + factor * (color2.G - color1.G));
            int b = (int)(color1.B + factor * (color2.B - color1.B));
            return Color.FromArgb(r, g, b);
        }

        // SENİN ORİJİNAL EVENT HANDLER'LARIN - AYNEN KORUNDU
        private void btn_credit_count_Click(object sender, EventArgs e)
        {
            ShowClickAnimation(sender as Button);
            var form = new CreditInfoForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowClickAnimation(sender as Button);
            var form = new PrefixInfoForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowClickAnimation(sender as Button);
            var form = new SendInvoice();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowClickAnimation(sender as Button);
            var form = new UserQueryForm();
            form.ShowDialog();
        }

        private void ShowClickAnimation(Button btn)
        {
            // Click animasyonu
            Color originalColor = btn.BackColor;
            btn.BackColor = Color.FromArgb(Math.Min(255, originalColor.R + 30),
                                          Math.Min(255, originalColor.G + 30),
                                          Math.Min(255, originalColor.B + 30));

            Timer clickTimer = new Timer();
            clickTimer.Interval = 150;
            clickTimer.Tick += (s, args) =>
            {
                btn.BackColor = originalColor;
                clickTimer.Stop();
                clickTimer.Dispose();
            };
            clickTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Form border shadow
            Graphics g = e.Graphics;
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                g.FillRectangle(shadowBrush, new Rectangle(5, 5, this.Width - 10, this.Height - 10));
            }
        }

        // Form drag functionality
        /*
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 1;
            const int HTCAPTION = 2;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if ((int)m.Result == HTCLIENT)
                {
                    Point screenPoint = new Point(m.LParam.ToInt32());
                    Point clientPoint = this.PointToClient(screenPoint);

                    // Header paneline tıklanırsa formu taşınabilir yap
                    if (clientPoint.Y <= headerPanel.Height)
                    {
                        m.Result = (IntPtr)HTCAPTION;
                        return;
                    }
                }
            }

            base.WndProc(ref m);
        }*/

        // Custom title bar buttons
        private void AddCustomTitleBarButtons()
        {
            // Minimize button
            Button minimizeBtn = new Button();
            minimizeBtn.Text = "🗕";
            minimizeBtn.Size = new Size(40, 30);
            minimizeBtn.Location = new Point(this.Width - 120, 10);
            minimizeBtn.FlatStyle = FlatStyle.Flat;
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.BackColor = Color.Transparent;
            minimizeBtn.ForeColor = Color.White;
            minimizeBtn.Font = new Font("Segoe UI", 12);
            minimizeBtn.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            minimizeBtn.MouseEnter += (s, e) => minimizeBtn.BackColor = Color.FromArgb(100, 255, 255, 255);
            minimizeBtn.MouseLeave += (s, e) => minimizeBtn.BackColor = Color.Transparent;
            headerPanel.Controls.Add(minimizeBtn);

            // Close button
            Button closeBtn = new Button();
            closeBtn.Text = "✕";
            closeBtn.Size = new Size(40, 30);
            closeBtn.Location = new Point(this.Width - 80, 10);
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.BackColor = Color.Transparent;
            closeBtn.ForeColor = Color.White;
            closeBtn.Font = new Font("Segoe UI", 12);
            closeBtn.MouseEnter += (s, e) => closeBtn.BackColor = Color.FromArgb(231, 76, 60);
            closeBtn.MouseLeave += (s, e) => closeBtn.BackColor = Color.Transparent;
            closeBtn.Click += (s, e) =>
            {
                if (MessageBox.Show("Uygulamayı kapatmak istediğinizden emin misiniz?",
                                   "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            };
            headerPanel.Controls.Add(closeBtn);
        }

        // Form resize handler
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (headerPanel != null && headerPanel.Controls.Count > 3)
            {
                // Minimize ve close butonlarını yeniden konumlandır
                headerPanel.Controls[headerPanel.Controls.Count - 2].Location = new Point(this.Width - 120, 10);
                headerPanel.Controls[headerPanel.Controls.Count - 1].Location = new Point(this.Width - 80, 10);
            }
        }

        // Modern visual effects
        private void ApplyModernEffects()
        {
            // Rounded corners effect (Windows 10/11)
            try
            {
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            }
            catch
            {
                // Fallback for systems that don't support rounded corners
            }
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

       
    }
}