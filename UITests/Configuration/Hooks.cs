using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Bindings;
using ToptalAutomationTask.Utilities;

namespace ToptalAutomationTask.Configuration
{
    [Binding]
    public sealed class Hooks
    {
        IWebDriver _driver;
        private readonly IObjectContainer _container; //ovo isto pregleadti//
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private static ExtentReports _extentReports;
        private ExtentTest _scenario;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            _extentReports = ExtentReportManager.InitializeExtentReports();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            BrowserManager.KillBrowserDrivers();

            var feature = _extentReports.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _scenario = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

            _driver = BrowserManager.GetWebDriver();
            _container.RegisterInstanceAs(_driver);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            var _driver = _container.Resolve<IWebDriver>();
            _driver.Close();
            _driver.Quit();

        }

        [AfterStep]
        public void AfterStep(IObjectContainer container)
        {
            var _driver = container.Resolve<IWebDriver>();

            if (_scenarioContext.TestError == null)
            {
                switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    case StepDefinitionType.When:
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    case StepDefinitionType.Then:
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                var base64Screenshot = ExtentReportManager.CaptureScreenshot(_driver, _scenarioContext);
                var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot).Build();


                switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException, mediaEntity);
                        break;
                    case StepDefinitionType.When:
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException, mediaEntity);
                        break;
                    case StepDefinitionType.Then:
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException, mediaEntity);
                        break;
                    default:
                        break;
                }
            }
        }

        [AfterTestRun]
        public static void CloseExtentReports()
        {
            _extentReports.Flush();
        }
    }
}
