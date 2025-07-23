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
using UniDoxWinClient.ServiceReference1;

namespace UniDoxWinClient.Methods
{
    public partial class outbox : Form
    {
        public outbox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var queryClient = new QueryDocumentWSClient();
            try
            {
                using (var scope = new OperationContextScope(queryClient.InnerChannel))
                {
                    var prop = new HttpRequestMessageProperty();
                    prop.Headers.Add("Username", ServiceHelper.Username);
                    prop.Headers.Add("Password", ServiceHelper.Password);
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

                    var response = queryClient.QueryOutboxDocumentsWithDocumentDate(
                        startDate: "2025-01-01",
                        endDate: "2025-01-31",
                        documentType: "1",
                        queried: "ALL",
                        withXML: "NONE",
                        minRecordId: "0"
                    );

                    if (response.queryState == 0)
                    {
                        
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();

                        // Sütunları ekle
                        dataGridView1.Columns.Add("FaturaNo", "Fatura No");
                        dataGridView1.Columns.Add("Tarih", "Düzenleme Tarihi");
                        dataGridView1.Columns.Add("Tutar", "Toplam Tutar");
                        dataGridView1.Columns.Add("ParaBirimi", "Para Birimi");
                        dataGridView1.Columns.Add("AliciUnvan", "Alıcı Unvan");
                        dataGridView1.Columns.Add("Durum", "Durum");
                         
                        // Verileri ekle
                        if (response.documents != null)
                        {
                            foreach (var doc in response.documents)
                            {
                                dataGridView1.Rows.Add(
                                    doc.document_id ?? "N/A",
                                    doc.document_issue_date ?? "N/A",
                                    doc.invoice_total?.ToString() ?? "0",
                                    doc.currency_code ?? "TRY",
                                    doc.destination_urn ?? "N/A",
                                    doc.state_explanation ?? "N/A"
                                );
                            }
                        }

                        MessageBox.Show($"{response.documentsCount} adet fatura bulundu ve listelendi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Sorgu başarısız!\n\nKod: {response.queryState}\nAçıklama: {response.stateExplanation}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                queryClient?.Close();
            }
        }
    }
    }

