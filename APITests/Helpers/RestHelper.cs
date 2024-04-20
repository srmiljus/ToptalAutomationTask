using APITests.Models;
using RestSharp;

namespace APITests.Helpers
{
    public static class RestHelper
    {
        //Request Authorization
        public static RestResponse CreateToken(RestClient restClient)
        {
            var request = new RestRequest("auth", Method.Post)
         .AddJsonBody(new TokenModel
         {
             Username = "admin",
             Password = "password123"
         });

            return restClient.Post(request);
        }

        #region Booking

        public static RestResponse GetBookingIds(RestClient restClient)
        {
            var request = new RestRequest("booking", Method.Get)
           .AddHeader("Accept", "application/json")
           .AddHeader("Content-Type", "application/json");

            return restClient.Execute(request);
        }

        public static RestResponse GetBookingId(RestClient restClient, string bookingId)
        {
            var request = new RestRequest($"booking/{bookingId}", Method.Get)
                   .AddHeader("Accept", "application/json")
                   .AddHeader("Content-Type", "application/json");

            return restClient.Execute(request);
        }

        public static RestResponse CreateBooking(RestClient restClient, BookingModel body)
        {
            var request = new RestRequest("booking", Method.Post)
                 .AddHeader("Accept", "application/json")
                 .AddHeader("Content-Type", "application/json")
                 .AddJsonBody(body);

            return restClient.Execute(request);
        }

        public static RestResponse CreateBookingWithoutHeader(this RestClient restClient, BookingModel body)
        {
            var request = new RestRequest("booking", Method.Post)
                .AddJsonBody(body);

            return restClient.Execute(request);
        }

        public static RestResponse UpdateBooking(RestClient restClient, BookingModel body, string bookingId, string tokenValue)
        {
            var request = new RestRequest($"booking/{bookingId}", Method.Put)
                 .AddHeader("Accept", "application/json")
                 .AddHeader("Content-Type", "application/json")
                .AddHeader("Cookie", $"token={tokenValue}")
                .AddJsonBody(body);

            return restClient.Execute(request);
        }

        public static RestResponse DeleteBooking(RestClient restClient, string bookingId, string tokenValue)
        {
            var request = new RestRequest($"booking/{bookingId}", Method.Delete)
                  .AddHeader("Accept", "application/json")
                  .AddHeader("Cookie", $"token={tokenValue}");

            return restClient.Execute(request);
        }

        #endregion
    }
}
