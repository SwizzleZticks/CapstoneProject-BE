using Capstone_BE.Interfaces;
using Capstone_BE.Models;
using Capstone_BE.Services;
using Microsoft.EntityFrameworkCore;

namespace Capstone_BE.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<CapstoneDbContext>(option =>
            option.UseSqlServer(config.GetConnectionString(("CapstoneDB"))));
        
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("http://localhost:5001") //add your url
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowAnyHeader();
                });
        });
        services.AddHttpClient<WeatherService>();
        services.AddScoped<WeatherService>();
        services.AddScoped<ITokenService, TokenService>();
        
        return services;
    }
}