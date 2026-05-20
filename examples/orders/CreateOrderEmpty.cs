using PagarmeSDK;
using PagarmeSDK.Models;
using System.Collections.Generic;

namespace Example.Order
{
    class CreateOrderEmpty
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);
            
            var request = new CreateOrderRequest()
            {
                Customer = new CreateCustomerRequest()
                {
                    Name = "sdk customer order",
                    Email = "tonystark@avengers.com"
                },

                Items = new List<CreateOrderItemRequest>
                {
                    new CreateOrderItemRequest
                    {
                        Amount = 2990,
                        Description = "Chaveiro do Tesseract",
                        Quantity = 1,
                    }
                },
                Payments = new List<CreatePaymentRequest>
                {
                    new CreatePaymentRequest
                    {
                        BankTransfer = new CreateBankTransferPaymentRequest
                        {
                            Bank = "001"
                        }
                    }
                }
            };


            var response = client.Orders.CreateOrderAsync(request);

        }
    }
}

