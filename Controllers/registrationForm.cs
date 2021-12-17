using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bbnl.Controllers
{
    public class registrationForm : Controller
    {
        // GET: registrationForm
        public ActionResult Index()
        {
            return View();
        }

        // GET: registrationForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: registrationForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: registrationForm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: registrationForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: registrationForm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: registrationForm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: registrationForm/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
