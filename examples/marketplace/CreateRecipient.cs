using PagarmeSDK;
using PagarmeSDK.Models;

namespace Example.Marketplace
{
    class CreateRecipient
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);

            var request = new CreateRecipientRequest
            {
                Name = "Tony Stark",
                Document = "12312312312",
                Email = "Star22k@pagar.me",
                Type = "individual",
                DefaultBankAccount = new CreateBankAccountRequest
                {
                    HolderName = "Tony Stark",
                    HolderDocument = "12312312312",
                    HolderType = "individual",
                    Bank = "341",
                    AccountNumber = "123",
                    Type = "checking"

                }
            };
            var response = client.Recipients.CreateRecipient(request);
        }
    }
}

