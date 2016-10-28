(function () {

    'use strict';

    angular
        .module('app')
        .controller('ProviderController', ProviderController);

    ProviderController.$inject = ['$window', 'blockUI', '$routeParams', 'toastr', 'viaCepService', 'utilityService', 'localStorageService', 'valuesService', 'providerService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function ProviderController($window, blockUI, $routeParams, toastr, viaCepService, utilityService, localStorageService, valuesService, providerService, DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.provider = {};
        vm.nameClient = '';
        vm.initControls = initControls
        vm.loadDataTables = loadDataTables;

        vm.initControls();
        vm.loadDataTables();

        function initControls() {

            angular.element('.ui.dropdown').dropdown();

            angular.element('button').popup({
                on: 'click',
                position: 'right center'
            });

            angular.element('.menu .item').tab();

        }

        function loadDataTables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage);

        }
    }

})();