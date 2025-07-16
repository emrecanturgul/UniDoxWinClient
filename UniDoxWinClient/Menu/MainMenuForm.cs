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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnearsiv_Click(object sender, EventArgs e)
        {
            var eArsivForm = new EArchiveMenuForm();
            eArsivForm.Show();
        }

        private void btnefatura_Click(object sender, EventArgs e)
        {
     //       var eFaturaForm = new EFaturaMenuForm();
     //       eFaturaForm.Show();
        }
    }
}
