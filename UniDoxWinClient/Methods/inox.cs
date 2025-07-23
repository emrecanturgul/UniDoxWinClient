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
using UniDoxWinClient.ServiceReference1;

namespace UniDoxWinClient.Methods
{
    public partial class inox : Form
    {
        public inox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new QueryDocumentWSClient();
            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var prop = new HttpRequestMessageProperty();
                prop.Headers["Username"] = ServiceHelper.Username;
                prop.Headers["Password"] = ServiceHelper.Password;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                // PDF içerik için "PDF" parametresi kullan
                var response = client.QueryInboxDocument("Document_UUID", "09c9f178-7c75-4c6d-9e0d-227a22a1a740", "PDF");

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Sütunları ekle
                dataGridView1.Columns.Add("FaturaNo", "Fatura No");
                dataGridView1.Columns.Add("Tarih", "Düzenleme Tarihi");
                dataGridView1.Columns.Add("Tutar", "Toplam Tutar");
                dataGridView1.Columns.Add("ParaBirimi", "Para Birimi");
                dataGridView1.Columns.Add("AliciUnvan", "Alıcı Unvan");
                dataGridView1.Columns.Add("Durum", "Durum");
                dataGridView1.Columns.Add("PDF", "PDF İndir"); // Yeni sütun

                // Verileri ekle
                if (response.documents != null && response.documents.Length > 0)
                {
                    foreach (var doc in response.documents)
                    {
                        int rowIndex = dataGridView1.Rows.Add(
                            doc.document_id ?? "N/A",
                            doc.document_issue_date ?? "N/A",
                            doc.invoice_total?.ToString() ?? "0",
                            doc.currency_code ?? "TRY",
                            doc.destination_urn ?? "N/A",
                            doc.state_explanation ?? "N/A",
                            "İndir" // PDF buton metni
                        );

                        // PDF içeriği varsa kaydet
                        if (doc.document_content != null && doc.document_content is byte[] pdfBytes && pdfBytes.Length > 0)
                        {
                            try
                            {
                                // Masaüstü yolu
                                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                string fileName = $"Fatura_{doc.document_id}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                                string fullPath = Path.Combine(desktopPath, fileName);

                                // PDF dosyasını kaydet
                                File.WriteAllBytes(fullPath, pdfBytes);

                                // Satıra dosya yolu bilgisini ekle (gizli olarak)
                                dataGridView1.Rows[rowIndex].Tag = fullPath;

                                Console.WriteLine($"PDF kaydedildi: {fullPath}");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"PDF kaydetme hatası: {ex.Message}", "Hata",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    MessageBox.Show($"{response.documentsCount} adet fatura bulundu ve PDF'leri masaüstüne kaydedildi.",
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belge bulunamadı.", "Bilgi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // DataGridView'deki PDF sütununa tıklandığında PDF'i aç
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // PDF sütununa tıklandıysa
            if (e.ColumnIndex == dataGridView1.Columns["PDF"].Index && e.RowIndex >= 0)
            {
                string pdfPath = dataGridView1.Rows[e.RowIndex].Tag?.ToString();

                if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
                {
                    try
                    {
                        // PDF'i varsayılan uygulama ile aç
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = pdfPath,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"PDF açma hatası: {ex.Message}", "Hata",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("PDF dosyası bulunamadı.", "Hata",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Alternatif: Kullanıcıya dosya yeri seçtirme
        private void button1_Click_WithSaveDialog(object sender, EventArgs e)
        {
            var client = new QueryDocumentWSClient();
            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var prop = new HttpRequestMessageProperty();
                prop.Headers["Username"] = ServiceHelper.Username;
                prop.Headers["Password"] = ServiceHelper.Password;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                var response = client.QueryInboxDocument("Document_UUID", "09c9f178-7c75-4c6d-9e0d-227a22a1a740", "PDF");

                if (response.documents != null && response.documents.Length > 0)
                {
                    foreach (var doc in response.documents)
                    {
                        if (doc.document_content != null && doc.document_content is byte[] pdfBytes && pdfBytes.Length > 0)
                        {
                            // SaveFileDialog ile kullanıcıya dosya yeri seçtir
                            using (SaveFileDialog saveDialog = new SaveFileDialog())
                            {
                                saveDialog.Filter = "PDF Dosyaları|*.pdf";
                                saveDialog.Title = "PDF'i Kaydet";
                                saveDialog.FileName = $"Fatura_{doc.document_id}.pdf";

                                if (saveDialog.ShowDialog() == DialogResult.OK)
                                {
                                    try
                                    {
                                        File.WriteAllBytes(saveDialog.FileName, pdfBytes);
                                        MessageBox.Show($"PDF başarıyla kaydedildi:\n{saveDialog.FileName}",
                                                       "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        // Kaydettiğin dosyayı aç
                                        if (MessageBox.Show("PDF'i açmak ister misiniz?", "PDF Aç",
                                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                            {
                                                FileName = saveDialog.FileName,
                                                UseShellExecute = true
                                            });
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"PDF kaydetme hatası: {ex.Message}", "Hata",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
