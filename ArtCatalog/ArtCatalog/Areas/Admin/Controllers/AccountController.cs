using ArtCatalog.Areas.Admin.Models;
using ArtCatalog.Models.DbContext;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ArtCatalog.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;
                using (CatalogContext db = new CatalogContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Name && u.Password == model.Password);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Product");
        }
    }
}