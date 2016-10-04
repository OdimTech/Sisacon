using System.Web.Optimization;

namespace Sisacon.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-3.1.1.js",
                "~/node_modules/fullcalendar/node_modules/moment/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/design").Include
               ("~/Scripts/semantic.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include
               ("~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/bower_components/angular-ui-mask/dist/mask.js",
                "~/Scripts/angular-toastr.tpls.js",
                "~/Scripts/angular-block-ui.js",
                "~/Sctipts/ng-file-upload-shim.js",
                "~/Scripts/ng-file-upload.js",
                "~/bower_components/angular-local-storage/dist/angular-local-storage.js",
                "~/node_modules/angular-ui-calendar/src/calendar.js",
                "~/node_modules/fullcalendar/dist/fullcalendar.min.js",
                //MODULE
                "~/app/js/app.module.js",
                //CONFIG-ROUTES
                "~/app/js/config/routes/indexRoutes.config.js",
                "~/app/js/config/routes/landingPageRoutes.config.js",
                //CONFIG
                "~/app/js/config/toastr.config.js",
                "~/app/js/config/blockUI.config.js",
                "~/app/js/config/localStorage.config.js",
                "~/app/js/config/interceptors.config.js",
                //INTERCEPTORS
                "~/app/js/interceptors/timestamp.interceptor.js",
                "~/app/js/interceptors/error.interceptor.js",
                //SERVICES
                "~/app/js/services/account.service.js",
                "~/app/js/services/viaCep.service.js",
                "~/app/js/services/values.service.js",
                "~/app/js/services/company.service.js",
                "~/app/js/services/localStorage.service.js",
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
                "~/Content/angular-block-ui.css",
                "~/node_modules/fullcalendar/dist/fullcalendar.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}