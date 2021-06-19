using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectWeekendPuzzles.Core.ApiServer;
using ProjectWeekendPuzzles.StepList.Api.Services;
using ProjectWeekendPuzzles.StepList.Model;
using ProjectWeekendPuzzles.StepList.Views;

namespace ProjectWeekendPuzzles.StepList
{
    public class StepListModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public StepListModule(IRegionManager regionManager, ApiServiceCollection apiServiceCollection)
        {
            _regionManager = regionManager;

            apiServiceCollection.AddApiService<StepListUpdaterService>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion<StepListView>("main-content-region");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<StepListModel>();
        }
    }
}
