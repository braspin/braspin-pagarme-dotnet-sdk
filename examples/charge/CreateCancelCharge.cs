
using PagarmeSDK;

namespace Example.Charges
{
    class CreateCancelCharge
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);
            string chargeId = "ch_exRAY21fvNFVD9EX";

            var response = client.Charges.CancelCharge(chargeId);

        }
    }
}

