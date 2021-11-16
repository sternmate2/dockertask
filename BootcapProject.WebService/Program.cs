using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BootcapProject.WebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                SetStdOut();

                if (args != null && args.Length > 0)
                {
                    // Windows Service
                    SetCurrentDirectory();
                }

                var host = CreateHostBuilder(args).Build();

                host.Run();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        private static void SetCurrentDirectory()
        {
            try
            {
                string location = Assembly.GetExecutingAssembly().Location;
                string currentDirectory = Path.GetDirectoryName(location);

                if (currentDirectory == null)
                {
                    Console.Error.WriteLine("failed to set current directory, null value");
                    return;
                }

                Console.WriteLine($"Set current directory to {currentDirectory}");

                Directory.SetCurrentDirectory(currentDirectory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to set current directory, error: {ex.Message}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddEnvironmentVariables()
                .Build();

            string port = (string)config.GetValue(typeof(string), "APP_PORT");


            var builder =
                Host.CreateDefaultBuilder(args)
                    .UseWindowsService()
                    .ConfigureWebHostDefaults(
                        webBuilder =>
                        {
                            webBuilder.ConfigureServices(services =>
                            {
                                services.AddControllers();
                            });
                            webBuilder.UseUrls($"http://*:{port}");
                            webBuilder.ConfigureLogging(logging => logging.ClearProviders());
                            webBuilder.UseStartup<Startup>();
                        });


            return builder;
        }

        public static void SetStdOut()
        {
            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput())
            {
                AutoFlush = true
            };
            Console.SetOut(standardOutput);
        }
    }
}
