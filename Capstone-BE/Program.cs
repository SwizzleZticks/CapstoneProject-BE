using Capstone_BE.Extensions;
using Capstone_BE.Models;
using Capstone_BE.Services;
using Microsoft.EntityFrameworkCore;

namespace Capstone_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<CapstoneDbContext>(option =>
                      option.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneDB")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("") //add your url
                              .AllowAnyMethod()
                              .AllowAnyOrigin()
                              .AllowAnyHeader();
                    });
            });
            builder.Services.AddHttpClient<WeatherService>();
            builder.Services.AddScoped<WeatherService>();
            builder.Services.AddIdentityServices(builder.Configuration);
            
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors();
            app.Run();
        }
    }
}
