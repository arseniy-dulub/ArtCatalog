using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtCatalog.Models.Repositories;
using ArtCatalog.Models;

namespace ArtCatalog.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ProductRepository _prodRepo = new ProductRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        // GET: Catalog
        //public ActionResult Index()
        //{
        //    return View(_prodRepo.AllIncluding(product => product.Categ));
        //}

        public ViewResult Index(int? id)
        {
            ViewBag.Categories = _catRepo.AllIncluding(category => category.Products);
            if (id == null || id == 0)
                return View(_prodRepo.AllIncluding(product => product.Categ));
            else
                return View(_prodRepo.All.Where(product => product.CategoryID == id));
        }
    }
}