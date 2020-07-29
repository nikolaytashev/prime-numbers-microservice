using Application.Queries;
using Application.Validation;
using System.Numerics;
using Xunit;

namespace Application.Tests
{
    public class CheckPrimeNumberQueryValidatorTests
    {
        [Fact]
        public void ValidCheckPrimeNumberQuery()
        {
            var query = new CheckPrimeNumberQuery(Constants.PositiveNumber);

            var validator = new CheckPrimeNumberQueryValidator();
            var result = validator.Validate(query);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void InvalidCheckPrimeNumberQueryNegativeNumberError()
        {
            var query = new CheckPrimeNumberQuery(Constants.NegativeNumber);

            var validator = new CheckPrimeNumberQueryValidator();
            var result = validator.Validate(query);

            Assert.True(!result.IsValid);
        }
    }
}
