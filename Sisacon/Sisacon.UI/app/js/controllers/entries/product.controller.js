(function () {

    angular.
        module('app').
        controller('ProductController', ProductController);

    ProductController.$inject = ['$scope', 'blockUI', '$routeParams', 'toastr', 'materialService', 'valuesService', 'localStorageService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function ProductController($scope, blockUI, $routeParams, toastr, materialService, valuesService, localStorageService, DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        // VARIABLES   
        vm.product = {};
        vm.materials = [];
        vm.user = localStorageService.get('user');

        // METHODS
        vm.initialize = initialize;
        vm.loadDatatables = loadDatatables;
        vm.loadMaterials = loadMaterials;
        vm.showModalAddMaterial = showModalAddMaterial;

        vm.initialize();

        function initialize() {

            angular.element('button').popup({
                on: 'click',
                position: 'right center'
            });

            vm.loadDatatables();
            vm.loadMaterials();
        }

        function loadDatatables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage)
                .withDisplayLength(10);
        }

        function loadMaterials() {

            materialService.getMaterialByUserId(vm.user.id).success(function (response) {

                vm.materials = response.valueList;

            }).error(function (response) {

                console.log(response.message);
            })
        }

        function showModalAddMaterial() {

            angular.element('#addMaterialModal').modal({

                blurring: false,
                closable: true,
                autofocus: true

            }).modal('show');
        }
    }

})();