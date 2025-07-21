using System;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using UniDoxWinClient.InvoiceWS;
using System.Linq;

namespace UniDoxWinClient
{
    public partial class CreditInfoForm : Form
    {
        public CreditInfoForm()
        {
            InitializeComponent();
        }

        private void CreditInfoForm_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new InvoiceWSClient();

            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var prop = new HttpRequestMessageProperty();
                prop.Headers["Username"] = ServiceHelper.Username;
                prop.Headers["Password"] = ServiceHelper.Password;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;



                var gbList = client.getCustomerGBList();


                var vknTckn = gbList.users.Select(p => p.vkn_tckn).FirstOrDefault();
                textBox1.Text = vknTckn;
            }
        }
        

        private void button2_Click_1(object sender, EventArgs e)
        {
            var client = new InvoiceWSClient();

            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var prop = new HttpRequestMessageProperty();
                prop.Headers["Username"] = ServiceHelper.Username;
                prop.Headers["Password"] = ServiceHelper.Password;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;
                var gbList = client.getCustomerGBList();


                var vknTckn = gbList.users.Select(p => p.vkn_tckn).FirstOrDefault();
                textBox2.Text = client.getCustomerCreditCount(vknTckn).remainCredit.ToString();
                textBox3.Text = client.getCustomerCreditCount(vknTckn).totalCredit.ToString();

               

                
            }

        }

        private void CreditInfoForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}