using System;
using Microsoft.AspNetCore.Mvc.Filters;
using PhoneBook.Core.Exceptions;

namespace PhoneBook.Api.Filter
{
    public class AuthorizationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;

            headers.TryGetValue("Authorization", out var authToken);

            if (string.IsNullOrEmpty(authToken.ToString()))
                throw new UnauthorizedException("Unauthorized access");

            context.HttpContext.Items.Add("session", new AuthSession { UserId = Guid.Parse(authToken) });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        { }
    }
}
