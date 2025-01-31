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
            
            // Add services to the container.

            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            
            app.Run();
        }
    }
}
