using Autofac.Core;
using BnSatrack.Api.Extensions;
using BnSatrack.Core.Entites;
using Microsoft.Extensions.Configuration;

namespace PrSatrackBackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDatabase(builder.Configuration);
            builder.Services.AddUnitOfWork();
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddBusinessServices(builder.Configuration);
            builder.Services.AddSwaggerDocumentation();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });
            });

            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();            
            var appSettings = new AppSettings();
            configuration.GetSection("ConnectionString").Bind(appSettings.ConnectionStrings);

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwaggerGen();
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();            
            app.Run();
        }
    }
}