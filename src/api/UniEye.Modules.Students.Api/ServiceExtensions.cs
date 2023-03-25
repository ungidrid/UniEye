using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniEye.Modules.Students.Infrastructure;
using UniEye.Modules.Students.Shared;
using Refit;

namespace UniEye.Modules.Students.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddStudentsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
            services.AddRefitClient<IStudentsClient>()
                .ConfigureHttpClient(c =>
                {
                    var moduleUrl = configuration["Modules:Students:Url"];
                    c.BaseAddress = new Uri(moduleUrl);
                });

            return services;
        }
    }
}
