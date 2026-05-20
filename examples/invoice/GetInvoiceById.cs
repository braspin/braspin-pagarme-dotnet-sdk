using PagarmeSDK;

namespace Example.Invoice
{
    class GetInvoiceById
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            string publicKey = "publicKey"; // The public key to use with basic authentication
            string secretKey = "secretKey"; // The secret key to use with basic authentication

            var client = new PagarmeClient(publicKey, secretKey);

            string invoiceId = "in_n87qwY1FA2SzwXDb";
            var response = client.Invoices.GetInvoice(invoiceId);
        }
    }
}

