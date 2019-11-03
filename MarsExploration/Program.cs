using Microsoft.Extensions.DependencyInjection;

namespace MarsExploration
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup DI
            // Create service collection and configure our services
            var services = DependendencySetup.ConfigureServices();

            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            // Kick off our actual code
            serviceProvider.GetService<MarsExplorer>().Run();
        }
    }
}
