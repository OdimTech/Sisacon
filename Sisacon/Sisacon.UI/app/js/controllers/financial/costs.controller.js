(function () {

    angular.module('app')
        .controller('CostsController', CostsController);

    CostsController.$inject = ['$scope', '$window', 'blockUI', '$routeParams', 'toastr', 'utilityService', 'localStorageService', 'configurationService'];

    function CostsController($scope, $window, blockUI, $routeParams, toastr, utilityService, localStorageService, configurationService) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.configuration = {};

        //METHODS
        vm.initControls = initControls;
        vm.openModalOptions = openModalOptions;

        function initControls() {


        }

        function openModalOptions() {

            angular.element('#costOptions').modal({

                blurring: false,
                closable: true

            }).modal('show');
        }
    }

})();