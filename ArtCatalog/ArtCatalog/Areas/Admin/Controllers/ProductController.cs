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
using System.IO;
using ArtCatalog.Tools;
using System.Drawing;
using System.Web.Routing;

namespace ArtCatalog.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _prodRepo = new ProductRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View(_prodRepo.AllIncluding(prod => prod.Categ));
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            Product product = new Product();
            product.CategoryID = _catRepo.All.First().CategoryID;
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(_catRepo.All, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _prodRepo.InsertOrUpdate(product);
                _prodRepo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(_catRepo.All, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }


        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _prodRepo.Find((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(_catRepo.All, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }
        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _prodRepo.InsertOrUpdate(product);
                _prodRepo.Save();
                return RedirectToAction("Index");
            }
            else
                return View(product);
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _prodRepo.Find((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _prodRepo.Delete(id);
            _prodRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
