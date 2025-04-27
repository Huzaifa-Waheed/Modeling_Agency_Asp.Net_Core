using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web;

namespace Modeling_Agency.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute))
                && !context.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute)))
            {
                if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    if (context.HttpContext.Session.GetString("UserId") == null)
                    {
                        context.HttpContext.Response.StatusCode = 403;
                        context.Result = new JsonResult("LogOut");
                    }
                }
                else if (context.HttpContext.Session.GetString("UserId") == null)
                {
                    var returnUrlWithQueryString = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
                    var redirectUrl = $"/Identity/Account/Login?returnUrl={HttpUtility.UrlEncode(returnUrlWithQueryString)}";
                    context.Result = new RedirectResult(redirectUrl);
                }

            }
        }
    }
}
