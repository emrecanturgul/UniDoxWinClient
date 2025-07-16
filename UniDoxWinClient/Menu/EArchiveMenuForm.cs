using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniDoxWinClient.Archive;

namespace UniDoxWinClient
{
    public partial class EArchiveMenuForm : Form
    {
        public EArchiveMenuForm()
        {
            InitializeComponent();
        }

        private void btnFaturaServisi_Click(object sender, EventArgs e)
        {
            var faturaForm = new EArchiveFaturaForm();
            faturaForm.Show();
            this.Hide();
        }

        private void btnRaporServisi_Click(object sender, EventArgs e)
        {
            var raporForm = new EArchiveRaporForm();
            raporForm.Show();
            this.Hide();
        }

        private void btnYuklemeServisi_Click(object sender, EventArgs e)
        {
            var yuklemeForm = new EArchiveYuklemeForm();
            yuklemeForm.Show();
            this.Hide();
        }
    }
}
