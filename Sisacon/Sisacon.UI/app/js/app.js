angular.module('sisacon', ['ngRoute', 'ui.mask'])

    .config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {

        $routeProvider
            .when('/login', {

                templateUrl: '/app/views/account/login.html',
                controller: 'LoginController'
            })
            .when('/singup', {

                templateUrl: '/app/views/account/singup.html',
                controller: 'SingUpController'
            })
            .otherwise({ redirectTo: '/index' });;

        $locationProvider.html5Mode(true);

    }]).config(['uiMask.ConfigProvider', function(uiMaskConfigProvider) {
        uiMaskConfigProvider.maskDefinitions({'A': /[a-z]/, '*': /[a-zA-Z0-9]/});
        uiMaskConfigProvider.clearOnBlur(false);
        uiMaskConfigProvider.eventsToHandle(['input', 'keyup', 'click']);
    }]);