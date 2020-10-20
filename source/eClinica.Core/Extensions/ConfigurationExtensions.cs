using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace eClinica.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IConfiguration GetConfiguration(this IHostEnvironment env)
        {
            return GetConfiguration(env.EnvironmentName, env.ContentRootPath);
        }

        public static IConfigurationRoot GetConfiguration(string enviromentName, string contentRootPath = null)
        {
            var configurationbuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{enviromentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (contentRootPath != null)
            {
                configurationbuilder.SetBasePath(contentRootPath);
            }

            return configurationbuilder.Build();
        }
    }
}
