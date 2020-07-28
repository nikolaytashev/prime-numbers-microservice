using Application.Queries;
using FluentValidation;

namespace Application.Validation
{
    public class GetNextPrimeNumberQueryValidator : AbstractValidator<GetNextPrimeNumberQuery>
    {
        public GetNextPrimeNumberQueryValidator()
        {
            RuleFor(item => item.Value).SetValidator(new PositivePrimeNumberValidator());
        }
    }
}
