using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using UniDoxWinClient.InvoiceWS;

namespace UniDoxWinClient
{
    public static class ServiceHelper
    {
        public static string Username { get; set; } = "admin_008678";
        public static string Password { get; set; } = "FFb8rB(Z";

        public static void WithHeaders(Action<InvoiceWSClient> action)
        {
            var client = new InvoiceWSClient();

            using (var scope = new OperationContextScope(client.InnerChannel))
            {
                var props = new HttpRequestMessageProperty();
                props.Headers.Add("Username", Username);
                props.Headers.Add("Password", Password);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = props;

                action(client);
            }
        }
    }
}
