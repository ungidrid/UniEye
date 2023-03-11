using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniEye.Modules.Users.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
