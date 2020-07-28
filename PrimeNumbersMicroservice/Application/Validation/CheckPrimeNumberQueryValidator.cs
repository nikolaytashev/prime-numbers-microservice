using Application.Queries;
using FluentValidation;

namespace Application.Validation
{
    public class CheckPrimeNumberQueryValidator : AbstractValidator<CheckPrimeNumberQuery>
    {
        public CheckPrimeNumberQueryValidator()
        {
            RuleFor(item => item.Value).SetValidator(new PositivePrimeNumberValidator());
        }
    }
}
