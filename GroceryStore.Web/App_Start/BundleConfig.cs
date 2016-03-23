using System.Web;
using System.Web.Optimization;

namespace GroceryStore.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/Angular/angular.min.js",
                "~/Scripts/Angular/angular-resource.min.js",
                "~/Scripts/Angular/ui-router.min.js",
                "~/Scripts/Angular/App/app.js",
                "~/Scripts/Angular/App/Common/commonDirectives.js",
                "~/Scripts/Angular/App/Common/commonControllers.js",
                "~/Scripts/Angular/App/Products/productServices.js",               
                "~/Scripts/Angular/App/Products/productControllers.js",
                "~/Scripts/Angular/App/ProductReports/productReportControllers.js",
                "~/Scripts/Angular/App/Products/productDirectives.js",
                "~/Scripts/Angular/App/Categories/categoryServices.js",
                "~/Scripts/Angular/App/Categories/categoryControllers.js",
                "~/Scripts/Angular/App/Categories/categoryDirectives.js",
                "~/Scripts/Angular/App/Relationships/relationshipServices.js",
                "~/Scripts/Angular/App/Relationships/relationshipControllers.js",
                "~/Scripts/Angular/App/PriceSets/priceSetServices.js",
                "~/Scripts/Angular/App/PriceSets/priceSetControllers.js"              
                ));
        }
    }
}
