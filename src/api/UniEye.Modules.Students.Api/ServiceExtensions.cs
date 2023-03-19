using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniEye.Modules.Students.Infrastructure;

namespace UniEye.Modules.Students.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddStudentsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
            return services;
        }
    }
}
