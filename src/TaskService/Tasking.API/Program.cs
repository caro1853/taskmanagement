using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Tasking.Application;
//using Tasking.Infrastructure;
//using Tasking.API.Extensions;
//
//var builder = WebApplication.CreateBuilder(args);
//
//// Add services to the container.
//
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//
//builder.Services.AddApplicationServices();
//var config = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetCurrentDirectory())
//                 .AddJsonFile("appsettings.json")
//                 .Build();
//builder.Services.AddInfrastructureServices(config);
////builder.Services.AddAutoMapper(typeof(this));
//
//var app = builder.Build();
//
//
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//
//app.UseAuthorization();
//
//app.MapControllers();
//
//app.Run();

using Microsoft.Extensions.Configuration;
using Tasking.API.Extensions;
using Tasking.Infrastructure.Persistence;
using Tasking.API;

namespace Tasking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDatabase<TaskContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<TaskContextSeed>>();

                if (logger == null)
                    throw new Exception("logger can't be null");

                TaskContextSeed
                    .SeedAsync(context, logger)
                    .Wait();
            });
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

