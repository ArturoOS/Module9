using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog.Events;
using Serilog;
using Serilog.Sinks.EmailPickup;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var log = new LoggerConfiguration()
            .WriteTo.EmailPickup(
                fromEmail: "app@example.com",
                toEmail: "email@example.com",
                pickupDirectory: @"c:\logs\emailpickup",
                subject: "SUBJECT",
                fileExtension: ".email",
                restrictedToMinimumLevel: LogEventLevel.Debug)
            .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
