using PagarmeSDK;
using PagarmeSDK.Models;

namespace Example.Charges
{
    class CaptureCharge
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);
            string chargeId = "ch_exRAY21fvNFVD9EX";

            // Opcional
            var request = new CreateCaptureChargeRequest
            {
                Amount = 100,
                Code = "ABCDE123"
            };

            var response = client.Charges.CaptureCharge(chargeId, request);

        }

    }
}

