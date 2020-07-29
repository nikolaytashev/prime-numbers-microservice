using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using FluentValidation;
using System.Linq;

namespace PrimeNumbersMicroservice.Common
{
    /// <summary>ExceptionFilter</summary>
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> logger;

        /// <summary>Constructs the ExceptionFilter</summary>
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            this.logger = logger;
        }

        /// <summary>Called before the action executes, after model binding is complete.</summary>
        public void OnException(ExceptionContext context)
        {
            if (context.Exception == null)
                return;

            logger.LogError(context.Exception, context.HttpContext.Request.Path);
            var m = (ValidationException)context.Exception;
            context.Result = context.Exception switch
            {
                ValidationException validationException => new BadRequestObjectResult(string.Join("/", validationException.Errors)),
                _ => new ObjectResult(context.Exception.Message) { StatusCode = (int)HttpStatusCode.InternalServerError },
            };

            context.ExceptionHandled = true;
        }
    }
}
