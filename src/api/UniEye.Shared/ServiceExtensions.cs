using Microsoft.Extensions.DependencyInjection;

namespace UniEye.Shared
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSharedModule(this IServiceCollection services) 
        {
            return services;
        }
    }
}
