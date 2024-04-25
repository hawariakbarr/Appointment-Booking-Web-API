using Autofac.Extensions.DependencyInjection;
using Autofac;
using AppointmentBooking.Data;
using AppointmentBooking.Business.Services;
using AppointmentBooking.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using AppointmentBooking.Data.Interfaces;
using AppointmentBooking.Data.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Configure routing to use lowercase URLs
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});
builder.Services.AddEndpointsApiExplorer();


// Configure Swagger directly from appsettings.json
var swaggerTitle = builder.Configuration["SwaggerSettings:Title"];
var swaggerVersion = builder.Configuration["SwaggerSettings:Version"];

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(swaggerVersion, new OpenApiInfo
    {
        Title = swaggerTitle,
        Version = swaggerVersion
    });
});


// Configure Autofac as the IoC container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<AppDbContext>().AsSelf().InstancePerLifetimeScope();

    containerBuilder.RegisterType<AppointmentService>().As<IAppointmentService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<AgencyConfigurationService>().As<IAgencyConfigurationService>().InstancePerLifetimeScope();

    containerBuilder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<AgencyConfigurationRepository>().As<IAgencyConfigurationRepository>().InstancePerLifetimeScope();

    // Register other services and repositories as needed
});

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    // Assuming usage of SQL Server; modify connection string as necessary
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/{swaggerVersion}/swagger.json", swaggerTitle);
    });
}

app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();

app.Run();
