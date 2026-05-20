using PagarmeSDK;
using PagarmeSDK.Models;

namespace Example.Charges
{
    class CreateCaptureChargePartial
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);
            string chargeId = "ch_exRAY21fvNFVD9EX";

            var request = new CreateCaptureChargeRequest
            {
                Amount = 100,
                Code = "capture_partial_operation"
            };

            client.Charges.CaptureChargeAsync(chargeId, request);

        }

    }
}

