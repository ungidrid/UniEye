using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UniEye.Modules.Study.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("study");
            services.AddDbContext<StudyContext>(opts =>
            {
                opts.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
