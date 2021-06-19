using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using ProjectWeekendPuzzles.StepList.Api;
using System;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;

namespace ProjectWeekendPuzzles.StepList.Client
{
    public class StepListUpdaterClient : IDisposable
    {
        private readonly GrpcChannel _channel;
        private readonly StepListUpdater.StepListUpdaterClient _client;

        public StepListUpdaterClient()
        {
            var portStr = ConfigurationSettings.AppSettings["port"] ?? "55331"; // fallback to default
            var port = int.Parse(portStr);

            _channel = GrpcChannel.ForAddress($"https://localhost:{port}", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new WinHttpHandler())
            });

            _client = new StepListUpdater.StepListUpdaterClient(_channel);
        }

        public async Task<AddReply> AddStepAsync(string name, string result, StepStatus status)
            => await _client
                .AddStepAsync(new AddRequest { Name = name, Result = result, Status = (AddRequest.Types.StepStatus) status })
                .ResponseAsync;

        public async Task<ClearReply> ClearAsync()
            => await _client
                .ClearListAsync(new ClearRequest())
                .ResponseAsync;

        public void Dispose() => _channel.Dispose();

        public enum StepStatus
        {
            Pass,
            Fail,
            Error
        }
    }
}
