using System.Web.Optimization;

namespace Sisacon.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-3.1.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/design").Include
               ("~/Scripts/semantic.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include
               ("~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/bower_components/angular-ui-mask/dist/mask.js",
                "~/Scripts/angular-toastr.tpls.js",
                "~/Scripts/angular-block-ui.js",
                //MODULES
                "~/app/js/app.module.js",
                "~/app/js/modules/admin/admin.module.js",
                "~/app/js/modules/index/index.module.js",
                "~/app/js/modules/landingPage/landingPage.module.js",
                "~/app/js/modules/index/entries.module.js",
                "~/app/js/modules/index/estimate.module.js",
                "~/app/js/modules/landingPage/account.module.js",
                //SERVICES
                "~/app/js/services/account.service.js",
                "~/app/js/services/viaCep.service.js",
                "~/app/js/services/values.service.js",
                "~/app/js/services/loggedUser.service.js",
                //CONTROLLERS
                "~/app/js/controllers/base/admin.controller.js",
                "~/app/js/controllers/base/index.controller.js",
                "~/app/js/controllers/base/landingPage.controller.js",
                "~/app/js/controllers/account/login.controller.js",
                "~/app/js/controllers/account/singup.controller.js",
                "~/app/js/controllers/entries/client.controller.js",
                "~/app/js/controllers/estimate/estimate.controller.js",
                "~/app/js/controllers/initialDashboard.controller.js",
                "~/app/js/controllers/company/company.controller.js",
                //DIRECTIVES
                "~/app/js/directives/validateEmail.directive.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/style").Include
                ("~/Content/semantic.css",
                "~/Content/Site.css",
                "~/Content/angular-toastr.css",
                "~/Content/angular-block-ui.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}