using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
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
    public partial class UserQueryForm : Form
    {
        public UserQueryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var queryClient = new QueryDocumentWSClient();

            using (var scope = new OperationContextScope(queryClient.InnerChannel))
            {
                // HTTP başlığı ekle
                var prop = new HttpRequestMessageProperty();
                prop.Headers.Add("Username", ServiceHelper.Username);
                prop.Headers.Add("Password", ServiceHelper.Password);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                // Method 1: Query with date range
                string startDate = "2025-01-01";
                string endDate = "2025-01-31";

                var queryResult = queryClient.QueryUsers(startDate, endDate, "0370368198");


                // Process first query results


                // Get first user's VKN/TCKN for second query


                // Method 2: Query specific user without date filter
                var singleUserResponse = queryClient.QueryUsers(
                    "",                    // startDate - empty
                    "",                    // endDate - empty  
                    "0370368198"        // vkn_tckn - specific user
                );


                var userInfo = singleUserResponse.users[0];

                // Display user information in a message box
                string userDetails = $"VKN/TCKN: {userInfo.vkn_tckn}\n" +
                                   $"Ünvan/Ad: {userInfo.unvan_ad}\n" +
                                   $"Etiket: {userInfo.etiket}\n" +
                                   $"Tip: {userInfo.tip}\n" +
                                   $"İlk Kayıt: {userInfo.ilkKayitZamani}\n" +
                                   $"Etiket Kayıt: {userInfo.etiketKayitZamani}";

                MessageBox.Show(userDetails, "Kullanıcı Bilgileri",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Also write to console (visible in Output window during debug)
                Console.WriteLine("=== User Information ===");
                Console.WriteLine($"VKN/TCKN: {userInfo.vkn_tckn}");
                Console.WriteLine($"Ünvan/Ad: {userInfo.unvan_ad}");
                Console.WriteLine($"Etiket: {userInfo.etiket}");
                Console.WriteLine($"Tip: {userInfo.tip}");
                Console.WriteLine($"İlk Kayıt: {userInfo.ilkKayitZamani}");
                Console.WriteLine($"Etiket Kayıt: {userInfo.etiketKayitZamani}");


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {



            var queryClient = new QueryDocumentWSClient();
            using (var scope = new OperationContextScope(queryClient.InnerChannel))
            {


                var prop = new HttpRequestMessageProperty();
                prop.Headers.Add("Username", ServiceHelper.Username);
                prop.Headers.Add("Password", ServiceHelper.Password);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;
                var responseDocument = queryClient.GetLastInvoiceIdAndDate("0370368198",   prefixdondur());
                string LastInvoiceId = $"state explanation: {responseDocument.stateExplanation} "+                                 
                                       $"querystate: {responseDocument.queryState}" + 
                                       $"document count: {responseDocument.documentsCount}" + 
                                       $"maxrecordIdinList: {responseDocument.maxRecordIdinList}";

                MessageBox.Show(LastInvoiceId, "GetLastInvoiceIdAndDate ",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public string[] prefixdondur()
        {
            var client = new InvoiceWSClient();
            using (var scope = new OperationContextScope(client.InnerChannel))
            {

                var prop = new HttpRequestMessageProperty();
                prop.Headers.Add("Username", ServiceHelper.Username);
                prop.Headers.Add("Password", ServiceHelper.Password);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;
                string[] prefix = new string[100];
                prefix = client.getPrefixList().documents.Select(p => p.reserved1).ToArray();
                return prefix;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var queryClient = new QueryDocumentWSClient();

            using (var scope = new OperationContextScope(queryClient.InnerChannel))
            {


                var prop = new HttpRequestMessageProperty();
                prop.Headers.Add("Username", ServiceHelper.Username);
                prop.Headers.Add("Password", ServiceHelper.Password);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;
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

                      
                        try
                        {
                            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            string fileName = $"Document_{doc.document_id}_{DateTime.Now:yyyyMMdd_HHmmss}.xml";
                            string fullPath = Path.Combine(desktopPath, fileName);

                            File.WriteAllText(fullPath, xmlContent, Encoding.UTF8);

                            MessageBox.Show($"XML dosyası başarıyla masaüstüne kaydedildi:\n{fullPath}",
                                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dosya kaydedilirken hata oluştu:\n" + ex.Message,
                                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    }
                }
                else
                {
                    MessageBox.Show("Belge bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new outbox();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {   Form QueryOutboxDocumentsWithReceivedDateForm = new QueryOutboxDocumentsWithReceivedDateForm();
             QueryOutboxDocumentsWithReceivedDateForm.ShowDialog();
        }
    }
}             
            
           