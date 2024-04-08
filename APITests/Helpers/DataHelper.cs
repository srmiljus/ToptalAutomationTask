using APITests.Models;
using Bogus;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITests.Helpers
{
    public class DataHelper
    {
        public static BookingModel CreateBookingData()
        {
            Faker faker = new Faker();

            var bookingData = new BookingModel()
            {
                firstname = faker.Name.FirstName(),
                lastname = faker.Name.LastName(),
                totalprice = (long)faker.Finance.Amount(0, 1000, 2),
                depositpaid = true,
                bookingdates = PrepareBookingDates(faker),
                additionalneeds = "Breakfast"
            };

            return bookingData;
        }

        public static BookingModel CreateBookingWithInvalidData()
        {
            Faker faker = new Faker();

            var bookingData = new BookingModel()
            {
                firstname = string.Empty,
                lastname = string.Empty,
                totalprice = (long)faker.Finance.Amount(0, 1000, 2),
                additionalneeds = string.Empty
            };
            return bookingData;
        }

        public static BookingDatesModel PrepareBookingDates(Faker faker)
        {
            var bookingDates = new BookingDatesModel()
            {
                Checkin = faker.Date.Future(1).ToString("yyyy-MM-dd"),
                Checkout = faker.Date.Future(2).ToString("yyyy-MM-dd"),
            };

            return bookingDates;
        }
        public static string GetTokenValueFromResponse(RestResponse response)
        {
            var data = JObject.Parse(response.Content);
            return data["token"].ToString();
        }

        public static int GetBookingIdFromGetBookingIdsResponse(RestResponse response)
        {
            var data = JArray.Parse(response.Content);
            var bookingId = data[0]["bookingid"].Value<int>();
            return bookingId;
        }

        public static int GetBookingIdFromCreateBookingResponse(RestResponse response)
        {
            var data = JObject.Parse(response.Content);
            var bookingId = data["bookingid"].Value<int>();
            return bookingId;
        }
    }
}
