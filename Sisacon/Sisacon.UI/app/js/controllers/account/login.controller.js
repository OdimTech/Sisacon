(function () {

    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', 'accountService', 'localStorageService', 'toastr', 'blockUI', '$window'];

    function LoginController($scope, accountService, localStorageService,toastr, blockUI, $window) {

        $scope.login = function () {

            if ($scope.loginForm.$valid) {

                blockUI.start('Validando Informações...');

                accountService.loginUser($scope.account).success(function (response) {

                    blockUI.stop();

                    localStorageService.set('id', response.value.id);
                    $window.location.href = 'Index#/initialDashboard';

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);

                });
            }
        };
    }

})();

