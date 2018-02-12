using MvcWithMsUnit.Managers;
using System.Web.Mvc;

namespace MvcWithMsUnit.Controllers
{
    public class AccountTypeController : Controller
    {
        // GET: AccountType
        private IAccountTypeManager _accountType;

        public AccountTypeController(IAccountTypeManager accountType)
        {
            _accountType = accountType;
        }

        public ActionResult Index()
        {
            var model = _accountType.GetAll();
            return View(model);
        }
    }
}