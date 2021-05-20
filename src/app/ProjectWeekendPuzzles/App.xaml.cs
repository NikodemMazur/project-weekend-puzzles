using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using ProjectWeekendPuzzles.ApiServer;
using ProjectWeekendPuzzles.Core.ApiServer;
using ProjectWeekendPuzzles.Views;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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
    }
}
