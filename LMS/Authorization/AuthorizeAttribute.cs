
using Microsoft.AspNetCore.Mvc.Filters;

using Microsoft.AspNetCore.Mvc;


namespace LMS.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
     

        public AuthorizeAttribute()
        {
       
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Items["resultAuth"] == null) {
                context.Result = new JsonResult(new { message = "Unauthroized" }) { StatusCode = StatusCodes.Status401Unauthorized };

            }


        }
    }
}
