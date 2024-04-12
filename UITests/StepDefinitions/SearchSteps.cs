using BoDi;
using NUnit.Framework;
using ToptalAutomationTask.Configuration;
using ToptalAutomationTask.Pages;

namespace ToptalAutomationTask.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        HomePage _homePage;



        public SearchSteps(IObjectContainer objectContainer)
        {
            _homePage = objectContainer.Resolve<HomePage>();
        }

        [Given(@"User opened the home page")]
        public void GivenUserOpenedTheHomePage()
        {
            _homePage.GoToPage(ConfigManager.HomePageUrl);
            //_homePage.WaitForPageToLoad();
        }

        [When(@"User enter (.*) in search bar")]
        public void WhenUserEnterInSearchBar(string searchWord)
        {
            _homePage.SearchInSearchField(searchWord);

        }

        [When(@"User can see message (.*)")]
        public void WhenUserCanSeeMessage(string expectedResults)
        {
            Assert.AreEqual(expectedResults, _homePage.GetNumberOfSearchResults());
        }

        [Then(@"User verify there is (.*) items shown")]
        public void ThenUserVerifyThereIsItemsShown(int numberOfItems)
        {
            Assert.AreEqual(numberOfItems, _homePage.GetItemsCount());
        }
        [Then(@"User verify alert message (.*)")]
        public void ThenUserVerifyAlertMessage(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, _homePage.GetAllertMessage());
        }

        [When(@"User click on search button")]
        public void WhenUserClickOnSearchButton()
        {
            _homePage.ClickSearchButton();
        }

        [When(@"User choose (.*) term from dropdown")]
        public void WhenUserChooseTermFromDropdown(string term)
        {
            _homePage.ClickSearchTerm(term);
        }

        [When(@"User can see (.*) title")]
        public void WhenUserCanSeeTitle(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, _homePage.GetSingleItemTitle());
        }


        [When(@"User click on (.*) header menu button")]
        public void WhenUserClickOnHeaderMenuButton(string button)
        {
            _homePage.ClickHeaderMenuButton(button);
        }

        [Given(@"User can see picture of only one item")]
        [When(@"User can see picture of only one item")]
        [Then(@"User can see picture of only one item")]
        public void WhenUserCanSeePictureOfOnlyOneItem()
        {
            _homePage.VerifySingleImage();
        }

    }
}
