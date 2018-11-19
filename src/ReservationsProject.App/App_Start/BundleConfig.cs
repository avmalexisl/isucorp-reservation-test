using System.Web;
using System.Web.Optimization;

namespace ReservationsProject.App
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                    "~/node_modules/jquery/dist/jquery.min.js",
                    "~/node_modules/bootstrap/dist/js/bootstrap.min.js",
                    "~/node_modules/froala-editor/js/froala_editor.pkgd.min.js",
                    "~/node_modules/knockout/build/output/knockout-latest.js",
                    "~/node_modules/knockout/build/output/knockout-latest.debug.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                    "~/node_modules/bootstrap/dist/css/bootstrap.min.css",
                    "~/node_modules/font-awesome/css/font-awesome.min.css",
                    "~/node_modules/froala-editor/css/froala_editor.pkgd.min.css",
                    "~/Content/styles/base.css",
                    "~/Content/styles/common.css",
                    "~/Content/styles/custom.css"));
        }
    }
}
