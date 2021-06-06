using System;
using System.Reactive.Linq;

namespace ProjectWeekendPuzzles.Dashboard.Model
{
    public class DashboardModel : IObservable<Status>
    {
        private readonly IObservable<Status> _observable;
        private event Action<Status> StatusChanged;

        public DashboardModel()
        {
            StatusChanged += _ => { };
            _observable = Observable.FromEvent<Status>(a => StatusChanged += a, a => StatusChanged -= a);
        }

        public void SetStatus(Status status)
        {
            StatusChanged.Invoke(status);
        }

        public IDisposable Subscribe(IObserver<Status> observer) => _observable.Subscribe(observer);
    }
}
