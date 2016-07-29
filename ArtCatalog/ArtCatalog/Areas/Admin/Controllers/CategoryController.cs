using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtCatalog.Models.Repositories;
using ArtCatalog.Models;

namespace ArtCatalog.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        // GET: /Category/
        public ViewResult Index()
        {
            return View(_catRepo.AllIncluding(cat => cat.Products));
        }

        // GET: Category/Details/5
        public ViewResult Details(int id)
        {
            return View(_catRepo.Find(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _catRepo.InsertOrUpdate(category);
                _catRepo.Save();
                return RedirectToAction("Index");
            }
            else
            return View();
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_catRepo.Find(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _catRepo.InsertOrUpdate(category);
                _catRepo.Save();
                return RedirectToAction("Index");
            }
            else
                return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_catRepo.Find(id));
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _catRepo.Delete(id);
            _catRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
