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

        [HttpGet]
        [Authorize]
        public ViewResult Index()
        {
            return View(_catRepo.AllIncluding(cat => cat.Products));
        }

        [HttpGet]
        [Authorize]
        public ViewResult Details(int id)
        {
            return View(_catRepo.Find(id));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize]
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

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View(_catRepo.Find(id));
        }
        
        [HttpPost]
        [Authorize]
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

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(_catRepo.Find(id));
        }
        
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _catRepo.Delete(id);
            _catRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
