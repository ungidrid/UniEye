using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Azure;
using Microsoft.Graph.ExternalConnectors;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System.Reflection;
using UniEye.Bootstrapper.Extensions;
using UniEye.Bootstrapper.Settings;
using UniEye.Modules.Notifications.App;
using UniEye.Modules.Students.Api;
using UniEye.Modules.Study.Api;
using UniEye.Modules.Users.Api;
using UniEye.Modules.Users.App.Settings;
using UniEye.Shared;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
Configure(app, app.Environment, builder.Configuration);
app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(configuration.GetSection(AzureAdOptions.ConfigSection));

    services.AddSwagger(configuration);
    services.AddControllers();
    services.AddSharedModule(GetAssembliesToScan())
        .AddStudentsModule(configuration)
        .AddUsersModule(configuration)
        .AddNotificationsModule(configuration)
        .AddStudyModule(configuration);

    services.AddCors(o => o.AddPolicy("default", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    }));
}

void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
{
    app.UseSwaggerModule(configuration);
    app.UseCors("default");
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => endpoints.MapControllers());
}

Assembly[] GetAssembliesToScan()
{
    return new[]
    {
        typeof(UniEye.Modules.Students.App.IAssemblyMarker).Assembly,
        typeof(UniEye.Modules.Users.App.IAssebmlyMarker).Assembly,
        typeof(UniEye.Modules.Notifications.App.IAssemblyMarker).Assembly,
        typeof(UniEye.Modules.Study.App.IAssemblyMarker).Assembly
    };
}