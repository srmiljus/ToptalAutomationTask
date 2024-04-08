using Bogus;
using ToptalAutomationTask.Models;

namespace ToptalAutomationTask.Utilities
{
    public static class Helpers
    {


        public static EmailDetails CreateEmailDetails()
        {
            var faker = new Faker();

            var emailDetails = new EmailDetails()
            {
                Email_Address = faker.Internet.Email(),
                Order_reference = faker.Random.AlphaNumeric(6),
                Message = faker.Lorem.Sentence()
            };

            return emailDetails;
        }
    }
}
