using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using khaledhikmat.Api.Services;

namespace khaledhikmat.Api
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(s =>
            {
                s.AddHttpClient();
                s.AddSingleton<ISettingService, SettingService>();
                s.AddSingleton<IPostService, CosmicService>();
            })
            .Build();
            host.Run();
        }
    }
}