using Application.Validation;
using System.Linq;
using System.Numerics;
using Xunit;

namespace Application.Tests
{
    public class PositivePrimeNumberValidatorTests
    {
        [Fact]
        public void PositiveNumberSuccessful()
        {
            var validator = new PositivePrimeNumberValidator();
            var result = validator.Validate(Constants.PositiveNumber);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void NegativeNumberError()
        {
            var validator = new PositivePrimeNumberValidator();
            var result = validator.Validate(Constants.NegativeNumber);

            Assert.True(!result.IsValid);
        }
    }
}
