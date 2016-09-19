angular.module('app.index', ['ngRoute', 'app.index.entries', 'app.index.estimate', 'ui.mask'])

    .config(['$routeProvider', function ($routeProvider) {

        $routeProvider

            .when('/company', {

                templateUrl: '/app/views/company/company.html',
                controller: 'CompanyController'
            })
            .when('/initialDashboard/:id', {

                templateUrl: '/app/views/InitialDashboard.html',
                controller: 'InitialDashboardController'
            })
            .when('/initialDashboard', {

                templateUrl: '/app/views/InitialDashboard.html',
                controller: 'InitialDashboardController'
            })
            //CADASTROS
            .when('/estimateDashboard', {

                templateUrl: '/app/views/estimate/estimateDashboard.html',
                controller: 'EstimateController'
            });

    }]).config(['uiMask.ConfigProvider', function (uiMaskConfigProvider) {

        uiMaskConfigProvider.maskDefinitions({ 'A': /[a-z]/, '*': /[a-zA-Z0-9]/ });
        uiMaskConfigProvider.clearOnBlur(false);
        uiMaskConfigProvider.eventsToHandle(['input', 'keyup', 'click']);
    }]);