using AzRBlog.Entities;
using AzRBlog.Services;
using System.Web.Mvc;

namespace AzRBlog.Web.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {

        //initialize service object
        private readonly ICountryManager _country;

        public CountryController(ICountryManager country)
        {
            _country = country;
        }

        //
        // GET: /Country/
        public ActionResult Index()
        {
            return View(_country.GetAll());
        }

        //
        // GET: /Country/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            // TODO: Add insert logic here
            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError("Name", @"Please Insert Valid Country Name");
                return View(country);
            }

            _country.Create(country);
            return RedirectToAction("Index");
        }

        //
        // GET: /Country/Edit/5
        public ActionResult Edit(int id)
        {
            var country = _country.GetById(id);

            if (country == null)
            {
                return HttpNotFound();

            }
            return View(country);
        }

        //
        // POST: /Country/Edit
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _country.Update(country);
                return RedirectToAction("Index");
            }

            return View(country);

        }

        //
        // GET: /Country/Delete/5
        public ActionResult Delete(int id)
        {
            var country = _country.GetById(id);

            if (country == null)
            {
                return HttpNotFound();
            }

            return View(country);
        }

        //
        // POST: /Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection data)
        {
            var country = _country.GetById(id);
            _country.Delete(country);
            return RedirectToAction("Index");
        }
    }
}