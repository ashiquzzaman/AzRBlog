using AzRBlog.Entities.Models;
using AzRBlog.Services;
using System.Net;
using System.Web.Mvc;

namespace AzRBlog.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserProfileService _user;
        private readonly ICountryService _country;
        public UserController(IUserProfileService user, ICountryService country)
        {
            _user = user;
            _country = country;
        }

        // GET: /User/
        public ActionResult Index()
        {
            return View(_user.GetAll());
        }

        // GET: /User/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _user.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }




        // GET: /User/Save/5
        public ActionResult Save(long? id)
        {

            var user = id != null && id > 0
                ? _user.GetById(id.Value)
                : new UserProfile
                {
                    Id = -1
                };
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(_country.GetAll(), "Id", "Name", user.CountryId);
            return View(user);
        }

        // POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserProfile model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    _user.Update(model);
                }
                else
                {
                    _user.Create(model);

                }


                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_country.GetAll(), "Id", "Name", model.CountryId);
            return View(model);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _user.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var user = _user.GetById(id);
            _user.Delete(user);
            return RedirectToAction("Index");
        }
    }
}