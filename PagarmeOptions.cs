namespace PagarmeSDK
{
    public class PagarmeOptions
    {
        public string PublicKey { get; set; }

        public string SecretKey { get; set; }

        public string BaseUrl { get; set; } = Configuration.BaseUri;

        public string UserAgent { get; set; } = Configuration.UserAgent;
    }
}


