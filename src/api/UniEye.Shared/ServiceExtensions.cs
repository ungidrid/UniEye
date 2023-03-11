using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UniEye.Shared
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSharedModule(this IServiceCollection services, Assembly[] assembliesToScan) 
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.SetInMemorySagaRepositoryProvider();


                x.AddConsumers(assembliesToScan);
                x.AddSagaStateMachines(assembliesToScan);

                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(assembliesToScan));

            return services;
        }
    }
}
