using PagarmeSDK;

namespace Example.Order
{
    class GetOrderById
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);

            string orderId = "or_9j8m1E4f6HonwYA0";


            var response = client.Orders.GetOrder(orderId);
        }

    }
}

