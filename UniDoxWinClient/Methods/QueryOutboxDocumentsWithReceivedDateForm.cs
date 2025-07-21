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
            string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string selected = comboBox1.SelectedItem?.ToString() ?? "";

            string documentType = selected == "fatura" ? "1" :
                                  selected == "uygulama" ? "2" :
                                  "1";
            string queried = comboBox2.SelectedItem?.ToString() ?? "";
            string documentStatus = comboBox3.SelectedItem?.ToString() ?? "";

            var inputDocumentList = paramdondur();
            var queryClient = new QueryDocumentWSClient();
            using (var scope = new OperationContextScope(queryClient.InnerChannel))
            {


                var prop = new HttpRequestMessageProperty();
                prop.Headers.Add("Username", ServiceHelper.Username);
                prop.Headers.Add("Password", ServiceHelper.Password);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;
                if (documentStatus == "XML")
            {
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

                        }
                    }
                    


                       

                       var dateresponse =  queryClient.QueryOutboxDocumentsWithReceivedDate(startDate, endDate, documentType, queried, documentStatus , "0" );
                       string LastInvoiceId = $"state explanation: {dateresponse.stateExplanation} " +
                                    $"querystate: {dateresponse.queryState}" +
                                    $"document count: {dateresponse.documentsCount}" +
                                    $"maxrecordIdinList: {dateresponse.maxRecordIdinList}";

                    MessageBox.Show(LastInvoiceId, "GetLastInvoiceIdAndDate ",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);

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


    }
}
