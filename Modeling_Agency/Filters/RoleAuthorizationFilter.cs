using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Modeling_Agency.Filters
{
    public class RoleAuthorizationFilter : ActionFilterAttribute
    {
        private readonly string _role;
        public RoleAuthorizationFilter(string role)
        {
            _role = role;
        }   

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.IsInRole(_role))
            {
                context.Result = new RedirectToPageResult("/Accout/AccessDenied", new { area = "Identity"});
            }
        }
    }
}
