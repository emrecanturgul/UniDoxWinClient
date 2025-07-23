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
    public partial class UserQueryForm : Form
    {
        public UserQueryForm()
        {
            InitializeComponent();
        }

        private void ShowLoadingStatus(string message)
        {
            statusLabel.Text = "Yükleniyor: " + message;
            statusLabel.ForeColor = Color.Orange;
            Application.DoEvents();
        }

        private void ShowSuccessStatus(string message)
        {
            statusLabel.Text = "Başarılı: " + message;
            statusLabel.ForeColor = Color.Green;
        }

        private void ShowErrorStatus(string message)
        {
            statusLabel.Text = "Hata: " + message;
            statusLabel.ForeColor = Color.Red;
        }

        private void ResetStatus()
        {
            statusLabel.Text = "Sistem hazır - E-Fatura Query operasyonları kullanılabilir";
            statusLabel.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Kullanıcı bilgileri sorgulanıyor...");
            try
            {
                var queryClient = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(queryClient.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers.Add("Username", ServiceHelper.Username);
                    prop.Headers.Add("Password", ServiceHelper.Password);
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    string startDate = "2025-01-01";
                    string endDate = "2025-01-31";
                    var queryResult = queryClient.QueryUsers(startDate, endDate, "0370368198");
                    var singleUserResponse = queryClient.QueryUsers("", "", "6621610117");
                    var userInfo = singleUserResponse.users[0];

                    string userDetails = $"VKN/TCKN: {userInfo.vkn_tckn}\n" +
                                       $"Ünvan/Ad: {userInfo.unvan_ad}\n" +
                                       $"Etiket: {userInfo.etiket}\n" +
                                       $"Tip: {userInfo.tip}\n" +
                                       $"İlk Kayıt: {userInfo.ilkKayitZamani}\n" +
                                       $"Etiket Kayıt: {userInfo.etiketKayitZamani}";

                    MessageBox.Show(userDetails, "Kullanıcı Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("Kullanıcı bilgileri başarıyla alındı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Kullanıcı sorgulanırken hata: {ex.Message}");
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Son fatura numarası alınıyor...");
            try
            {
                var queryClient = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(queryClient.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers.Add("Username", ServiceHelper.Username);
                    prop.Headers.Add("Password", ServiceHelper.Password);
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var responseDocument = queryClient.GetLastInvoiceIdAndDate("0370368198", prefixdondur());
                    string LastInvoiceId = $"State Explanation: {responseDocument.stateExplanation}\n" +
                                           $"Query State: {responseDocument.queryState}\n" +
                                           $"Document Count: {responseDocument.documentsCount}\n" +
                                           $"Max Record ID: {responseDocument.maxRecordIdinList}";

                    MessageBox.Show(LastInvoiceId, "Son Fatura Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("Son fatura numarası başarıyla alındı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Son fatura numarası alınırken hata: {ex.Message}");
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Outbox document tarih sorgusu açılıyor...");
            try
            {
                var form = new outbox();
                form.ShowDialog();
                ShowSuccessStatus("Outbox form kapatıldı");
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Form açılırken hata: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Outbox belgesi sorgulanıyor...");
            try
            {
                var queryClient = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(queryClient.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers.Add("Username", ServiceHelper.Username);
                    prop.Headers.Add("Password", ServiceHelper.Password);
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var inputDocumentList = paramdondur();
                    var responseDocument = queryClient.QueryOutboxDocument("Document_ID", inputDocumentList.Select(p => p.documentId).First(), "XML");

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
                                MessageBox.Show($"XML dosyası başarıyla masaüstüne kaydedildi:\n{fullPath}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Dosya kaydedilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        ShowSuccessStatus("Outbox belgesi başarıyla sorgulandı");
                    }
                    else
                    {
                        MessageBox.Show("Belge bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ShowErrorStatus("Belge bulunamadı");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Outbox belgesi sorgulanırken hata: {ex.Message}");
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Outbox alınma tarihi sorgusu açılıyor...");
            try
            {
                Form QueryOutboxDocumentsWithReceivedDateForm = new QueryOutboxDocumentsWithReceivedDateForm();
                QueryOutboxDocumentsWithReceivedDateForm.ShowDialog();
                ShowSuccessStatus("Outbox received date form kapatıldı");
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Form açılırken hata: {ex.Message}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Local ID ile sorgulama yapılıyor...");
            try
            {
                string file = @"C:\Users\HP\Desktop\a.xml";
                string rawXml = File.ReadAllText(file);
                var xml = XDocument.Parse(rawXml);
                string uuidFromXml = xml.Descendants().FirstOrDefault(m => m.Name.LocalName == "UUID")?.Value;

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
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    string localId = InputDocumentList.Select(p => p.localId).FirstOrDefault();
                    var response = client.QueryOutboxDocumentWithLocalId(localId);

                    // İnovatif çözüm: Modern DataGrid ile sonuçları göster
                    var resultsForm = new DocumentResultsForm();

                    string queryInfo = $"Local ID: {localId} | Query State: {response.queryState} | " +
                                     $"State Explanation: {response.stateExplanation} | " +
                                     $"Document Count: {response.documentsCount} | " +
                                     $"Max Record ID: {response.maxRecordIdinList}";

                    resultsForm.ShowResults("Query Outbox With Local ID", queryInfo, response.documents);
                    resultsForm.ShowDialog();

                    ShowSuccessStatus("Local ID sorgusu tamamlandı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Local ID sorgusu sırasında hata: {ex.Message}");
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("GUID listesi ile sorgulama yapılıyor...");
            try
            {
                string file = @"C:\Users\HP\Desktop\a.xml";
                string rawXml = File.ReadAllText(file);
                var xml = XDocument.Parse(rawXml);
                string uuidFromXml = xml.Descendants().FirstOrDefault(m => m.Name.LocalName == "UUID")?.Value;

                if (string.IsNullOrEmpty(uuidFromXml))
                {
                    MessageBox.Show("XML'den UUID bulunamadı!", "Hata");
                    ShowErrorStatus("XML'den UUID bulunamadı");
                    return;
                }

                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    List<string> guidList = new List<string>
                    {
                        "652b9876-9778-458f-85a0-f79637214a46",
                        "e421fa2c-ef66-482d-b18d-ea27dd8e9ae9"
                    };

                    if (!string.IsNullOrEmpty(uuidFromXml))
                    {
                        guidList.Add(uuidFromXml);
                    }

                    string[] guidArray = guidList.ToArray();
                    string documentType = "1";
                    var response = client.QueryOutboxDocumentsWithWithGUIDList(guidArray, documentType);

                    string result = $"QUERY OUTBOX WITH GUID LIST SONUCU\n===================================\n";
                    result += $"Gönderilen GUID sayısı: {guidArray?.Length ?? 0}\n";
                    result += $"Query State: {response?.queryState ?? -999}\n";
                    result += $"State Explanation: {response?.stateExplanation ?? "NULL"}\n";
                    result += $"Documents Count: {response?.documentsCount ?? -1}\n\n";

                    if (response != null && response.documents != null && response.documents.Length > 0)
                    {
                        result += $"BULUNAN BELGELER ({response.documents.Length} adet):\n" + new string('-', 40) + "\n";
                        for (int i = 0; i < response.documents.Length; i++)
                        {
                            var doc = response.documents[i];
                            result += $"{i + 1}. BELGE:\n";
                            result += $"   - ID: {doc?.document_id ?? "NULL"}\n";
                            result += $"   - UUID: {doc?.document_uuid ?? "NULL"}\n";
                            result += $"   - Tarih: {doc?.document_issue_date ?? "NULL"}\n";
                            result += $"   - Gönderen: {doc?.source_title ?? "NULL"} ({doc?.source_id ?? "NULL"})\n";
                            result += $"   - Alıcı: {doc?.destination_title ?? "NULL"} ({doc?.destination_id ?? "NULL"})\n";
                            result += $"   - Tutar: {doc?.invoice_total ?? "NULL"} {doc?.currency_code ?? "NULL"}\n";
                            result += $"   - Durum: {doc?.state_explanation ?? "NULL"}\n";
                            result += new string('-', 40) + "\n";
                        }
                    }
                    else
                    {
                        result += "BELGE BULUNAMADI!\n";
                    }

                    MessageBox.Show(result, "Query Outbox With GUID List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("GUID listesi sorgusu tamamlandı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"GUID listesi sorgusu sırasında hata: {ex.Message}");
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Inbox form açılıyor...");
            try
            {
                Form inox = new inox();
                inox.ShowDialog();
                ShowSuccessStatus("Inbox form kapatıldı");
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Form açılırken hata: {ex.Message}");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Inbox belgeler tarih ile sorgulanıyor...");
            try
            {
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var response = client.QueryInboxDocumentsWithDocumentDate("2025-01-01", "2025-07-22", "1", "ALL", "PDF", "ALL", "0");

                    string info = "";
                    foreach (var item in response.documents)
                    {
                        info += $"Document ID: {item.document_id}\n" +
                                $"UUID: {item.document_uuid}\n" +
                                $"Issue Date: {item.document_issue_date}\n" +
                                $"Total Amount: {item.invoice_total} {item.currency_code}\n" +
                                $"State Explanation: {item.state_explanation}\n\n";
                    }
                    MessageBox.Show(info, "Inbox Documents", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("Inbox belgeler başarıyla sorgulandı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Inbox belge sorgusu sırasında hata: {ex.Message}");
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Inbox belgeler alınma tarihi ile sorgulanıyor...");
            try
            {
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var response = client.QueryInboxDocumentsWithReceivedDate("2025-01-01 00:00:00 ", "2025-07-22 23:59:59", "1", "ALL", "XML", "ALL", "1");

                    string info = "";
                    foreach (var item in response.documents)
                    {
                        info += $"Document ID: {item.document_id}\n" +
                                $"UUID: {item.document_uuid}\n" +
                                $"Issue Date: {item.document_issue_date}\n" +
                                $"Total Amount: {item.invoice_total} {item.currency_code}\n" +
                                $"State Explanation: {item.state_explanation}\n\n";
                    }
                    MessageBox.Show(info, "Inbox Documents", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("Inbox belgeler alınma tarihi ile sorgulandı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Inbox belge sorgusu sırasında hata: {ex.Message}");
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Inbox GUID listesi sorgulanıyor...");
            try
            {
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    List<string> strings = new List<string>();
                    strings.Add("09c9f178-7c75-4c6d-9e0d-227a22a1a740");
                    strings.Add("652b9876-9778-458f-85a0-f79637214a46");

                    var resp = client.QueryInboxDocumentsWithGUIDList(strings.ToArray(), "1");

                    string info = "";
                    foreach (var item in resp.documents)
                    {
                        info += $"Document ID: {item.document_id}\n" +
                                $"UUID: {item.document_uuid}\n" +
                                $"Issue Date: {item.document_issue_date}\n" +
                                $"Total Amount: {item.invoice_total} {item.currency_code}\n" +
                                $"State Explanation: {item.state_explanation}\n\n";
                    }
                    MessageBox.Show(info, "Inbox Documents", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("Inbox GUID listesi sorgulandı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Inbox GUID sorgusu sırasında hata: {ex.Message}");
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("User GB listesi indiriliyor...");
            try
            {
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var result = client.GetNewUserGBList();

                    string fileName = result.fileName ?? "output.zip";
                    byte[] byteIcerik = result.fileContent;

                    if (byteIcerik != null && byteIcerik.Length > 0)
                    {
                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string fullPath = Path.Combine(desktopPath, fileName);
                        File.WriteAllBytes(fullPath, byteIcerik);
                        MessageBox.Show("Zip dosyası masaüstüne kaydedildi:\n" + fullPath, "Başarılı");
                        ShowSuccessStatus("User GB listesi başarıyla indirildi");
                    }
                    else
                    {
                        MessageBox.Show("Dosya içeriği boş.", "Uyarı");
                        ShowErrorStatus("Dosya içeriği boş");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"User GB listesi indirme hatası: {ex.Message}");
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Inbox uygulama yanıtı sorgulanıyor...");
            try
            {
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var result = client.QueryAppResponseOfInboxDocument("09c9f178-7c75-4c6d-9e0d-227a22a1a740", "YES");

                    string info = "";
                    foreach (var item in result.documents)
                    {
                        info += $"Document ID: {item.document_id}\n" +
                               $"UUID: {item.document_uuid}\n" +
                               $"Issue Date: {item.document_issue_date}\n\n";
                    }
                    MessageBox.Show(info, "Inbox App Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("Inbox uygulama yanıtı sorgulandı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Inbox uygulama yanıtı sorgusu hatası: {ex.Message}");
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Outbox uygulama yanıtı sorgulanıyor...");
            try
            {
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var result = client.QueryAppResponseOfOutboxDocument("09c9f178-7c75-4c6d-9e0d-227a22a1a740", "YES");

                    string info = "";
                    foreach (var item in result.documents)
                    {
                        info += $"Document ID: {item.document_id}\n" +
                               $"UUID: {item.document_uuid}\n" +
                               $"Issue Date: {item.document_issue_date}\n\n";
                    }
                    MessageBox.Show(info, "Outbox App Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("Outbox uygulama yanıtı sorgulandı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Outbox uygulama yanıtı sorgusu hatası: {ex.Message}");
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Entegratör işaretlemesi yapılıyor...");
            try
            {
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    List<string> strings = new List<string>();
                    strings.Add("09c9f178-7c75-4c6d-9e0d-227a22a1a740");

                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var result = client.SetTakenFromEntegrator(strings.ToArray());

                    string info = "";
                    info += $"State Explanation: {result.stateExplanation}\n" +
                                $"Query State: {result.queryState}\n" +
                                $"Document Count: {result.documentsCount}\n" +
                                $"Max Record ID: {result.maxRecordIdinList}\n\n";

                    foreach (var item in result.documents)
                    {
                        info += $"Document ID: {item.document_id}\n" +
                                $"UUID: {item.document_uuid}\n" +
                                $"Issue Date: {item.document_issue_date}\n" +
                                $"Total Amount: {item.invoice_total} {item.currency_code}\n" +
                                $"State Explanation: {item.state_explanation}\n\n";
                    }
                    MessageBox.Show(info, "Set Taken From Entegrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("Entegratör işaretlemesi tamamlandı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Entegratör işaretleme hatası: {ex.Message}");
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("User PK listesi indiriliyor...");
            try
            {
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var resultx = client.GetNewUserPKList();

                    string fileName = resultx.fileName ?? "output.zip";
                    byte[] byteIcerik = resultx.fileContent;

                    if (byteIcerik != null && byteIcerik.Length > 0)
                    {
                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string fullPath = Path.Combine(desktopPath, fileName);
                        File.WriteAllBytes(fullPath, byteIcerik);
                        MessageBox.Show("Zip dosyası masaüstüne kaydedildi:\n" + fullPath, "Başarılı");
                        ShowSuccessStatus("User PK listesi başarıyla indirildi");
                    }
                    else
                    {
                        MessageBox.Show("Dosya içeriği boş.", "Uyarı");
                        ShowErrorStatus("Dosya içeriği boş");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"User PK listesi indirme hatası: {ex.Message}");
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ShowLoadingStatus("Zarf sorgulanıyor...");
            try
            {
                var client = new QueryDocumentWSClient();
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers["Username"] = ServiceHelper.Username;
                    prop.Headers["Password"] = ServiceHelper.Password;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var response = client.QueryEnvelope("20e670e8-422a-4a60-98f1-6ad791962ed7", 1, 1, "09c9f178-7c75-4c6d-9e0d-227a22a1a740", "1");

                    MessageBox.Show($"Zarf Durumu: {response.stateExplanation}", "Query Envelope", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSuccessStatus("Zarf sorgusu tamamlandı");
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Zarf sorgusu hatası: {ex.Message}");
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void UserQueryForm_Load(object sender, EventArgs e)
        {
            ResetStatus();
            this.ActiveControl = button1;
        }
    }

   
}