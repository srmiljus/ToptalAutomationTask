namespace APITests.Models
{
    public class BookingModel
    {
        public string firstname { get; set; }

        public string lastname { get; set; }

        public long totalprice { get; set; }

        public bool depositpaid { get; set; }

        public BookingDatesModel bookingdates { get; set; }

        public string additionalneeds { get; set; }
    }

    public class BookingDatesModel
    {
        public string Checkin { get; set; }

        public string Checkout { get; set; }
    }
}
