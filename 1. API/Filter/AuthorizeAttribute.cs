using _3._Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _1._API.Filter
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        // Autorizacion por roles
        private readonly List<string> _roles;

        public AuthorizeAttribute(params string[] roles)
        {
            _roles = (roles.Count()>0) ? roles.FirstOrDefault().Split(",").ToList() : new List<string>();
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                return;
            }

            var user = (User)context.HttpContext.Items["User"];

            if (user == null || !_roles.Any() || (_roles.Any() && !_roles.Contains(user.Roles)))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
