
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btn_credit_count_Click(object sender, EventArgs e)
        {
            var form = new CreditInfoForm(); // parametresiz açıyorsan
            form.ShowDialog();
            
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new PrefixInfoForm(); 
            form.ShowDialog(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new SendInvoice(); 
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new UserQueryForm(); 
            form.ShowDialog();
        }
    }
}
