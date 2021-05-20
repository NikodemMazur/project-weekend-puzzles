using Prism.Commands;
using ProjectWeekendPuzzles.Dashboard.Model;
using ReactiveUI;
using System.Reactive.Linq;

namespace ProjectWeekendPuzzles.Dashboard.ViewModels
{
    public class DashboardViewModel : ReactiveObject
    {
        private readonly DashboardModel _model;

        private readonly ObservableAsPropertyHelper<int> _passCount;
        public int PassCount => _passCount.Value;

        private readonly ObservableAsPropertyHelper<int> _failCount;
        public int FailCount => _failCount.Value;

        private readonly ObservableAsPropertyHelper<int> _errorCount;
        public int ErrorCount => _errorCount.Value;

        public DashboardViewModel(DashboardModel dashboardModel)
        {
            _model = dashboardModel;

            _passCount = _model
                .ObserveOnDispatcher()
                .Select(x => x.PassCount)
                .ToProperty(this, x => x.PassCount);

            _failCount = _model
                .ObserveOnDispatcher()
                .Select(x => x.FailCount)
                .ToProperty(this, x => x.FailCount);

            _errorCount = _model
                .ObserveOnDispatcher()
                .Select(x => x.ErrorCount)
                .ToProperty(this, x => x.ErrorCount);
        }
    }
}
