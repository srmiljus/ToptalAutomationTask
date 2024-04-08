using OpenQA.Selenium;
using ToptalAutomationTask.Utilities;
using ToptalAutomationTaskTests.Pages;

namespace ToptalAutomationTask.Pages
{
    public class ContactUsPage : BasePage
    {
        private readonly IWebDriver _driver;

        public ContactUsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region WebElements


        private IWebElement CustomerServiceText => _driver.FindElement(By.XPath("//div[@id='center_column']/h1"));
        private IWebElement SubjectHeading => _driver.FindElement(By.XPath("//select[@class='form-control']"));
        private IWebElement ChooseValueFromDropdown(string value) => _driver.FindElement(By.XPath($"//select[@class='form-control']//option[contains(.,'{value}')]"));
        private IWebElement InputEmail => _driver.FindElement(By.XPath($"//input[@id='email']"));
        private IWebElement OrderRefInput => _driver.FindElement(By.XPath($"//input[@id='id_order']"));
        private IWebElement AttachFileInput => _driver.FindElement(By.XPath($"//input[@id='fileUpload']"));
        private IWebElement TextAreaInput => _driver.FindElement(By.XPath($"//textarea[@id='message']"));
        private IWebElement SendButton => _driver.FindElement(By.XPath($"//button[@id='submitMessage']"));
        private IWebElement SuccessMessage => _driver.FindElement(By.XPath($"//div[@id='center_column']//p"));
        private IWebElement ErrorMessage => _driver.FindElement(By.XPath($"//div[@class='alert alert-danger']//li"));


        #endregion

        #region Methods

        public string GetTitleCustomerService()
        {
            return GetText(CustomerServiceText);
        }

        public void SelectSubjectHeading(string value)
        {
            ClickOn(SubjectHeading);
            ClickOn(ChooseValueFromDropdown(value));
        }
        public void EnterOtherDetails()
        {
            var emailDetails = Helpers.CreateEmailDetails();
            TypeText(InputEmail, emailDetails.Email_Address);
            TypeText(OrderRefInput, emailDetails.Order_reference);
            TypeText(TextAreaInput, emailDetails.Message);
        }

        public void EnterOtherDetailsWithoutMessage()
        {
            var emailDetails = Helpers.CreateEmailDetails();
            TypeText(InputEmail, emailDetails.Email_Address);
            TypeText(OrderRefInput, emailDetails.Order_reference);
        }

        public void EnterInvalidEmailDetails()
        {
            var invalidMail = TestData.TestDataConstants.InvalidPassword;
            TypeText(InputEmail, invalidMail);
        }

        public void AttachValidFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, @"TestFiles\Test.txt");
            TypeText(AttachFileInput, filePath);
        }

        public void AttachInvalidFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, @"TestFiles\Superman.jfif");
            TypeText(AttachFileInput, filePath);
        }
        public void ClickSendButton()
        {
            ClickOn(SendButton);
        }

        public string GetSuccessMessage()
        {
            return GetText(SuccessMessage);
        }
        public string GetReasonErrorMessage()
        {
            return GetText(ErrorMessage);
        }


        #endregion
    }
}
