using OpenQA.Selenium;
using ToptalAutomationTaskTests.Pages;

namespace ToptalAutomationTask.Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region WebElements


        private IWebElement SearchBox => _driver.FindElement(By.XPath("//input[@id='search_query_top']"));
        private IWebElement SearchButton => _driver.FindElement(By.XPath("//button[@name='submit_search']"));
        private IWebElement SearchResults => _driver.FindElement(By.XPath("//span[@class='heading-counter']"));
        private IList<IWebElement> ItemsFound => _driver.FindElements(By.XPath("//div[@class='product-image-container']"));
        private IList<IWebElement> ItemsFoundBySelectingFromDropdown => _driver.FindElements(By.XPath("//span//img[@id='bigpic']"));
        private IWebElement ItemTitle => _driver.FindElement(By.XPath($"//h1[@itemprop]"));
        private IWebElement AllertMessage => _driver.FindElement(By.XPath($"//div[@id='center_column']//p"));
        private IWebElement HeaderMenuButton(string button) => _driver.FindElement(By.XPath($"//div[@class='row']//div[contains(.,'{button}')]"));
        private IWebElement SearchedTerm(string term) => _driver.FindElement(By.XPath($"//div[@class='ac_results']//li[contains(.,'{term}')]"));
        private IList<IWebElement> NumberOfSearchedTerm(string term) => _driver.FindElements(By.XPath($"//div[@class='product-container']//h5[contains(.,'{term}')]"));




        #endregion

        #region Methods

        public void SearchInSearchField(string searchWord)
        {
            TypeText(SearchBox, searchWord);

        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public void ClickSearchTerm(string term)
        {
            WaitElement();
            SearchedTerm(term).Click();
        }

        public string GetNumberOfSearchResults()
        {
            return GetText(SearchResults);
        }

        public bool VerifySingleImage()
        {
            return ItemsFoundBySelectingFromDropdown.Count == 1;
        }

        public string GetSingleItemTitle()
        {
            return GetText(ItemTitle);
        }

        public int GetItemsCount()
        {
            return ItemsFound.Count();
        }

        public string GetAllertMessage()
        {
            return GetText(AllertMessage);

        }

        public void ClickHeaderMenuButton(string button)
        {
            WaitElement();
            ClickOn(HeaderMenuButton(button));
        }

        public int GetSearchedItemsCount(string term)
        {
            return NumberOfSearchedTerm(term).Count();
        }



        #endregion
    }
}
