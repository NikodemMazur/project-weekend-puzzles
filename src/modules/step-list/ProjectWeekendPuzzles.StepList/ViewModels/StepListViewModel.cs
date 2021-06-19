using DynamicData;
using DynamicData.Binding;
using ProjectWeekendPuzzles.StepList.Model;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace ProjectWeekendPuzzles.StepList.ViewModels
{
    public class StepListViewModel : ReactiveObject
    {
        private ReadOnlyObservableCollection<Step> _stepList;
        public ReadOnlyObservableCollection<Step> StepList => _stepList;

        public StepListViewModel(StepListModel stepListModel)
        {
            stepListModel
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToObservableChangeSet(x => x.Id)
                .IgnoreUpdateWhen((curr, prev) => curr.Equals(prev)) // The whole IChangeSet is said to be updated every time a new item is added though the old items remained 
                .Bind(out _stepList)                                 // unchanged. To prevent an unnecessary rendering of items one should explicitly discard updates with a simple predicate.
                .Subscribe();
        }
    }
}
