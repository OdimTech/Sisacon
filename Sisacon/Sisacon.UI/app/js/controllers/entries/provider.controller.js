(function () {

    'use strict';

    angular
        .module('app')
        .controller('ProviderController', ProviderController);

    ProviderController.$inject = ['$scope', '$window', 'blockUI', '$routeParams', 'toastr', 'viaCepService', 'utilityService', 'localStorageService', 'valuesService', 'providerService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function ProviderController($scope, $window, blockUI, $routeParams, toastr, viaCepService, utilityService, localStorageService, valuesService, providerService, DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        //INTIT CONTROLS
        angular.element('.ui.dropdown').dropdown();

        angular.element('button').popup({
            on: 'click',
            position: 'right center'
        });

        angular.element('.menu .item').tab();

        //VARIABLES
        vm.userId = localStorageService.get('id');


    }

})();