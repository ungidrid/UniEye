using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UniEye.Modules.Notifications.App
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddNotificationsModule(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection;
        }
    }
}
