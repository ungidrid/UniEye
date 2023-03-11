using Microsoft.OpenApi.Models;
using UniEye.Modules.Students.Api;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
Configure(app, app.Environment);
app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddStudentsModule(configuration);

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