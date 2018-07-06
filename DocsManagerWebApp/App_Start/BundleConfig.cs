using System.Web;
using System.Web.Optimization;

namespace DocsManagerWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/angularJs").Include(
                "~/Scripts/angular.js",
                "~/Scripts/ng-file-upload-shim.js",
                "~/Scripts/ng-file-upload.js",
                "~/Scripts/custom-scripts/fileCache.js",
                "~/Scripts/custom-scripts/uploadProgressbar.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js"));

    
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));


        }
    }
}
