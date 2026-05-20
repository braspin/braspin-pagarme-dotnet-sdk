using PagarmeSDK;

namespace Example.Subscription
{
    class GetSubscriptionById
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);
            string subscrptionId = "sub_05jkdIfGYPfN26mI";

            var response = client.Subscriptions.GetSubscription(subscrptionId);

        }
    }
}

