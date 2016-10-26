(function () {

    'use strict';

    angular
        .module('app')

        .config(['$routeProvider', function ($routeProvider) {

            $routeProvider

                .when('/company', {

                    templateUrl: '/app/views/company/company.html',
                    controller: 'CompanyController'
                })
                .when('/initialDashboard', {

                    templateUrl: '/app/views/InitialDashboard.html',
                    controller: 'InitialDashboardController'
                })
                //TOP MENU
                .when('/calendar', {

                    templateUrl: '/app/views/menu/calendar.html',
                    controller: 'CalendarController',
                    controllerAs: 'vm'

                })
                .when('/configuration', {

                    templateUrl: '/app/views/menu/configuration.html',
                    controller: 'ConfigurationController',
                    controllerAs: 'vm'

                })
                .when('/feedback', {

                    templateUrl: '/app/views/menu/feedback.html',
                    controller: 'FeedbackController',
                    controllerAs: 'vm'

                })
                .when('/myAccount', {

                    templateUrl: '/app/views/menu/myAccount.html',
                    controller: 'MyAccountController',
                    controllerAs: 'vm'

                })
                //CADASTROS
                .when('/clientList', {

                    templateUrl: '/app/views/entries/clientList.html',
                    controller: 'ClientController'
                })
                .when('/newClient', {

                    templateUrl: '/app/views/entries/newClient.html',
                    controller: 'ClientController'
                })
                .when('/newClient/:id', {

                    templateUrl: '/app/views/entries/newClient.html',
                    controller: 'ClientController'
                })
                .when('/providerList', {

                    templateUrl: '/app/views/entries/providerList.html',
                    controller: 'ProviderController',
                    controllerAs: 'vm'

                })
                .when('/newProvider', {

                    templateUrl: '/app/views/entries/newProvider.html',
                    controller: 'ProviderController',
                    controllerAs: 'vm'

                })
                .when('/newProvider/id', {

                    templateUrl: '/app/views/entries/newProvider.html',
                    controller: 'ProviderController',
                    controllerAs: 'vm'

                })
                .when('/estimateDashboard', {

                    templateUrl: '/app/views/estimate/estimateDashboard.html',
                    controller: 'EstimateController'
                })
                .when('/errorPage', {

                    templateUrl: '/app/views/errorPage.html'
                })
                .otherwise({

                    templateUrl: '/app/views/InitialDashboard.html'
                    //templateUrl: '/app/views/pageNotFound.html'
                });

        }]);



})();