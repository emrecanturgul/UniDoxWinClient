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

        private void button2_Click(object sender, EventArgs e)
        {
            
            var client = new InvoiceWSClient();
           

            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var prop = new HttpRequestMessageProperty();
                prop.Headers["Username"] = ServiceHelper.Username;
                prop.Headers["Password"] = ServiceHelper.Password;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                var prefixResponse = client.getPrefixList();

                textBox1.Clear();
                foreach (var item in prefixResponse.documents)
                {
                    // Tüm alanları tek satıra yaz veya ayrı ayrı satırlara yaz
                    string line = $"Prefix: {item.reserved1}, Aktif: {item.reserved2}, Mail Durumu: {item.emailSent}";
                    textBox1.AppendText(line + Environment.NewLine);
                }
            }
        } 





        private void PrefixInfoForm_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
        }
    }
}
