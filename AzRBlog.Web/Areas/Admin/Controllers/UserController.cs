﻿using AzRBlog.Entities.Models;
using AzRBlog.Services;
using System.Net;
using System.Web.Mvc;

namespace AzRBlog.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        IUserProfileService _Person;
        ICountryService _Country;
        public UserController(IUserProfileService person, ICountryService country)
        {
            _Person = person;
            _Country = country;
        }

        // GET: /Person/
        public ActionResult Index()
        {
            return View(_Person.GetAll());
        }

        // GET: /Person/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile person = _Person.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: /Person/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(_Country.GetAll(), "Id", "Name");
            return View();
        }

        // POST: /Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Address,State,CountryId")] UserProfile person)
        {
            if (ModelState.IsValid)
            {
                _Person.Create(person);
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(_Country.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: /Person/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile person = _Person.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(_Country.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // POST: /Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Address,State,CountryId")] UserProfile person)
        {
            if (ModelState.IsValid)
            {
                _Person.Update(person);
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_Country.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: /Person/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile person = _Person.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: /Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            UserProfile person = _Person.GetById(id);
            _Person.Delete(person);
            return RedirectToAction("Index");
        }
    }
}