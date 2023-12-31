﻿using Microsoft.EntityFrameworkCore;
using PetSystem.Api.Ioc;
using PetSystem.Api.Mappings;
using PetSystem.Core.Contexts;
using PetSystem.Infra.Data;

namespace PetSystem.Api.Configurations;

public static class BuilderExtensions
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.RegisterServices();

        Configuration.Database.ConnectionString =
            builder.Configuration.GetConnectionString("DefaultConnection") ??
                                 string.Empty;

        Configuration.Secrets.ApiKey =
            builder.Configuration.GetSection("Secrets")
                                 .GetValue<string>("ApiKey") ??
                                 string.Empty;
    }

    public static void UseApiConfiguration(this IApplicationBuilder app,
                                           IWebHostEnvironment env)
    {
        app.UseSwaggerDocumentation(env);
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseAuthorization();
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.GlobalServices();
        services.InternalServices();
        services.MapModules();
        services.AddDataBase();
        services.AddSwaggerDocumentation();
    }

    private static void InternalServices(this IServiceCollection services)
    {
        var modules = AppDomain.CurrentDomain.GetAssemblies()
                                             .SelectMany(row => row.GetTypes())
                                             .Where(row => typeof(IInjection)
                                                .IsAssignableFrom(row) &&
                                                row.Name != "IInjection")
                                             .Select(row => row).ToList();

        foreach (var item in modules)
        {
            var iinjection = Activator.CreateInstance(item) as IInjection;
            iinjection.RegisterServices(services);
        }
    }

    private static void AddDataBase(this IServiceCollection services)
    {
        services.AddDbContext<PersistContext>(x =>
            x.UseSqlServer(Configuration.Database.ConnectionString,
            b => b.MigrationsAssembly("PetSystem.Api")));
    }
}