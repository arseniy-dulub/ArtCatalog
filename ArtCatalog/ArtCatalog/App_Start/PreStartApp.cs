using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ArtCatalog.App_Start.PreStartApp), "Start")]
namespace ArtCatalog.App_Start
{
    public static class PreStartApp
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Start()
        {
            logger.Info("Application Prestart");
        }
    }
}