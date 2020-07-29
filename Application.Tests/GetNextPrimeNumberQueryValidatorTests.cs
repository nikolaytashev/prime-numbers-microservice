using Application.Queries;
using Application.Validation;
using Xunit;

namespace Application.Tests
{
    public class GetNextPrimeNumberQueryValidatorTests
    {
        [Fact]
        public void ValidGetNextPrimeNumberQuery()
        {
            var query = new GetNextPrimeNumberQuery(Constants.PositiveNumber);

            var validator = new GetNextPrimeNumberQueryValidator();
            var result = validator.Validate(query);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void InvalidGetNextPrimeNumberQueryNegativeNumberError()
        {
            var query = new GetNextPrimeNumberQuery(Constants.NegativeNumber);

            var validator = new GetNextPrimeNumberQueryValidator();
            var result = validator.Validate(query);

            Assert.True(!result.IsValid);
        }
    }
}
