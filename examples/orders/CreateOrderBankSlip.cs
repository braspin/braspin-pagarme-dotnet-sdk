using PagarmeSDK;
using PagarmeSDK.Models;
using System;
using System.Collections.Generic;

namespace Example.Order
{
    class CreateOrderBankSlip
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
                        PaymentMethod = "Boleto",
                        Amount = 1242,
                        Boleto = new CreateBoletoPaymentRequest
                        {
                            DocumentNumber = "276262",
                            Bank = "001"
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

