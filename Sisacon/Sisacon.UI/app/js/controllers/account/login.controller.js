angular.module('app.landingPage.account')

    .controller('LoginController', ['$scope', 'accountService', 'loggedUserService', '$window', 'toastr', 'blockUI',

    function ($scope, accountService, loggedUserService, $window, toastr, blockUI) {

    $scope.login = function () {

        if ($scope.loginForm.$valid) {

            blockUI.start('Validando Informações...');

            accountService.loginUser($scope.account).success(function (response) {

                blockUI.stop();

                $window.location.href = 'Index#/initialDashboard/' + response.value.id;

            }).error(function (response) {
                
                blockUI.stop();

                toastr.error(response.message);

            });
        }
    }

}]);