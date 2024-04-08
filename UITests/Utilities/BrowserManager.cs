using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using ToptalAutomationTask.Configuration;

namespace ToptalAutomationTask.Utilities
{
    public class BrowserManager
    {
        public static IWebDriver GetWebDriver()
        {
            IWebDriver driver;

            bool headless = ConfigManager.GetHeadless();
            string browser = ConfigManager.Browser.ToLower();

            switch (browser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (headless)
                    {
                        chromeOptions.AddArgument("--headless");
                        chromeOptions.AddArgument("--window-size=1920,1080");
                    }
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (headless)
                    {
                        firefoxOptions.AddArgument("-headless");
                        firefoxOptions.AddArgument("--window-size=1920,1080");
                    }
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                default:
                    throw new NotSupportedException("Unsupported browser.");
            }

            driver.Manage().Window.Maximize();
            return driver;
        }

        public static void KillBrowserDrivers()
        {
            var drivers = Process.GetProcessesByName("chromedriver");

            foreach (var driver in drivers)
            {
                driver.Kill();
            }
        }
    }
}
