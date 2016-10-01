(function () {
    
    'use strict';

    angular
        .module('app')
        
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

})();