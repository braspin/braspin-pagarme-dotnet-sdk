using System;
using Microsoft.Extensions.DependencyInjection;

namespace PagarmeSDK
{
    public static class PagarmeExtensions
    {
        public static IServiceCollection AddPagarMe(
            this IServiceCollection services,
            string publicKey,
            string secretKey,
            string baseUrl = null,
            string userAgent = null)
        {
            return services.AddPagarMe(options =>
            {
                options.PublicKey = publicKey;
                options.SecretKey = secretKey;

                if (!string.IsNullOrWhiteSpace(baseUrl))
                {
                    options.BaseUrl = baseUrl;
                }

                if (!string.IsNullOrWhiteSpace(userAgent))
                {
                    options.UserAgent = userAgent;
                }
            });
        }

        public static IServiceCollection AddPagarMe(
            this IServiceCollection services,
            Action<PagarmeOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            var options = new PagarmeOptions();
            configure(options);
            ApplyConfiguration(options);

            services.AddSingleton<PagarmeClient>(_ =>
            {
                ApplyConfiguration(options);
                return new PagarmeClient(options.PublicKey, options.SecretKey, options.BaseUrl, options.UserAgent);
            });

            return services;
        }

        private static void ApplyConfiguration(PagarmeOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.PublicKey))
            {
                throw new ArgumentException("PagarMe publicKey is required.", nameof(options));
            }

            if (string.IsNullOrWhiteSpace(options.SecretKey))
            {
                throw new ArgumentException("PagarMe secretKey is required.", nameof(options));
            }

            if (!string.IsNullOrWhiteSpace(options.BaseUrl))
            {
                Configuration.BaseUri = options.BaseUrl.TrimEnd('/');
            }

            Configuration.BasicAuthUserName = options.SecretKey;
            Configuration.BasicAuthPassword = string.Empty;

            if (!string.IsNullOrWhiteSpace(options.UserAgent))
            {
                Configuration.UserAgent = options.UserAgent;
            }
        }
    }
}


