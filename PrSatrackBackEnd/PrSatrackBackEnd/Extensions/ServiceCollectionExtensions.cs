using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using BnSatrack.Core.Interfaces.Service;
using BnSatrack.Core.Services;
using BnSatrack.Infrastructure.Context;
using BnSatrack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using Serilog;
//using System.Text.Json.Serialization;
//using Autofac.Extensions.DependencyInjection;

namespace BnSatrack.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {

        
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<EFContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBasicDataService, BasicDataService>();
            services.AddTransient<IBasicDataRepository, BasicDataRepository>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IReportesService, ReporteService>();
            services.AddTransient<IReportesRepository, ReporteRepository>();
            services.AddTransient<IGestionBnService, GestionBnService>();
            services.AddTransient<IGestionBnRepository, GestionBnRepository>();

            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            return services;
        }
    }
}
