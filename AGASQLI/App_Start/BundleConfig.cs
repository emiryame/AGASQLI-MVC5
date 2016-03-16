using System.Web;
using System.Web.Optimization;

namespace AGASQLI
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/lib/jquery-{version}.js",
                        "~/Content/lib/jquery.sortelements.js",
                        "~/Content/lib/jquery.bdt.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/lib/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/lib/bootstrap.js",
                      "~/Content/lib/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Content/js/default.js",
                      "~/Content/js/layout.js",
                      "~/Content/js/main.js",
                      "~/Content/js/site.js",
                      "~/Content/js/watch.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                       "~/Content/css/brown.css",
                       "~/Content/css/font-awesome.min.css",
                       "~/Content/css/linecons.css",
                       "~/Content/css/normalize.css",
                       "~/Content/css/site.css",
                       "~/Content/css/style.css"));
        }
    }
}
