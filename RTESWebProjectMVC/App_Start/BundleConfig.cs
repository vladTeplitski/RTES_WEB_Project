using System.Web;
using System.Web.Optimization;

namespace RTESWebProjectMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Lib/jquery-{version}.js",
                        "~/Scripts/Lib/jquery.unobtrusive-ajax.js",  // Microsoft jQuery Unobtrusive Ajax 3.2.3 for ajax
                        "~/Scripts/Lib/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Lib/jquery.validate*"));

            //angular
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/Lib/angular.min.js"));

            //My application scripts
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                         "~/Scripts/Functions/app.js",
                         "~/Scripts/Functions/funcLib.js"));

            //Bootstrap scripts
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Lib/bootstrap.js",
                      "~/Scripts/Lib/respond.js"));

            //CSS Files
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/project.css",
                      "~/Content/bootstrap.css",
                      "~/Content/tooltip.css",
                      "~/Content/login_register.css"));
        }
    }
}
