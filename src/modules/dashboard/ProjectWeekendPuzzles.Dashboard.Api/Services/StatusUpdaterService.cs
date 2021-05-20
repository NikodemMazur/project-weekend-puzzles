using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ProjectWeekendPuzzles.Dashboard.Model;

namespace ProjectWeekendPuzzles.Dashboard.Api
{
    public class StatusUpdaterService : StatusUpdater.StatusUpdaterBase
    {
        private readonly ILogger<StatusUpdaterService> _logger;
        private readonly DashboardModel _dashboardModel;

        public StatusUpdaterService(ILogger<StatusUpdaterService> logger, DashboardModel dashboardModel)
        {
            _logger = logger;
            _dashboardModel = dashboardModel;
        }

        public override Task<UpdateReply> UpdateStatus(UpdateRequest request, ServerCallContext context)
        {
            var newStatus = new Dashboard.Model.Status(request.PassCount, request.FailCount, request.ErrorCount);
            _dashboardModel.SetStatus(newStatus);
            return Task.FromResult(new UpdateReply { Success = true });
        }
    }
}
