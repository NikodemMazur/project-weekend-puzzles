using System.Threading;
using System.Threading.Tasks;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ProjectWeekendPuzzles.Core.ApiServer;

namespace ProjectWeekendPuzzles.ApiServer
{
    public class GrpcWebApiServer
    {
        private readonly IHost _host;

        private GrpcWebApiServer(IHost host)
        {
            _host = host;
        }

        public static GrpcWebApiServer Create(int port, IContainer preBuiltContainer)
        {
            var host = Host
                .CreateDefaultBuilder()
                .UseServiceProviderFactory(new DryIocServiceProviderFactory(preBuiltContainer))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup(_ => new Startup(preBuiltContainer.Resolve<ApiServiceCollection>()))
                        .ConfigureKestrel(kestrelOptions =>
                        {
                            kestrelOptions
                                .ListenLocalhost(port);
                        });
                })
                .Build();

            return new GrpcWebApiServer(host);
        }

        public Task RunAsync(CancellationToken token)
            => _host.RunAsync(token);
    }
}
