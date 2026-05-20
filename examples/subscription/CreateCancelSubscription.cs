using PagarmeSDK;
using PagarmeSDK.Models;

namespace Example.Subscription
{
    class CreateCancelSubscription
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);

            string subscrptionId = "sub_WeEMlp2FXFMjVq3Q";

            var request = new CreateCancelSubscriptionRequest
            {
                CancelPendingInvoices = true
            };

            var response = client.Subscriptions.CancelSubscription(subscrptionId, request);
        }
    }
}

