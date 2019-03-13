using System.Web;
using System.Web.Optimization;

namespace HFSRBO.WebClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/material/js").Include(
                        "~/Scripts/material/material.js",
                        "~/Scripts/material/init.js",
                        "~/Scripts/select2.js",
                        "~/Scripts/material/createComplaintFormSubmit.js",
                        "~/Scripts/lolibox.min.js"
                        ));

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
            bundles.Add(new StyleBundle("~/material/css").Include(
                      "~/Content/fonts.css",
                      "~/Content/materialize.css",
                      "~/Content/paralax.css",
                      "~/Content/page.css",
                      "~/Content/select2.css",
                      "~/Content/lolibox.min.css"
                      ));
        }
    }
}
