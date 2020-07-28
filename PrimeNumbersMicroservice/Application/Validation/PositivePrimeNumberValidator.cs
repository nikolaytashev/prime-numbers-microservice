using Application.Queries;
using Core.Common;
using FluentValidation;
using System.Numerics;

namespace Application.Validation
{
    public class PositivePrimeNumberValidator : AbstractValidator<BigInteger>
    {
        public PositivePrimeNumberValidator()
        {
            RuleFor(item => item.Sign).NotEqual(Constants.NegativeSignNumber).WithMessage("Value must not be negative.");
        }
    }
}
