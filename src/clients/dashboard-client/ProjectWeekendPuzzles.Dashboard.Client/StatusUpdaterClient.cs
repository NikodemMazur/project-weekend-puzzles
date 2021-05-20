using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using ProjectWeekendPuzzles.Dashboard.Api;
using System;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;

namespace ProjectWeekendPuzzles.Dashboard.Client
{
    public class StatusUpdaterClient : IDisposable
    {
        private readonly GrpcChannel _channel;
        private readonly StatusUpdater.StatusUpdaterClient _client;

        public StatusUpdaterClient()
        {
            var portStr = ConfigurationSettings.AppSettings["port"] ?? "55331"; // fallback to default
            var port = int.Parse(portStr);

            _channel = GrpcChannel.ForAddress($"https://localhost:{port}", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new WinHttpHandler())
            });

            _client = new StatusUpdater.StatusUpdaterClient(_channel);
        }

        public async Task<UpdateReply> UpdateStatusAsync(int passCount, int failCount, int errorCount)
            => await _client
                .UpdateStatusAsync(new UpdateRequest { PassCount = passCount, FailCount = failCount, ErrorCount = errorCount })
                .ResponseAsync;

        public UpdateReply UpdateStatus(int passCount, int failCount, int errorCount)
            => UpdateStatusAsync(passCount, failCount, errorCount).Result;

        public void Dispose() => _channel.Dispose();
    }
}
