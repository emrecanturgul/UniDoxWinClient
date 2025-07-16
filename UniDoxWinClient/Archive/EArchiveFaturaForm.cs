using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace UniDoxWinClient.Archive
{
    public partial class EArchiveFaturaForm : Form
    {
        public EArchiveFaturaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new InvoiceWS.InvoiceWSClient();

            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var props = new HttpRequestMessageProperty();
                props.Headers.Add("Username", ServiceHelper.Username); // login'de set ettiysen
                props.Headers.Add("Password", ServiceHelper.Password);

                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = props;

                // şimdi servis çağrısı yapılabilir
                var tc = client.getCustomerGBList().users.Select(x => x.vkn_tckn).First();
                var creditCount = client.getCustomerCreditCount(tc).ToString();


                MessageBox.Show(creditCount);
            }
        }
    }
}
