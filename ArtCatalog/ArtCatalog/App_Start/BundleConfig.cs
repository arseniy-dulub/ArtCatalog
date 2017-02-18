using System.Web;
using System.Web.Optimization;

namespace ArtCatalog
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/common.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css",
                      "~/Content/bootstrap.css")
                      );

            bundles.Add(new StyleBundle("~/Content/css/colorbox").
                Include("~/Content/colorbox.css"));

            bundles.Add(new ScriptBundle("~/bundles/colorbox").
                Include(
                "~/Scripts/colorbox/jquery.colorbox.js",
                "~/Scripts/colorbox/colorbox-viewer.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular/vendor/angular.min.js",
                      "~/Scripts/angular/app/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/tokenfield").Include(
                    "~/Scripts/bootstrap-tokenfield/bootstrap-tokenfield.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/tokenfield").Include(
                "~/Content/bootstrap-tokenfield/tokenfield-typeahead.min.css",
                "~/Content/bootstrap-tokenfield/bootstrap-tokenfield.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                    "~/Scripts/typeahead/bloodhound.min.js",
                    "~/Scripts/typeahead/typeahead.jquery.min.js",
                    "~/Scripts/typeahead/typeahead.bundle.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                "~/Scripts/jquery-ui-1.10.1.custom.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/jquery-ui/css").Include(
                "~/Content/jquery-ui-1.10.1.custom.min.css"));
        }
    }
}
