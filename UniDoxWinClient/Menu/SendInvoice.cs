using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        private static int invoiceCounter = 1;

        public SendInvoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new InvoiceWSClient();

            string file = Path.Combine(Application.StartupPath, "a.xml");

            if (!File.Exists(file))
            {
                MessageBox.Show($"XML dosyası bulunamadı: {file}\n\nDosyanın projeye eklendiğinden ve 'Copy to Output Directory' ayarının 'Copy always' olduğundan emin olun.",
                               "Dosya Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int totalToSend = 1000;
            int successCount = 0;
            int failCount = 0;
            StringBuilder resultLog = new StringBuilder();

            var dialogResult = MessageBox.Show($"{totalToSend} adet fatura gönderilecek. Devam etmek istiyor musunuz?",
                                              "Toplu Fatura Gönderimi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
                return;

            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var prop = new HttpRequestMessageProperty();
                prop.Headers["Username"] = ServiceHelper.Username;
                prop.Headers["Password"] = ServiceHelper.Password;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                string rawXml = File.ReadAllText(file);

                for (int i = 1; i <= totalToSend; i++)
                {
                    try
                    {
                        string newUuid = Guid.NewGuid().ToString();
                        string newDocumentId = GenerateNewDocumentId();

                        string updatedXml = UpdateXmlContent(rawXml, newUuid, newDocumentId);

                        var inputDocument = new InputDocument
                        {
                            documentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                            xmlContent = updatedXml,
                            documentUUID = newUuid,
                            sourceUrn = "urn:mail:defaultgb@univera.com.tr",
                            destinationUrn = "urn:mail:defaultpkhotmail@hotmail.com",
                            localId = invoiceCounter.ToString(),
                            documentId = newDocumentId,
                            note = $"Otomatik toplu gönderim {i}/{totalToSend} - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        };

                        var InputDocumentList = new InputDocument[] { inputDocument };

                        var sendinvoice = client.sendInvoice(InputDocumentList);

                        string explanation = sendinvoice.Select(s => s.explanation).FirstOrDefault() ?? "Açıklama yok";
                        string code = sendinvoice.Select(s => s.code).FirstOrDefault() ?? "Kod yok";
                        string documentUuidResponse = sendinvoice.Select(s => s.documentUUID).FirstOrDefault() ?? "UUID yok";
                        string cause = sendinvoice.Select(s => s.cause).FirstOrDefault() ?? "";

                        string debugInfo = $"Response - Code: {code}, Explanation: {explanation}, UUID: {documentUuidResponse}, Cause: {cause}";

                        // Başarı kontrolü: Kod "000" veya explanation "başarıyla" içeriyorsa başarılı
                        bool isSuccess = (code == "000" || code == "0") ||
                                        (explanation != null && explanation.ToLower().Contains("başarıyla"));

                        if (isSuccess)
                        {
                            successCount++;
                            invoiceCounter++;
                            resultLog.AppendLine($"✓ Fatura {i}: Başarılı - UUID: {newUuid.Substring(0, 8)}... - ID: {newDocumentId}");
                            resultLog.AppendLine($"  {debugInfo}");
                        }
                        else
                        {
                            failCount++;
                            resultLog.AppendLine($"✗ Fatura {i}: Başarısız - {explanation} (Kod: {code})");
                            resultLog.AppendLine($"  {debugInfo}");
                            if (!string.IsNullOrEmpty(cause))
                            {
                                resultLog.AppendLine($"  Sebep: {cause}");
                            }
                        }

                        if (i % 10 == 0)
                        {
                            this.Text = $"SendInvoice - İşlem: {i}/{totalToSend} - Başarılı: {successCount} - Başarısız: {failCount}";
                            Application.DoEvents();
                        }

                       // System.Threading.Thread.Sleep(1);
                    }
                    catch (Exception ex)
                    {
                        failCount++;
                        resultLog.AppendLine($"✗ Fatura {i}: Hata - {ex.Message}");
                    }
                }
            }

            string finalMessage = $"Toplu fatura gönderimi tamamlandı!\n\n" +
                                 $"Toplam: {totalToSend}\n" +
                                 $"Başarılı: {successCount}\n" +
                                 $"Başarısız: {failCount}\n\n" +
                                 $"Detaylar:\n{resultLog.ToString()}";

            string logFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                         "bulk_invoice_log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt");
            File.WriteAllText(logFile, finalMessage);

            MessageBox.Show($"Başarılı: {successCount}/{totalToSend}\nBaşarısız: {failCount}/{totalToSend}\n\nDetaylı log: {logFile}",
                           "Toplu Gönderim Sonucu", MessageBoxButtons.OK,
                           successCount == totalToSend ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            this.Text = "SendInvoice";
        }

        private string GenerateNewDocumentId()
        {
            Random random = new Random();
            return $"ESK{DateTime.Now.Year}{random.Next(100000000, 999999999)}";
        }

        private string UpdateXmlContent(string xmlContent, string newUuid, string newDocumentId)
        {
            try
            {
                var xml = XDocument.Parse(xmlContent);

                var namespaces = xml.Root.Attributes()
                    .Where(a => a.IsNamespaceDeclaration)
                    .GroupBy(a => a.Name.Namespace == XNamespace.None ? String.Empty : a.Name.LocalName,
                             a => XNamespace.Get(a.Value))
                    .ToDictionary(g => g.Key, g => g.First());

                var uuidElements = xml.Descendants()
                                     .Where(x => x.Name.LocalName == "UUID");

                foreach (var element in uuidElements)
                {
                    element.Value = newUuid;
                }

                var idElements = xml.Descendants()
                                   .Where(x => x.Name.LocalName == "ID" &&
                                          (x.Parent?.Name.LocalName == "Invoice" ||
                                           x.Parent?.Name.LocalName == "InvoiceLine" ||
                                           x.Value.Contains("ESK") ||
                                           x.Value.Contains("TST") ||
                                           x.Value.Contains("2025") ||
                                           (x.Parent?.Name.LocalName == "cbc" && x.Name.LocalName == "ID")));

                foreach (var element in idElements)
                {
                    if (element.Parent?.Name.LocalName == "Invoice" ||
                        element.Value.StartsWith("ESK") ||
                        element.Value.StartsWith("TST") ||
                        element.Value.Contains("2025"))
                    {
                        element.Value = newDocumentId;
                    }
                }

                var issueDateElements = xml.Descendants()
                                          .Where(x => x.Name.LocalName == "IssueDate");

                foreach (var element in issueDateElements)
                {
                    element.Value = DateTime.Now.ToString("yyyy-MM-dd");
                }

                var typeCodeElements = xml.Descendants()
                                         .Where(x => x.Name.LocalName == "InvoiceTypeCode");

                foreach (var element in typeCodeElements)
                {
                    if (string.IsNullOrEmpty(element.Value))
                    {
                        element.Value = "SATIS";
                    }
                }

                var profileElements = xml.Descendants()
                                        .Where(x => x.Name.LocalName == "ProfileID");

                foreach (var element in profileElements)
                {
                    if (string.IsNullOrEmpty(element.Value))
                    {
                        element.Value = "TEMELFATURA";
                    }
                }

                return xml.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"XML güncelleme hatası: {ex.Message}\n\nDetay: {ex.StackTrace}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return xmlContent;
            }
        }
    }
}