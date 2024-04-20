using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ToptalAutomationTaskTests.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ClickOn(IWebElement webElement)
        {
            webElement.Click();
        }

        public void TypeText(IWebElement webElement, string text)
        {
            webElement.SendKeys(text);
        }

        public string GetText(IWebElement webElement)
        {
            return webElement.Text;
        }

        public void WaitElement()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public IWebElement ElementIsClickable(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}

