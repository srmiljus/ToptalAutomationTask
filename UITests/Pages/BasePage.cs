using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ToptalAutomationTaskTests.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        private readonly TimeSpan _timeout;
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

        public IWebElement WaitForElementToBeVisible(By element)
        {
            {
                int attempts = 0;
                while (attempts < 3)
                {
                    try
                    {
                        WebDriverWait wait = new WebDriverWait(_driver, _timeout);
                        return wait.Until(ExpectedConditions.ElementIsVisible(element));
                    }
                    catch (NoSuchElementException)
                    {
                        _driver.Navigate().Refresh();
                        attempts++;
                    }
                    catch (WebDriverTimeoutException)
                    {
                        _driver.Navigate().Refresh();
                        attempts++;
                    }
                }
                throw new NoSuchElementException($"Element is not visible after {attempts} attempts.");
            }
        }
    }
}

