using BoDi;
using NUnit.Framework;
using ToptalAutomationTask.Pages;

namespace ToptalAutomationTask.StepDefinitions
{
    [Binding]
    public class ContactUsSteps
    {
        ContactUsPage _contactUsPage;


        public ContactUsSteps(IObjectContainer objectContainer)
        {
            _contactUsPage = objectContainer.Resolve<ContactUsPage>();
        }

        [Then(@"User can see title (.*)")]
        public void ThenUserCanSeeTitle(string expectedText)
        {
            Assert.AreEqual(expectedText, _contactUsPage.GetTitleCustomerService());
        }

        [When(@"User choose (.*) from Subject Heading")]
        public void WhenUserChooseFromSubjectHeading(string subjectHeading)
        {
            _contactUsPage.SelectSubjectHeading(subjectHeading);
        }

        [When(@"User enter valid details for the form")]
        public void WhenUserEnterValidDetailsForTheForm()
        {
            _contactUsPage.EnterOtherDetails();
        }

        [When(@"User enter invalid email details for the form")]
        public void WhenUserEnterInvalidEmailDetailsForTheForm()
        {
            _contactUsPage.EnterInvalidEmailDetails();
        }


        [When(@"User send message")]
        public void WhenUserSendMessage()
        {
            _contactUsPage.ClickSendButton();
        }

        [Then(@"User verify success message (.*)")]
        public void ThenUserVerifySuccessMessage(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, _contactUsPage.GetSuccessMessage());
        }

        [When(@"User attach valid file")]
        public void WhenUserAttachValidFile()
        {
            _contactUsPage.AttachValidFile();
        }

        [When(@"User attach invalid file")]
        public void WhenUserAttachInvalidFile()
        {
            _contactUsPage.AttachInvalidFile();
        }

        [Then(@"User verify reason for error (.*)")]
        public void ThenUserVerifyReasonForError(string reasonForError)
        {
            Assert.AreEqual(reasonForError, _contactUsPage.GetReasonErrorMessage());
        }
        [When(@"User enter valid details without message")]
        public void WhenUserEnterValidDetailsWithoutMessage()
        {
            _contactUsPage.EnterOtherDetailsWithoutMessage();
        }





    }
}
