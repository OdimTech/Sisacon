angular.module('app.landingPage.account', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {

        $routeProvider
            .when('/singup', {

                templateUrl: '/app/views/account/singup.html',
                controller: 'SingUpController'
            })
            .when('/login', {

                templateUrl: '/app/views/account/login.html',
                controller: 'LoginController'
            });

    }]);
