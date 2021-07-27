using Prism.Regions;
using System.Collections.Generic;
using System;
using ProjectWeekendPuzzles.Security.Authorization;
using System.Threading;

namespace ProjectWeekendPuzzles.Core.Prism
{
    public class ReloadRegionViewsRegionBehavior : RegionBehavior
    {
        private readonly IRegionViewRegistry _regionViewRegistry;
        private readonly IAuthenticationStateProvider _authenticationStateProvider;

        protected virtual void AddViewIntoRegion(object viewToAdd)
        {
            Region.Add(viewToAdd);
        }

        protected virtual IEnumerable<object> CreateViewsToPopulate() => _regionViewRegistry.GetContents(Region.Name);

        protected override void OnAttach()
        {
            _authenticationStateProvider.AuthenticationStateChanged += OnUserRelogged;
        }

        private void OnUserRelogged(AuthenticationState authenticationState)
        {
            Region.RemoveAll();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            foreach (object view in CreateViewsToPopulate())
            {
                AddViewIntoRegion(view);
            }
        }

        public const string BehaviorKey = "ReloadRegionViews";

        public ReloadRegionViewsRegionBehavior(IRegionViewRegistry regionViewRegistry, IAuthenticationStateProvider authenticationStateProvider)
        {
            _regionViewRegistry = regionViewRegistry;
            _authenticationStateProvider = authenticationStateProvider ?? throw new ArgumentNullException(nameof(authenticationStateProvider));
        }
    }
}
