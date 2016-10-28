using System.Web.Optimization;

namespace Sisacon.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-3.1.1.js",
                "~/Scripts/moment.js",
                "~/Scripts/moment-with-locales.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.semanticui.js"));

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
                "~/bower_components/angular-datatables/dist/angular-datatables.js",
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
                "~/app/js/services/notification.service.js",
                "~/app/js/services/client.service.js",
                "~/app/js/services/provider.service.js",
                "~/app/js/services/utility.service.js",
                "~/app/js/services/configuration.service.js",
                //CONTROLLERS
                "~/app/js/controllers/base/admin.controller.js",
                "~/app/js/controllers/base/index.controller.js",
                "~/app/js/controllers/base/landingPage.controller.js",
                "~/app/js/controllers/account/login.controller.js",
                "~/app/js/controllers/account/singup.controller.js",
                "~/app/js/controllers/entries/client.controller.js",
                "~/app/js/controllers/entries/provider.controller.js",
                "~/app/js/controllers/estimate/estimate.controller.js",
                "~/app/js/controllers/initialDashboard.controller.js",
                "~/app/js/controllers/company/company.controller.js",
                "~/app/js/controllers/menu/calendar.controller.js",
                "~/app/js/controllers/menu/configuration.controller.js",
                "~/app/js/controllers/menu/feedback.controller.js",
                "~/app/js/controllers/menu/myAccount.controller.js",
                //DIRECTIVES
                "~/app/js/directives/validateEmail.directive.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/style").Include
                ("~/Content/semantic.css",
                "~/Content/Site.css",
                "~/Content/angular-toastr.css",
                "~/Content/angular-block-ui.css",
                "~/node_modules/fullcalendar/dist/fullcalendar.css",
                "~/Content/DataTables/css/dataTables.semanticui.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}