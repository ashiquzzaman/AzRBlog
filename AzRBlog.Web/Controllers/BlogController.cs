using System.Web.Mvc;

namespace AzRBlog.Web.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}