(function () {

    'use strict';

    angular
        .module('app')
        .controller('CostConfiguration', CostConfiguration);

    CostConfiguration.$inject = ['$scope', 'toastr', 'localStorageService', 'costConfigurationService'];

    function CostConfiguration($scope, toastr, localStorageService, costConfigurationService) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.costConfiguration = {};
        //METHODS
        vm.save = save;
        vm.loadConfiguration = loadConfiguration;

        loadConfiguration();

        function save() {

            if ($scope.costConfigForm.$valid)
            {
                costConfigurationService.save(vm.costConfiguration).success(function (response) {

                    toastr.success(response.message);

                }).error(function (response) {

                    toastr.error(response.message);

                })
            }
        }

        function loadConfiguration() {

            costConfigurationService.getCostConfigurationByUserId(vm.userId).success(function (response) {

                vm.costConfiguration = response.value;

            }).error(function (response) {

                toastr.error('Não foi possivel carregar as Configurações de Custo, tente novamente mais tarde.')
            })

        }
    }

})();