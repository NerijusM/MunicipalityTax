using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repository;

namespace Infrastructure.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(configuration.GetConnectionString("AppConnection"));
        });
    }

    //FIXME: - append new Repositories
    //FIXME: - make this import automaticaly
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IMunicipalityTaxRepository, MunicipalityTaxRepository>();
    }

    //FIXME: - append new Services
    //FIXME: - make this import automaticaly
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IMunicipalityTaxService, MunicipalityTaxService>();
    }
}