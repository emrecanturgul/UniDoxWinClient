using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniDoxWinClient.InvoiceWS;

namespace UniDoxWinClient.Methods
{
    public partial class PrefixInfoForm : Form
    {
        public PrefixInfoForm()
        {
            InitializeComponent();
        }

        private void btnLoadPrefixes_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new InvoiceWSClient();

                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var prefixResponse = client.getPrefixList();

                    dataGridView1.Rows.Clear();

                    foreach (var item in prefixResponse.documents)
                    {
                        string status = item.reserved2 == "1" ? "Aktif" : "Pasif";
                        string emailStatus = item.emailSent == 1 ? "Gönderildi" : "Gönderilmedi";

                        dataGridView1.Rows.Add(item.reserved1, status, emailStatus);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Prefix listesi yüklenirken hata oluştu: {ex.Message}",
                               "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrefixInfoForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde otomatik olarak prefix listesini yükle
            btnLoadPrefixes_Click(null, null);
        }
    }
}