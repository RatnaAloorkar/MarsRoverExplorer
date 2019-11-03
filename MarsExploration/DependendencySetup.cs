using MarsExploration.Interfaces;
using MarsExploration.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MarsExploration
{
    class DependendencySetup
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<MarsExplorer>();
            return services;
        }
    }
}
