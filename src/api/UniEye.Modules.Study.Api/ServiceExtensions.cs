using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniEye.Modules.Study.Infrastructure;

namespace UniEye.Modules.Study.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddStudyModule(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddInfrastructure(configuration);
            
            return serviceCollection;
        }
    }
}
