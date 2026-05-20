using PagarmeSDK.Http.Client;

namespace PagarmeSDK.Exceptions
{
    public class PagarmeInvalidRequestException : PagarmeException
    {
        public PagarmeInvalidRequestException(HttpContext context)
            : base("Invalid request", context)
        {
        }
    }

    public class PagarmeInvalidApiKeyException : PagarmeException
    {
        public PagarmeInvalidApiKeyException(HttpContext context)
            : base("Invalid API key", context)
        {
        }
    }

    public class PagarmeResourceNotFoundException : PagarmeException
    {
        public PagarmeResourceNotFoundException(HttpContext context)
            : base("An informed resource was not found", context)
        {
        }
    }

    public class PagarmeBusinessValidationException : PagarmeException
    {
        public PagarmeBusinessValidationException(HttpContext context)
            : base("Business validation error", context)
        {
        }
    }

    public class PagarmeContractValidationException : PagarmeException
    {
        public PagarmeContractValidationException(HttpContext context)
            : base("Contract validation error", context)
        {
        }
    }

    public class PagarmeInternalServerErrorException : PagarmeException
    {
        public PagarmeInternalServerErrorException(HttpContext context)
            : base("Internal server error", context)
        {
        }
    }
}

