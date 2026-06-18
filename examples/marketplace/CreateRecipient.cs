using System.Collections.Generic;
using System;
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
                Code = "1234",
                RegisterInformation = new CreateRecipientRegisterInformationRequest
                {
                    Name = "Tony Stark",
                    Document = "12312312312",
                    Email = "stark@pagar.me",
                    Type = "individual",
                    SiteUrl = "https://sitedorecebedor.com.br",
                    MotherName = "Nome da mae",
                    Birthdate = new DateTime(1984, 10, 30),
                    MonthlyIncome = 120000,
                    ProfessionalOccupation = "Vendedor",
                    Address = new CreateRecipientRegisterInformationAddressRequest
                    {
                        Street = "Av. General Justo",
                        Complementary = "Bloco A",
                        StreetNumber = "375",
                        Neighborhood = "Centro",
                        City = "Rio de Janeiro",
                        State = "RJ",
                        ZipCode = "20021130",
                        ReferencePoint = "Ao lado da banca de jornal"
                    },
                    PhoneNumbers = new List<CreateRecipientRegisterInformationPhoneRequest>
                    {
                        new CreateRecipientRegisterInformationPhoneRequest
                        {
                            Ddd = "21",
                            Number = "994647568",
                            Type = "mobile"
                        }
                    }
                },
                DefaultBankAccount = new CreateBankAccountRequest
                {
                    HolderName = "Tony Stark",
                    HolderDocument = "12312312312",
                    HolderType = "individual",
                    Bank = "341",
                    BranchNumber = "1234",
                    BranchCheckDigit = "6",
                    AccountNumber = "123",
                    AccountCheckDigit = "6",
                    Type = "checking"

                }
            };
            var response = client.Recipients.CreateRecipient(request);
        }
    }
}

