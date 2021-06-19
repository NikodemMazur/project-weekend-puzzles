using Grpc.Core;
using ProjectWeekendPuzzles.StepList.Model;
using System;
using System.Threading.Tasks;

namespace ProjectWeekendPuzzles.StepList.Api.Services
{
    public class StepListUpdaterService : StepListUpdater.StepListUpdaterBase
    {
        private readonly StepListModel _stepListModel;

        public StepListUpdaterService(StepListModel stepListModel)
        {
            _stepListModel = stepListModel;
        }

        public override Task<AddReply> AddStep(AddRequest request, ServerCallContext context)
        {
            var newStep = new Step(request.Name, request.Result, ConvertStatus(request.Status));
            _stepListModel.AddSteps(new[] { newStep });
            return Task.FromResult(new AddReply { Success = true });
        }

        public override Task<ClearReply> ClearList(ClearRequest request, ServerCallContext context)
        {
            _stepListModel.Clear();
            return Task.FromResult(new ClearReply { Success = true });
        }

        private static Step.StepStatus ConvertStatus(AddRequest.Types.StepStatus stepStatus)
            => stepStatus switch
            {
                AddRequest.Types.StepStatus.Pass => Step.StepStatus.Pass,
                AddRequest.Types.StepStatus.Fail => Step.StepStatus.Fail,
                AddRequest.Types.StepStatus.Error => Step.StepStatus.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(stepStatus), $"Cannot convert {nameof(AddRequest.Types.StepStatus)} because of the incompatible value.")
            };
    }
}
