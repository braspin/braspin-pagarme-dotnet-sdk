using PagarmeSDK;
using PagarmeSDK.Models;

namespace Example.Customer
{
    class UpdateCustomer
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);

            string customerId = "cus_6l5dMWZ0hkHZ4XnE";
            var request = new UpdateCustomerRequest
            {
                Name = "Peter Parker",
                Email = "parker@avengers.com"
            };

            var response = client.Customers.UpdateCustomer(customerId, request);
        }
    }
}

