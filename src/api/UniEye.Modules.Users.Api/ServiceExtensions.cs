using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using UniEye.Modules.Users.App.Settings;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;

namespace UniEye.Modules.Users.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureAdOptions>(configuration.GetSection(AzureAdOptions.ConfigSection));
            services.AddGraphClient();

            return services;
        }

        private static IServiceCollection AddGraphClient(this IServiceCollection services)
        {
            services.AddScoped((serviceProvider) =>
            {
                var azureAdOptions = serviceProvider.GetRequiredService<IOptions<AzureAdOptions>>().Value;
                var clientCredentials = new ClientSecretCredential(azureAdOptions.TenantId, azureAdOptions.ClientId, azureAdOptions.ClientSecret);
                var scope = "https://graph.microsoft.com/.default"; //See https://learn.microsoft.com/en-us/graph/auth-v2-service#4-get-an-access-token

                var token = clientCredentials.GetToken(new TokenRequestContext(new[] { scope }));

                return new GraphServiceClient(
                    new DelegateAuthenticationProvider((requestMessage) =>
                    {
                        requestMessage
                            .Headers
                            .Authorization = new AuthenticationHeaderValue("bearer", token.Token);

                        return Task.CompletedTask;
                    })
                );
            });

            return services;
        }
    }
}
