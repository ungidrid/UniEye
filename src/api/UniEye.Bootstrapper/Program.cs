using Microsoft.OpenApi.Models;
using System.Reflection;
using UniEye.Modules.Students.Api;
using UniEye.Modules.Users.Api;
using UniEye.Modules.Users.App;
using UniEye.Shared;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
Configure(app, app.Environment);
app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddSharedModule(GetAssembliesToScan())
        .AddStudentsModule(configuration)
        .AddUsersModule(configuration);

    services.AddSwaggerGen(swagger =>
    {
        swagger.CustomSchemaIds(x => x.FullName);
        swagger.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "UniEye",
            Version = "v1"
        });
    });
} 

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    app.UseRouting();
    app.UseEndpoints(endpoints => endpoints.MapControllers());
}

Assembly[] GetAssembliesToScan()
{
    return new[]
    {
        typeof(UniEye.Modules.Students.App.IAssemblyMarker).Assembly,
        typeof(UniEye.Modules.Users.App.IAssebmlyMarker).Assembly
    };
}