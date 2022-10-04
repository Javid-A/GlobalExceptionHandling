using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GlobalExceptionHandling.Filters
{
    public class ExceptionHandlingAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //var errorModel = new ErrorModel
            //{
            //    StatusCode = context.HttpContext.Response.StatusCode,
            //    Message = context.Exception.Message
            //};

            ProblemDetails details = new ProblemDetails
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1",
                Title = "Custom Problem Details"
            };
            context.Result = new ObjectResult(details);
        }
    }
}
