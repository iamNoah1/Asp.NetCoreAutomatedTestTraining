using BusinessLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AutomatedTestTraining
{
    public class Program
    {
        static PasswordValidator validator = new PasswordValidator();

        public static void Main(string[] args)
        {
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
