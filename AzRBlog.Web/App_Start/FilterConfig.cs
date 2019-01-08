using System.Web.Mvc;

namespace AzRBlog.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
#if DEBUG
            filters.Add(new HandleErrorAttribute());
#else
              filters.Add(new AzRBlog.Web.Filters.AzRExceptionFilterAttribute());
#endif
        }
    }
}
