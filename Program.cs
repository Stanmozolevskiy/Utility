using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace JWT_Handler
{
    public class Program
    {
        public static void Main(string[] args)=>CreateHostBuilder(args).Build().Run();
        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
#if !DEBUG
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Listen(IPAddress.Any, Convert.ToInt32(Environment.GetEnvironmentVariable("PORT")));
                    }).UseStartup<Startup>();
#endif
                    webBuilder.UseStartup<Startup>();
                });
    }
}
