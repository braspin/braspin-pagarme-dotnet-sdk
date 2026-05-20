using PagarmeSDK;
using PagarmeSDK.Models;
using System.Collections.Generic;

namespace Example.Order
{
    class CreateOrderDebitCard
    {
        static void Main(string[] args)
        {
           // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);

            var request = new CreateOrderRequest
            {
                Payments = new List<CreatePaymentRequest>
                {
                new CreatePaymentRequest
                {
                    PaymentMethod = "debit_card",
                        DebitCard  = new CreateDebitCardPaymentRequest
                        {
                            Card = new CreateCardRequest
                            {
                                HolderName = "Tony Stark",
                                Number = "342793631858229",
                                ExpMonth = 1,
                                ExpYear = 18,
                                Cvv = "3531",
                            }
                        }
                    }
                },
                Items = new List<CreateOrderItemRequest>
                {
                    new CreateOrderItemRequest
                    {
                        Amount = 2990,
                        Description = "Chaveiro do Tesseract",
                        Quantity = 1
                    }
                },
                Customer = new CreateCustomerRequest
                {
                    Name = "sdk customer order",
                    Email = "tonystark@avengers.com"
                }
            };

            var response = client.Orders.CreateOrderAsync(request);

        }
    }
}

