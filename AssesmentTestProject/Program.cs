using AssesmentTestProject.Models;
using AssesmentTestProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace AssesmentTestProject
{
    public class Program
    {
        private static IConfiguration configuration;
        public static void ConfigureServices(HostBuilderContext context, IServiceCollection serviceCollection)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configuration = builder.Build();

            serviceCollection.AddHostedService<DatabaseStartup>();

            serviceCollection.AddDbContext<DefaultDBContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Default")));

            serviceCollection.AddUnitOfWork();
            serviceCollection.AddRepositories();
            serviceCollection.AddCustomServices();
        }

        public static async Task<int> Main(string[] args)
        {
            using (var host = CreateHostBuilder(args).Build())
            {
                await host.StartAsync();
                var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();

                var hierarchyService = host.Services.GetRequiredService<IHierarchyService>();
                var tree = await hierarchyService.GetTreeTillTheNthLayerAsync(4);

                lifetime.StopApplication();
                await host.WaitForShutdownAsync();
            }
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .UseConsoleLifetime()
                .ConfigureServices(ConfigureServices);
    }
}
