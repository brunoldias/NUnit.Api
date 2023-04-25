
using Microsoft.Extensions.Configuration;
using NUnit.Api.StartUp;
using NUnit.Core.Config;

namespace Nunit.Api
{
    public class Program
    {

        public static string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        public static void Main(string[] args)
        {          
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile($"appsettings.{Env}.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddEnvironmentVariables();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));
            builder.Services.AddRefit();
            builder.Services.AddDepencyInjection();

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

            app.Run();
        }
    }
}