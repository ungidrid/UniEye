
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UniEye.Modules.Students.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        { 
            var connectionString = configuration.GetConnectionString("students");
            services.AddDbContext<StudentsContext>(opts =>
            {
                opts.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
