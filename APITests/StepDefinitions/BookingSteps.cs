using APITests.Helpers;
using APITests.Models;
using BoDi;
using Newtonsoft.Json;
using RestSharp;

namespace APITests.StepDefinitions
{
    [Binding]
    public class BookingSteps
    {
        private RestResponse _response;
        private RestResponse _checkBookingIsDeleted;
        private BookingModel _bookingData;
        private string _token;
        RestClient _restClient;
        private readonly IObjectContainer _container;

        public BookingSteps(IObjectContainer container)
        {
            _container = container;
            _restClient = _container.Resolve<RestClient>();
        }

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
            var response = RestHelper.CreateToken(_restClient);
            _token = DataHelper.GetTokenValueFromResponse(response);
        }

        [Given(@"Request is sent to CREATE a booking")]
        [When(@"Request is sent to CREATE a booking")]
        [Then(@"Request is sent to CREATE a booking")]
        public void RequestIsSentToCreateABooking()
        {
            _response = RestHelper.CreateBooking(_restClient, _bookingData);
        }

        [When(@"Request is sent to GET a booking")]
        public void RequestIsSentToGetABooking()
        {
            var response = RestHelper.CreateBooking(_restClient, _bookingData);
            var bookingId = DataHelper.GetBookingIdFromCreateBookingResponse(response).ToString();
            _response = RestHelper.GetBookingId(_restClient, bookingId);
        }

        [When(@"Request is sent to UPDATE a booking")]
        public void RequestIsSentToUpdateABooking()
        {
            var bookingId = GetBookingId();
            _bookingData.additionalneeds = "Test";
            _response = RestHelper.UpdateBooking(_restClient, _bookingData, bookingId, _token);
        }
        [Given(@"Request is sent to DELETE a booking")]
        [When(@"Request is sent to DELETE a booking")]
        public void RequestIsSentToDeleteABooking()
        {
            var bookingId = GetBookingId();
            _response = RestHelper.DeleteBooking(_restClient, bookingId, _token);
            _checkBookingIsDeleted = RestHelper.GetBookingId(_restClient, bookingId);
        }

        [Given(@"Request is sent to GET a booking with id (.*)")]
        [When(@"Request is sent to GET a booking with id (.*)")]
        [Given(@"Request is sent to GET a booking with id (.*)")]
        public void GivenRequestIsSentToGETABookingWithId(string bookingId)
        {
            _response = RestHelper.GetBookingId(_restClient, bookingId);
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
            var bookingIdsResponse = RestHelper.GetBookingIds(_restClient);
            var bookingId = DataHelper.GetBookingIdFromGetBookingIdsResponse(bookingIdsResponse).ToString();
            return bookingId;
        }
    }
}