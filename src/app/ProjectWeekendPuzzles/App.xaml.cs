using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProjectWeekendPuzzles.ApiServer;
using ProjectWeekendPuzzles.Core.ApiServer;
using ProjectWeekendPuzzles.Core.Prism;
using ProjectWeekendPuzzles.Security.Authentication;
using ProjectWeekendPuzzles.Security.Authorization;
using ProjectWeekendPuzzles.Security.Core;
using ProjectWeekendPuzzles.Views;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ProjectWeekendPuzzles
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private Task? _apiServerTask;

        private readonly CancellationTokenSource _cts = new();

        protected override Window CreateShell() => Container.Resolve<Shell>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ApiServiceCollection>();

            containerRegistry.RegisterSingleton<IAuthenticationStateProvider, AuthenticationStateProvider>();
            containerRegistry.RegisterSingleton<IAuthorizationService, AuthorizationService>();
            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
            containerRegistry.Register<IAuthenticationHandler, DefaultAuthenticationHandler>();

            containerRegistry.Register<SignInView>();
            containerRegistry.Register<SignOut>();

            containerRegistry.Register<IRegion>(cp => new AuthorizeRegion(cp.Resolve<IAuthorizationService>(),
                cp.Resolve<IAuthenticationStateProvider>()));
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var dryIocContainer = Container.GetContainer();

            if (ConfigurationManager.AppSettings["port"] is { } portStr)
                if (int.TryParse(portStr, out int port))
                    _apiServerTask = GrpcWebApiServer.Create(port, dryIocContainer).RunAsync(_cts.Token);
                else
                    throw new ConfigurationErrorsException("Invalid configuration \"appSettings.port\".");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _cts.Cancel();
            _apiServerTask?.Wait(); // wait for the graceful server exit
        }

        protected override IModuleCatalog CreateModuleCatalog() => new ConfigurationModuleCatalog();

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            regionAdapterMappings.RegisterMapping<Selector, Core.Prism.SelectorRegionAdapter>();
            regionAdapterMappings.RegisterMapping<ItemsControl, Core.Prism.ItemsControlRegionAdapter>();
            regionAdapterMappings.RegisterMapping<ContentControl, Core.Prism.ContentControlRegionAdapter>();
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);
            regionBehaviors.AddIfMissing<ReloadRegionViewsRegionBehavior>(ReloadRegionViewsRegionBehavior.BehaviorKey);
        }
    }
}
