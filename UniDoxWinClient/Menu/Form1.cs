using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistem otomatik giriş yaptı.");
            login.Enabled = false;
            MainMenuForm mainMenu = new MainMenuForm(); 
            mainMenu.Show();                             
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtpassword.Text = password;
            txtusername.Text = username;
            txtusername.Enabled = false;
            txtpassword.Enabled = false;

        }

      
    }
}
