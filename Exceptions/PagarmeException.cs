using Newtonsoft.Json;
using PagarmeSDK.Http.Client;

namespace PagarmeSDK.Exceptions
{
    public class PagarmeException : APIException
    {
        private object errors;
        private object request;

        [JsonProperty("errors")]
        public object Errors
        {
            get
            {
                return this.errors;
            }
            private set
            {
                this.errors = value;
            }
        }

        [JsonProperty("request")]
        public object Request
        {
            get
            {
                return this.request;
            }
            private set
            {
                this.request = value;
            }
        }

        public PagarmeException(string reason, HttpContext context)
            : base(reason, context)
        {
        }
    }
}

