using MvcWithMsUnit.Entities;
using MvcWithMsUnit.Managers;
using System.Web.Mvc;

namespace MvcWithMsUnit.Controllers
{
    public class CountryController : Controller
    {

        //initialize service object
        ICountryManager _Country;

        public CountryController(ICountryManager country)
        {
            _Country = country;
        }

        //
        // GET: /Country/
        public ActionResult Index()
        {
            return View(_Country.GetAll());
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
            if (ModelState.IsValid)
            {
                _Country.Create(country);
                return RedirectToAction("Index");
            }
            return View(country);

        }

        //
        // GET: /Country/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = _Country.GetById(id);
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
                _Country.Update(country);
                return RedirectToAction("Index");
            }
            return View(country);

        }

        //
        // GET: /Country/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = _Country.GetById(id);
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
            Country country = _Country.GetById(id);
            _Country.Delete(country);
            return RedirectToAction("Index");
        }
    }
}