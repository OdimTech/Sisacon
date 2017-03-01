(function () {

    angular.module('app')
        .controller('CostsController', CostsController);

    CostsController.$inject = ['$scope', '$window', 'blockUI', '$routeParams', 'toastr', 'utilityService', 'costCategoryService', 'localStorageService', 'configurationService', 'valuesService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function CostsController($scope, $window, blockUI, $routeParams, toastr, utilityService, costCategoryService, localStorageService, configurationService, valuesService, DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.user = localStorageService.get('user');
        vm.configuration = {};
        vm.cost = {};
        vm.categories = [];

        //METHODS
        vm.initialize = initialize;
        vm.initControls = initControls;
        vm.openModalOptions = openModalOptions;
        vm.openModalCategory = openModalCategory;
        vm.loadDataTables = loadDataTables;
        vm.loadCategories = loadCategories;
        vm.loadConfiguration = loadConfiguration;

        vm.initialize();

        function initialize() {

            vm.initControls();
            vm.loadDataTables();
            vm.loadCategories();
            vm.loadConfiguration();

            var monthNumber = new Date().getMonth();

            vm.cost.referenceMonth = utilityService.getMonthText(monthNumber);
        }

        function initControls() {

            angular.element('button').popup({
                on: 'click',
                position: 'right center'
            });
        }

        function loadDataTables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage)
                .withDisplayLength(10);
        }

        function loadCategories() {

            if (vm.userId) {

                costCategoryService.getCategoriesByUserId(vm.userId).success(function (response) {

                    vm.categories = response.valueList;
                })
            }
        }

        function loadConfiguration() {
            
            
        }

        function openModalOptions() {

            angular.element('#costOptions').modal({

                blurring: false,
                closable: true

            }).modal('show');
        }

        function openModalCategory() {

            angular.element('#editCategory').modal({

                blurring: false,
                closable: true,
                autofocus: true,
                onHide: function () {

                    vm.loadCategories();
                }

            }).modal('show');
        }
    }

})();