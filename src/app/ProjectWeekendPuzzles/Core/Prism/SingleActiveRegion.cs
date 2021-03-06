using Prism.Regions;
using System;
using System.ComponentModel;
using System.Linq;

namespace ProjectWeekendPuzzles.Core.Prism
{
    public class SingleActiveRegion : IRegion
    {
        private readonly IRegion _region;

        public SingleActiveRegion(IRegion region)
        {
            _region = region;
        }

        public IViewsCollection Views => _region.Views;

        public IViewsCollection ActiveViews => _region.ActiveViews;

        public object Context { get => _region.Context; set => _region.Context = value; }
        public string Name { get => _region.Name; set => _region.Name = value; }
        public Comparison<object> SortComparison { get => _region.SortComparison; set => _region.SortComparison = value; }
        public IRegionManager RegionManager { get => _region.RegionManager; set => _region.RegionManager = value; }

        public IRegionBehaviorCollection Behaviors => _region.Behaviors;

        public IRegionNavigationService NavigationService { get => _region.NavigationService; set => _region.NavigationService = value; }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                _region.PropertyChanged += value;
            }

            remove
            {
                _region.PropertyChanged -= value;
            }
        }

        public void Activate(object view)
        {
            object currentActiveView = ActiveViews.FirstOrDefault();

            if (currentActiveView != null && currentActiveView != view && Views.Contains(currentActiveView))
            {
                _region.Deactivate(currentActiveView);
            }
            _region.Activate(view);
        }

        public IRegionManager Add(object view)
        {
            return _region.Add(view);
        }

        public IRegionManager Add(object view, string viewName)
        {
            return _region.Add(view, viewName);
        }

        public IRegionManager Add(object view, string viewName, bool createRegionManagerScope)
        {
            return _region.Add(view, viewName, createRegionManagerScope);
        }

        public void Deactivate(object view)
        {
            _region.Deactivate(view);
        }

        public object GetView(string viewName)
        {
            return _region.GetView(viewName);
        }

        public void Remove(object view)
        {
            _region.Remove(view);
        }

        public void RemoveAll()
        {
            _region.RemoveAll();
        }

        public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback)
        {
            _region.RequestNavigate(target, navigationCallback);
        }

        public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
        {
            _region.RequestNavigate(target, navigationCallback, navigationParameters);
        }
    }
}
