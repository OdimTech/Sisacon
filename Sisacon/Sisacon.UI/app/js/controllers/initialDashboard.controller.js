﻿(function () {

    'use strict';

    angular
        .module('app')
        .controller('InitialDashboardController', InitialDashBoardController);

    InitialDashBoardController.$inject = ['$scope', 'accountService', 'companyService', 'localStorageService', 'utilityService', 'blockUI'];

    function InitialDashBoardController($scope, accountService, companyService, localStorageService, utilityService, blockUI) {

        var vm = this;

        //INIT OBJECTS
        vm.company = {};
        vm.loggedUser = localStorageService.get('user');
        vm.companyName = '';
        vm.countEntities = {};

        // METHODS
        vm.loadCompany = loadCompany;
        vm.incrementBar = incrementBar;
        vm.getCountEntities = getCountEntities;

        initialize();

        function initialize() {

            $('.progress')
                .progress({
                    text: {
                        active: 'Etapa {value} de {total} Concluída',
                        success: 'Parabéns! Você está pronto(a) para o Sucesso!'
                    }
                });

            angular.element('.image').dimmer({

                on: 'hover'
            });

            vm.loggedUser.lastLogin = utilityService.convertDateToString(vm.loggedUser.lastLogin);

            vm.loadCompany();
            vm.getCountEntities();
        }

        function getCountEntities() {
            
            accountService.getCountEntities(vm.loggedUser.id).success(function (response) {  

                vm.countEntities = response.value;
            })
            .error(function (response) {  

                
            })
            
        }

        function loadCompany(params) {

            companyService.getCompanyByUser(vm.loggedUser.id).success(function (response) {

                vm.company = response.value;
            })
        }

        function incrementBar() {

            angular.element('.progress').progress('increment');
        }

        
    }

})();

