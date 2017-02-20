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
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Upload(HttpPostedFileWrapper uplFile)
        {
            try
            {
                var filePath = $"/Content/files/{uplFile.FileName}";
                PreviewCreator.CreateAndSavePreview(
                    uplFile.InputStream,
                    PreviewCreator.ReduceSize(uplFile.InputStream, 600),
                    Server.MapPath(filePath));

                var filePreviewPath = $"/Content/files/previews/{uplFile.FileName}";
                PreviewCreator.CreateAndSavePreview(
                    uplFile.InputStream,
                    new Size(300, 225),
                    Server.MapPath(filePreviewPath));               

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