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
using UniDoxWinClient.ServiceReference1;

namespace UniDoxWinClient.Methods
{
    public partial class QueryOutboxDocumentsWithReceivedDateForm : Form
    {
        public QueryOutboxDocumentsWithReceivedDateForm()
        {
            InitializeComponent();
        }

        private void QueryOutboxDocumentsWithReceivedDateForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string selected = comboBox1.SelectedItem?.ToString() ?? "";

            string documentType = selected == "fatura" ? "1" :
                                  selected == "uygulama" ? "2" :
                                  "1";
            string queried = comboBox2.SelectedItem?.ToString() ?? "";
            string documentStatus = comboBox3.SelectedItem?.ToString() ?? "";

            var queryClient = new QueryDocumentWSClient();
            using (var scope = new OperationContextScope(queryClient.InnerChannel))
            {
                var prop = new HttpRequestMessageProperty();
                prop.Headers.Add("Username", ServiceHelper.Username);
                prop.Headers.Add("Password", ServiceHelper.Password);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                if (documentStatus == "XML")
                {
                    // Önce tek belge sorgula
                    var inputDocumentList = paramdondur();
                    var responseDocument = queryClient.QueryOutboxDocument(
                        "Document_ID",
                        inputDocumentList.Select(p => p.documentId).First(),
                        "XML"
                    );

                    if (responseDocument?.documents != null && responseDocument.documents.Length > 0)
                    {
                        foreach (var doc in responseDocument.documents)
                        {
                            string xmlContent = "";

                            if (doc.document_content is byte[] byteArray)
                            {
                                xmlContent = Encoding.UTF8.GetString(byteArray);
                            }
                            else
                            {
                                xmlContent = doc.document_content?.ToString() ?? "[Boş içerik]";
                            }

                            string info = $"Belge ID: {doc.document_id}\n" +
                                          $"UUID: {doc.document_uuid}\n" +
                                          $"Zarf UUID: {doc.envelope_uuid}\n" +
                                          $"Fatura Tipi: {doc.document_profile}\n" +
                                          $"Tarih: {doc.document_issue_date}\n" +
                                          $"Gönderen: {doc.source_title} ({doc.source_id})\n" +
                                          $"Alıcı: {doc.destination_title} ({doc.destination_id})\n" +
                                          $"Tutar: {doc.invoice_total} {doc.currency_code}\n" +
                                          $"Durum: {doc.state_explanation}";

                            MessageBox.Show(info, "Belge Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // XML dosyasını masaüstüne kaydet
                            try
                            {
                                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                string file = $"Document_{doc.document_id}_{DateTime.Now:yyyyMMdd_HHmmss}.xml";
                                string fPath = Path.Combine(desktop, file);

                                File.WriteAllText(fPath, xmlContent, Encoding.UTF8);

                                MessageBox.Show($"XML dosyası başarıyla masaüstüne kaydedildi:\n{fPath}",
                                                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Dosya kaydedilirken hata oluştu:\n" + ex.Message,
                                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

                // Tarih aralığıyla sorgu yap
                var dateresponse = queryClient.QueryOutboxDocumentsWithReceivedDate(
                    startDate, endDate, documentType, queried, documentStatus, "0"
                );

                // Temel bilgileri göster
                string x = $"state explanation: {dateresponse.stateExplanation}\n" +
                          $"querystate: {dateresponse.queryState}\n" +
                          $"document count: {dateresponse.documentsCount}\n" +
                          $"maxrecordIdinList: {dateresponse.maxRecordIdinList}";

                MessageBox.Show(x, "WithReceivedDate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // TÜM faturaları MessageBox'ta göster (sınırsız)
                if (dateresponse.documents != null && dateresponse.documents.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"TÜM FATURALAR:");
                    sb.AppendLine(new string('=', 50));

                    int count = 1;
                    foreach (var doc in dateresponse.documents) // Tüm faturalar - sınır yok
                    {
                        sb.AppendLine($"{count}. {doc.document_id} - {doc.source_title} - {doc.invoice_total} {doc.currency_code}");
                        count++;
                    }

                    MessageBox.Show(sb.ToString(), $"Tüm Faturalar (Toplam: {dateresponse.documentsCount})",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Response'u dosyaya kaydet - TÜM FATURALARLA
                string responseText = $"QUERY RESPONSE SONUCU\n";
                responseText += $"========================\n";
                responseText += $"Tarih: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n";
                responseText += $"Sorgu Parametreleri:\n";
                responseText += $"  - Başlangıç Tarihi: {startDate}\n";
                responseText += $"  - Bitiş Tarihi: {endDate}\n";
                responseText += $"  - Dokuman Tipi: {documentType}\n";
                responseText += $"  - Sorgulandı: {queried}\n";
                responseText += $"  - Dokuman Durumu: {documentStatus}\n";
                responseText += $"\nSONUÇ:\n";
                responseText += $"  - State Explanation: {dateresponse.stateExplanation}\n";
                responseText += $"  - Query State: {dateresponse.queryState}\n";
                responseText += $"  - Document Count: {dateresponse.documentsCount}\n";
                responseText += $"  - Max Record ID: {dateresponse.maxRecordIdinList}\n";

                // TÜM faturaları dosyaya ekle (detaylı)
                if (dateresponse.documents != null && dateresponse.documents.Length > 0)
                {
                    responseText += $"\nTÜM FATURA LİSTESİ ({dateresponse.documentsCount} adet):\n";
                    responseText += new string('=', 80) + "\n";

                    int count = 1;
                    foreach (var doc in dateresponse.documents) // TÜM faturalar
                    {
                        responseText += $"\n{count}. FATURA:\n";
                        responseText += $"   - ID: {doc.document_id}\n";
                        responseText += $"   - UUID: {doc.document_uuid}\n";
                        responseText += $"   - Tarih: {doc.document_issue_date}\n";
                        responseText += $"   - Gönderen: {doc.source_title} ({doc.source_id})\n";
                        responseText += $"   - Alıcı: {doc.destination_title} ({doc.destination_id})\n";
                        responseText += $"   - Tutar: {doc.invoice_total} {doc.currency_code}\n";
                        responseText += $"   - Durum: {doc.state_explanation}\n";
                        responseText += $"   - Zarf UUID: {doc.envelope_uuid}\n";
                        responseText += new string('-', 60) + "\n";
                        count++;
                    }
                }

                // Masaüstü yolu
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"AllInvoices_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string fullPath = Path.Combine(desktopPath, fileName);

                try
                {
                    // Dosyaya yaz
                    File.WriteAllText(fullPath, responseText, Encoding.UTF8);

                    // Kullanıcıya bildir
                    MessageBox.Show($"Tüm faturalar başarıyla kaydedildi:\n{fullPath}",
                                    "Dosya Kaydedildi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Dosya kaydedilemedi:\n{ex.Message}",
                                    "Hata",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        public InputDocument[] paramdondur()
        {
            var client = new InvoiceWSClient();
            string file = @"C:\Users\HP\Desktop\a.xml";

            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var prop = new HttpRequestMessageProperty();
                prop.Headers["Username"] = ServiceHelper.Username;
                prop.Headers["Password"] = ServiceHelper.Password;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                string rawXml = File.ReadAllText(file);
                var xml = XDocument.Parse(rawXml);

                string uuidFromXml = xml.Descendants()
                                        .FirstOrDefault(m => m.Name.LocalName == "UUID")
                                        ?.Value;

                // inputDocument hazırla
                var inputDocument = new InputDocument
                {
                    documentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    xmlContent = rawXml,
                    documentUUID = uuidFromXml,
                    sourceUrn = "urn:mail:defaultgb@univera.com.tr",
                    destinationUrn = "urn:mail:defaultpkhotmail@hotmail.com",
                    localId = "1",
                    documentId = "TST2025000000124",
                    documentNoPrefix = "EEE",
                    submitForApproval = true,
                    note = "og"
                };

                var InputDocumentList = new InputDocument[] { inputDocument };
                return InputDocumentList;
            }
        }
    }
}