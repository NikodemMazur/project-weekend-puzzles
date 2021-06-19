using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace ProjectWeekendPuzzles.StepList.Model
{
    public class StepListModel : IObservable<IEnumerable<Step>>
    {
        private readonly IObservable<IEnumerable<Step>> _observable;
        private event Action<IEnumerable<Step>> ListChanged;
        private readonly ConcurrentQueue<Step> _steps = new();

        public StepListModel()
        {
            ListChanged += _ => { };
            _observable = Observable.FromEvent<IEnumerable<Step>>(a => ListChanged += a, a => ListChanged -= a);
        }

        public void AddSteps(IEnumerable<Step> steps)
        {
            steps
                .ToList()
                .ForEach(x => _steps.Enqueue(x));

            ListChanged.Invoke(_steps);
        }

        public void Clear()
        {
            _steps.Clear();

            ListChanged.Invoke(_steps);
        }

        public IDisposable Subscribe(IObserver<IEnumerable<Step>> observer) => _observable.Subscribe(observer);
    }
}
