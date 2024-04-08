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

        public static string HomePageUrl => _Configuration["HomePageUrl"];
        public static string Browser => _Configuration["Browser"];
        public static bool GetHeadless() => _Configuration.GetValue<bool>("Headless");
    }
}
