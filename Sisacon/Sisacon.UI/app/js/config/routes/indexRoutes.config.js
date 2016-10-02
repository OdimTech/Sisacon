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
                //CADASTROS
                .when('/estimateDashboard', {

                    templateUrl: '/app/views/estimate/estimateDashboard.html',
                    controller: 'EstimateController'
                })
                .when('/errorPage', {

                    templateUrl: '/app/views/errorPage.html'  
                })
                .when('',{

                    
                })
                .otherwise({

                    templateUrl: '/app/views/pageNotFound.html'
                });

        }]);



})();