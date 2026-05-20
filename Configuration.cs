using System.Reflection;

namespace PagarmeSDK
{
    public partial class Configuration
    {


        //The base Uri for API calls
        public static string BaseUri = "https://api.pagar.me/core/v5";

        //The username to use with basic authentication
        //TODO: Replace the BasicAuthUserName with an appropriate value
        public static string BasicAuthUserName = "";

        //The password to use with basic authentication
        //TODO: Replace the BasicAuthPassword with an appropriate value
        public static string BasicAuthPassword = "";

        public static string UserAgent = BuildDefaultUserAgent();

        private static string BuildDefaultUserAgent()
        {
            var version = typeof(Configuration).Assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion;

            if (string.IsNullOrWhiteSpace(version))
            {
                version = typeof(Configuration).Assembly.GetName().Version?.ToString();
            }

            return $"braspin-pagarme-dotnet-sdk {version}";
        }
    }
}

