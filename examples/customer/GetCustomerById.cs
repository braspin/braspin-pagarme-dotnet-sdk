using PagarmeSDK;

namespace Example.Customer
{
    class GetCustomerById
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);

            string customerId = "cus_6l5dMWZ0hkHZ4XnE";

            var response = client.Customers.GetCustomer(customerId);
        }
    }
}

