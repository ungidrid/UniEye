using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Models;
using UniEye.Bootstrapper.Settings;

namespace UniEye.Bootstrapper.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSwaggerGen(swagger =>
            {
                swagger.CustomSchemaIds(x => x.FullName);
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UniEye",
                    Version = "v1"
                });

                var azureConfig = new SwaggerAdOptions();
                configuration.GetSection(SwaggerAdOptions.ConfigSection).Bind(azureConfig);

                swagger.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "Azure AD auth",
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(azureConfig.AuthorizationUrl),
                            TokenUrl = new Uri(azureConfig.TokenUrl),
                            Scopes = new Dictionary<string, string>
                            {
                                [azureConfig.Scope] = "Access API"
                            }
                        }
                    }
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new[]
                        {
                            azureConfig.Scope
                        }
                    }
                });
            });

            return services;
        }

        public static void UseSwaggerModule(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;

                var azureConfig = new SwaggerAdOptions();
                configuration.GetSection(SwaggerAdOptions.ConfigSection).Bind(azureConfig);
                options.OAuthClientId(azureConfig.ClinetId);
                options.OAuthUsePkce();
            });
        }
    }
}
