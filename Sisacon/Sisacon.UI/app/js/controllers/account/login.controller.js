(function () {

    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', 'accountService', 'localStorageService', 'configurationService', 'toastr', 'blockUI', '$window'];

    function LoginController($scope, accountService, localStorageService, configurationService, toastr, blockUI, $window) {

        $scope.config = {};
        $scope.idUser = 0;

        $scope.login = function () {

            if ($scope.loginForm.$valid) {

                blockUI.start('Validando Informações...');

                accountService.loginUser($scope.account).success(function (response) {

                    blockUI.stop();
            
                    $scope.User = response.value;
                    localStorageService.set('id', $scope.User.id);
                    
                    loadSystem();

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);

                });
            }
        }

        function loadSystem() {

            configurationService.getConfigurationByIdUser($scope.User.id).success(function (response) {

                $scope.config = response.value;

                if ($scope.config) {

                    $window.location.href = 'Index' + $scope.config.defaultPage;
                }
                else {

                    $window.location.href = 'Index' + '#/initialDashBoard';
                }

            }).error(function (response) {

                console.log(response.message);

            })

            

        }
    }

})();

