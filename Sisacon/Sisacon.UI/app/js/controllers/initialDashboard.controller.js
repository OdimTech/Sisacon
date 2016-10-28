(function () {

    'use strict';

    angular
        .module('app')
        .controller('InitialDashboardController', InitialDashBoardController);

    InitialDashBoardController.$inject = ['$scope', 'accountService', 'companyService', 'localStorageService', 'blockUI'];

    function InitialDashBoardController($scope, accountService, companyService, localStorageService, blockUI) {

        //INIT OBJECTS
        $scope.company = {};
        $scope.loggedUser = localStorageService.get('id');
        $scope.companyName = '';

        getCompany();

        function getCompany() {

            if ($scope.loggedUser) {

                blockUI.start('Carregando Informações...');

                companyService.getCompanyByUser($scope.loggedUser.id).success(function (response) {

                    $scope.company = response.value;
                    blockUI.stop();

                    if ($scope.company) {

                        if ($scope.company.ePersonType == 1) {

                            $scope.companyName = $scope.company.companyName;
                        }
                        else {

                            $scope.companyName = $scope.company.fantasyName;
                        }
                    }

                }).error(function (response) {

                    blockUI.stop();
                });
            }
        }
    }

})();

