using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UniDoxWinClient.InvoiceWS;

namespace UniDoxWinClient.Menu
{
    public partial class SendInvoice : Form
    {
        public SendInvoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new InvoiceWSClient();
            string file = @"C:\Users\HP\Desktop\a.xml";

            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var prop = new HttpRequestMessageProperty();
                prop.Headers["Username"] = ServiceHelper.Username;
                prop.Headers["Password"] = ServiceHelper.Password;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                // XML içeriğini oku
                string rawXml = File.ReadAllText(file);

                // XML'i parse et
                var xml = XDocument.Parse(rawXml);

                // UUID çek
                string uuidFromXml = xml.Descendants()
                                        .FirstOrDefault(m => m.Name.LocalName == "UUID")
                                        ?.Value;

                // inputDocument hazırla
                var inputDocument = new InputDocument
                {
                    documentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    xmlContent = rawXml,
                    documentUUID = uuidFromXml,
                    sourceUrn = "urn:mail:defaultgb@univera.com.tr", // Bunu dinamik almak istersen: client.getCustomerGBList().users.First().etiket
                    destinationUrn = "urn:mail:defaultpkhotmail@hotmail.com",
                    localId = "1",
                    documentId = "TST2025000000124",
                    documentNoPrefix = "EEE",
                    submitForApproval = true,
                    note = "og"
                };

                var InputDocumentList = new InputDocument[] { inputDocument };

                // Fatura gönder
                var sendinvoice = client.sendInvoice(InputDocumentList);

                // Mesajları göster
                MessageBox.Show(sendinvoice.Select(i => i.explanation).FirstOrDefault());
                MessageBox.Show(sendinvoice.Select(i => i.code).FirstOrDefault());

                // Uygulama yanıtı gönder (zorunlu değilse silebilirsin)
                var app_response = client.sendApplicationResponse(InputDocumentList);
            }
        }
    }
}
