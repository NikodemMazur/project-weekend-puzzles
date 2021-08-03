using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectWeekendPuzzles.Dashboard.Client
{
    public class CustomHttpClientHandler : HttpClientHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Version = new Version(1, 1);
            return base.SendAsync(request, cancellationToken);
        }

        public CustomHttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (req, cert, chain, err) => true;
        }
    }
}
