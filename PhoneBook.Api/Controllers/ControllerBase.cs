namespace PhoneBook.Api.Controllers
{
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected AuthSession GetUserToken()
        {
            HttpContext.Items.TryGetValue("session", out var authorizedSession);
            var session = (AuthSession)authorizedSession;
            return session;
        }
    }
}
