using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PipeLineBehavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            IValidationContext context = new ValidationContext<TRequest>(request);
            var failures = validators.Select(item => item.Validate(context))
                .Where(item => !item.IsValid)
                .SelectMany(item => item.Errors).ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return next();
        }
    }
}
