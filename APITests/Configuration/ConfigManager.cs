using Microsoft.Extensions.Configuration;
using RestSharp;

namespace ToptalAutomationTask.Configuration
{
    public class ConfigManager
    {
        static IConfiguration _Configuration { get; set; }
        static RestClient _RestClient { get; set; }

        static ConfigManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _Configuration = builder.Build();

            _RestClient = new RestClient(_Configuration["BASE_URL"]);
        }

        public static RestClient GetRestClient()
        {
            return _RestClient;
        }
    }
}
