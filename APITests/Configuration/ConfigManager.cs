using Microsoft.Extensions.Configuration;

namespace ToptalAutomationTask.Configuration
{
    public class ConfigManager
    {
        static IConfiguration _Configuration { get; set; }

        static ConfigManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _Configuration = builder.Build();
        }

        public static string BASE_URL => _Configuration["BASE_URL"];
    }
}
