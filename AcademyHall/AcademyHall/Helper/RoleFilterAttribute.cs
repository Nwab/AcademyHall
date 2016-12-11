using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace AcademyHall.Helper
{
    public class RoleFilterAttribute : FilterAttribute, IAuthenticationFilter
    {
        string SUPER_ADMIN = "SuperAdmin";
        string TEACHER = "Teacher";

        public void OnAuthentication(AuthenticationContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated &&
                (context.HttpContext.User.IsInRole(SUPER_ADMIN) || context.HttpContext.User.IsInRole(TEACHER)))
            {
                //do nothing
            }
            else
            {
                context.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if (context.Result == null || context.Result is HttpUnauthorizedResult)
            {
                context.Result = new RedirectToRouteResult("Default",
                    new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Account"},
                        {"action", "Login"},
                        {"returnUrl", context.HttpContext.Request.RawUrl}
                    });
            }
        }
    }
}