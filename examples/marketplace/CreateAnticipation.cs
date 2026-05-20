using PagarmeSDK;
using PagarmeSDK.Models;
using System;

namespace Example.Marketplace
{
    class CreateAnticipation
    {
        static void Main(string[] args)
        {
           // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);

            var request = new CreateAnticipationRequest
            {
                Amount = 100,
                Timeframe= "start",
                PaymentDate = DateTime.Parse("2019-08-21")

            };

            String recipientId = "rp_RElaP4NMCJu08V9m";

            client.Recipients.CreateAnticipationAsync(recipientId, request);
            

        }

    }
}

