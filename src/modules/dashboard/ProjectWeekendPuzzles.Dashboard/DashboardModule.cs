using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectWeekendPuzzles.Core.ApiServer;
using ProjectWeekendPuzzles.Dashboard.Api;
using ProjectWeekendPuzzles.Dashboard.Model;
using ProjectWeekendPuzzles.Dashboard.Views;

namespace ProjectWeekendPuzzles.Dashboard
{
    public class DashboardModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public DashboardModule(IRegionManager regionManager, ApiServiceCollection apiServiceCollection)
        {
            _regionManager = regionManager;

            apiServiceCollection.AddApiService<StatusUpdaterService>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("main-content-region", typeof(DashboardView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<DashboardModel>();
        }
    }
}
