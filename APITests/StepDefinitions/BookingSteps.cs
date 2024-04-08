using APITests.Helpers;
using APITests.Models;
using Newtonsoft.Json;
using RestSharp;
using ToptalAutomationTask.Configuration;

namespace APITests.StepDefinitions
{
    [Binding]
    public class BookingSteps 
    {
        private RestResponse _response;
        private RestResponse _checkBookingIsDeleted;
        private BookingModel _bookingData;
        private string _token;

        public BookingSteps() { }

        [Given(@"Request body is prepared with valid data")]
        public void RequestBodyIsPreparedWithValidData()
        {
            _bookingData = DataHelper.CreateBookingData();
        }

        [Given(@"Request body is prepared with invalid data")]
        public void GivenRequestBodyIsPreparedWithInvalidData()
        {
            _bookingData = DataHelper.CreateBookingWithInvalidData();
        }


        [Given(@"Request is sent to GET a token")]
        public void RequestIsSentToGetAaToken()
        {
            var response = ConfigManager.GetRestClient().CreateToken();
            _token = DataHelper.GetTokenValueFromResponse(response);
        }

        [Given(@"Request is sent to CREATE a booking")]
        [When(@"Request is sent to CREATE a booking")]
        [Then(@"Request is sent to CREATE a booking")]
        public void RequestIsSentToCreateABooking()
        {
            _response = ConfigManager.GetRestClient().CreateBooking(_bookingData);
        }

        [When(@"Request is sent to GET a booking")]
        public void RequestIsSentToGetABooking()
        {
            var response = ConfigManager.GetRestClient().CreateBooking(_bookingData); 
            var bookingId = DataHelper.GetBookingIdFromCreateBookingResponse(response).ToString();
            _response = ConfigManager.GetRestClient().GetBookingId(bookingId);
        }

        [When(@"Request is sent to UPDATE a booking")]
        public void RequestIsSentToUpdateABooking()
        {
            var bookingId = GetBookingId();
            _bookingData.additionalneeds = "Test";
            _response = ConfigManager.GetRestClient().UpdateBooking(_bookingData, bookingId, _token);
        }
        [Given(@"Request is sent to DELETE a booking")]
        [When(@"Request is sent to DELETE a booking")]
        public void RequestIsSentToDeleteABooking()
        {
            var bookingId = GetBookingId();
            _response = ConfigManager.GetRestClient().DeleteBooking(bookingId, _token); 
            _checkBookingIsDeleted = ConfigManager.GetRestClient().GetBookingId(bookingId);
        }

        [Given(@"Request is sent to GET a booking with id (.*)")]
        [When(@"Request is sent to GET a booking with id (.*)")]
        [Given(@"Request is sent to GET a booking with id (.*)")]
        public void GivenRequestIsSentToGETABookingWithId(string bookingId)
        {
            _response = ConfigManager.GetRestClient().GetBookingId(bookingId);
        }

        [Then(@"Response should be (.*) and (.*)")]
        public void ResponseShouldBeAndSuccess(int statusCode, string statusMessage)
        {
            Convert.ToInt32(_response.StatusCode).Should().Be(statusCode);
            _response.StatusCode.ToString().Should().Be(statusMessage);
        }

        [Then(@"Response data corresponds with (.*) data")]
        public void ResponseDataCorrespondsWithCreatedData(string requestType)
        {
            var responseMessage = _response.Content.ToString();
            var actualData = JsonConvert.DeserializeObject<BookingModel>(responseMessage);
            actualData.Should().BeEquivalentTo(_bookingData);
        }

        [Then(@"Response for checking deleted booking should be (.*) and (.*)")]
        public void ResponseForCheckingDeletedBookingShouldBeAndNotFound(int statusCode, string statusMessage)
        {
            Convert.ToInt32(_checkBookingIsDeleted.StatusCode).Should().Be(statusCode);
            _checkBookingIsDeleted.Content.Should().Be(statusMessage);
        }

        private string GetBookingId()
        {
            var bookingIdsResponse = ConfigManager.GetRestClient().GetBookingIds();
            var bookingId = DataHelper.GetBookingIdFromGetBookingIdsResponse(bookingIdsResponse).ToString();
            return bookingId;
        }
    }
}