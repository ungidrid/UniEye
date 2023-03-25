using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UniEye.Modules.Study.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddStudyModule(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection;
        }
    }
}
