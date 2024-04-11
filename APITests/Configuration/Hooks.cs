using BoDi;
using RestSharp;
using ToptalAutomationTask.Configuration;

namespace APITests.Configuration
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var restClient = new RestClient(ConfigManager.BASE_URL);
            _container.RegisterInstanceAs(restClient);
        }

    }
}

