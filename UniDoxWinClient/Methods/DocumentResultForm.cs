
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UniDoxWinClient.Methods
{
    public partial class DocumentResultsForm : Form
    {
        public DocumentResultsForm()
        {
            InitializeComponent();
        }

        public void ShowResults(string title, string queryInfo, object[] documents)
        {
            this.Text = title;
            lblQueryInfo.Text = queryInfo;

            dataGridView1.Rows.Clear();

            if (documents != null && documents.Length > 0)
            {
                int count = 1;
                foreach (var doc in documents)
                {
                    var docType = doc.GetType();
                    var id = docType.GetProperty("document_id")?.GetValue(doc)?.ToString() ?? "N/A";
                    var uuid = docType.GetProperty("document_uuid")?.GetValue(doc)?.ToString() ?? "N/A";
                    var date = docType.GetProperty("document_issue_date")?.GetValue(doc)?.ToString() ?? "N/A";
                    var sourceTitle = docType.GetProperty("source_title")?.GetValue(doc)?.ToString() ?? "N/A";
                    var destTitle = docType.GetProperty("destination_title")?.GetValue(doc)?.ToString() ?? "N/A";
                    var total = docType.GetProperty("invoice_total")?.GetValue(doc)?.ToString() ?? "N/A";
                    var state = docType.GetProperty("state_explanation")?.GetValue(doc)?.ToString() ?? "N/A";

                    dataGridView1.Rows.Add(count, id, uuid, date, sourceTitle, destTitle, total, state);
                    count++;
                }
            }
        }

        private void DocumentResultsForm_Load(object sender, EventArgs e)
        {
            // Form load işlemleri
        }
    }
}