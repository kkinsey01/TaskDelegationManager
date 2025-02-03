using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace TaskDelegationAPI.Middleware
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly Serilog.ILogger _logger;
        public GlobalExceptionFilter(Serilog.ILogger logger)
        {
            _logger = logger;
        }


        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,

                ValidationException => StatusCodes.Status400BadRequest,

                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

                _ => StatusCodes.Status500InternalServerError
            };

            _logger.Error($"{context.Exception.Message}\n{context.Exception.StackTrace}");

            context.Result = new ObjectResult(new
            {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace,
            })
            {
                StatusCode = statusCode
            };
        }
    }
}
