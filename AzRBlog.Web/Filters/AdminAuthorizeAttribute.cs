using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace AzRCMS.WEBFW.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)//every request which has Authorize attribute is filter hear
        {
            var routeData = filterContext.HttpContext.Request.RequestContext.RouteData;
            var area = routeData.DataTokens["area"];

            var isAdmin = area != null && area.ToString().Equals("Admin", StringComparison.InvariantCultureIgnoreCase)
                                        && filterContext.HttpContext.User.Identity.IsAuthenticated
                                        && filterContext.HttpContext.User.IsInRole("Admin");// check admin role and admin area

            if (!isAdmin)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                if (filterContext.HttpContext.Request.IsAjaxRequest())//if ajax request set Forbidden( http code 403)
                {
                    filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;//.NET 4.5+
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    filterContext.HttpContext.Response.End();
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"action", "Login"},
                        {"controller", "UserAuth"},
                        {"area", ""}
                    });
                }

            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }

        }
    }
}
