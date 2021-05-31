using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectWeekendPuzzles.ModuleInfo.Views;

namespace ProjectWeekendPuzzles.ModuleInfo
{
    public class ModuleInfoModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleInfoModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("main-content-region", typeof(ModuleInfoView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
