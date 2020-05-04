using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhoneBook.Core.Exceptions;
using PhoneBook.Core.Models;

namespace PhoneBook.Api.Filter
{
    public sealed class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var response = new ServiceResponse<object>(context.Exception.Message)
            { Data = null };

            context.HttpContext.Response.StatusCode = context.Exception switch
            {
                UnauthorizedException _ => StatusCodes.Status401Unauthorized,
                BadRequestException _ => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError,
            };

            context.Result = new JsonResult(response);
            base.OnException(context);
        }
    }
}
