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

namespace ArtCatalog.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _prodRepo = new ProductRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        // GET: Product
        public ViewResult Index()
        {
            return View(_prodRepo.AllIncluding(prod => prod.Categ));
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
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

        // GET: Product/Create
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

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductDescription,ProducedAt,Size,CategoryID,ThumbinalPath,OriginalPath")] Product product)
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

        // GET: Product/Edit/5
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

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductDescription,ProducedAt,Size,CategoryID,ThumbinalPath,OriginalPath")] Product product)
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

        // GET: Product/Delete/5
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

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _prodRepo.Delete(id);
            _prodRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
