using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AzRCMS.WEBFW.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly List<string> _exceptCtrls = new List<string> { "userauth" };

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);

            //    return httpContext.Session != null && httpContext.Session.Count != 0;
            return isAuthorized;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var routeData = filterContext.HttpContext.Request.RequestContext.RouteData;
            var controller = routeData != null ? routeData.Values["controller"] as string : string.Empty;
            var check = !string.IsNullOrEmpty(controller) && !_exceptCtrls.Contains(controller.ToLower());


            var flag = filterContext.ActionDescriptor
                            .IsDefined(typeof(AllowAnonymousAttribute), true)
                        || filterContext.ActionDescriptor.ControllerDescriptor
                            .IsDefined(typeof(AllowAnonymousAttribute), true);


            if (check && !flag && !filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
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
            else if (check && !flag && !Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
            {

                filterContext.Result = new HttpUnauthorizedResult();
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
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