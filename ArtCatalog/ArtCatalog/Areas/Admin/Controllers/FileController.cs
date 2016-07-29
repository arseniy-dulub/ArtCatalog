using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ArtCatalog.Tools;
using System.Drawing;

namespace ArtCatalog.Areas.Admin.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(HttpPostedFileWrapper qqfile)
        {
            try
            {
                var filePath = Path.Combine("/Content/files", qqfile.FileName);

                qqfile.SaveAs(Server.MapPath(filePath));

                var filePreviewPath = Path.Combine("/Content/files/previews", qqfile.FileName);
                var previewIconSize = new Size(300, 225);
                if (previewIconSize != null)
                {
                    PreviewCreator.CreateAndSavePreview(
                        qqfile.InputStream, 
                        new Size(previewIconSize.Width, previewIconSize.Height),
                        Server.MapPath(filePreviewPath));
                }

                return Json(new
                {
                    success = true,
                    result = "error",
                    data = new
                    {
                        filePath,
                        filePreviewPath
                    }
                });
            }
            catch
            {
                return Json(new { error = "Нужно загрузить изображение", success = false });
            }
        }
    }
}