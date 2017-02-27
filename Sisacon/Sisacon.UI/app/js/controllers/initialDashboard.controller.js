(function () {

    'use strict';

    angular
        .module('app')
        .controller('InitialDashboardController', InitialDashBoardController);

    InitialDashBoardController.$inject = ['$scope', 'accountService', 'localStorageService','utilityService', 'blockUI'];

    function InitialDashBoardController($scope, accountService, localStorageService,utilityService, blockUI) {

        //INIT OBJECTS
        $scope.company = {};
        $scope.loggedUser = localStorageService.get('user');
        $scope.companyName = '';

        initialize();

        function initialize() {

            $scope.loggedUser.lastLogin = utilityService.convertDateToString($scope.loggedUser.lastLogin);

        }
    }

})();

