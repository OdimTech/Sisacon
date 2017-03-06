(function () {

    angular.module('app')
        .controller('CostsController', CostsController);

    CostsController.$inject = ['$scope', '$window', 'blockUI', '$routeParams', 'toastr', 'utilityService', 'costCategoryService', 'localStorageService', 'costConfigurationService', 'equipmentService', 'valuesService', 'costService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function CostsController($scope, $window, blockUI, $routeParams, toastr, utilityService, costCategoryService, localStorageService, costConfigurationService, equipmentService, valuesService, costService, DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.user = localStorageService.get('user');
        vm.costConfiguration = {};
        vm.cost = {};
        vm.listCost = [];
        vm.categories = [];
        vm.listEquipments = [];
        vm.btnSaveText = 'Salvar';

        //METHODS
        vm.initialize = initialize;
        vm.initControls = initControls;
        vm.openModalOptions = openModalOptions;
        vm.openModalCategory = openModalCategory;
        vm.loadDataTables = loadDataTables;
        vm.loadCategories = loadCategories;
        vm.loadConfiguration = loadConfiguration;
        vm.initObjects = initObjects;
        vm.calcDevaluation = calcDevaluation;
        vm.calcTotalDevaluation = calcTotalDevaluation;
        vm.validateNewCost = validateNewCost;
        vm.loadListCost = loadListCost;
        vm.loadCost = loadCost;
        vm.submitForm = submitForm;
        vm.editCost = editCost;

        vm.initialize();

        function initialize() {

            vm.initControls();
            vm.loadDataTables();
            vm.loadConfiguration();

            // EDIÇÃO
            if ($routeParams.id) {

                if ($routeParams.id > 0) {

                    vm.loadCost($routeParams.id);
                }
                else {

                    vm.initObjects();
                }

                vm.loadCategories();
            }
            else {

                vm.loadListCost();
            }
        }

        function initObjects() {

            vm.cost = {

                id: 0,
                salary: 0,
                workedHours: 0,
                closed: false,
                current: true,
                referenceMonthText: '',
                user: vm.user
            }

            var monthNumber = new Date().getMonth();

            vm.cost.referenceMonthText = utilityService.getMonthText(monthNumber) + ' de ' + new Date().getFullYear();
        }

        function initControls() {

            angular.element('button').popup({
                on: 'click',
                position: 'right center'
            });
        }

        function loadCost(costId) {

            blockUI.start("Carregando Custo Mensal...");

            costService.getCostById(costId).success(function (response) {

                blockUI.stop();

                vm.cost = response.value;
                vm.btnSaveText = 'Atualizar';

            }).error(function (response) {

                blockUI.stop();
            })
        }

        function loadListCost() {

            blockUI.start("Carregando Informações...");

            costService.getCostByUserId(vm.userId).success(function (response) {

                blockUI.stop();

                vm.listCost = response.valueList;

            })
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

            costConfigurationService.getCostConfigurationByUserId(vm.userId).success(function (response) {

                vm.costConfiguration = response.value;

                if (vm.costConfiguration) {

                    // CASO A OPÇÃO DE ICLUIR A DESVALORIZAÇÃO DE EQUIPAMENTOS ESTEJA MARCADA, CARREGA OS EQUIPAMENTOS
                    if (vm.costConfiguration.includDevaluationOfEquipment) {

                        equipmentService.getEquipsByUserId(vm.userId).success(function (response) {

                            vm.listEquipments = response.valueList;
                        })
                    }
                }
            })
        }

        function validateNewCost() {

            if (vm.listCost.length > 0) {

                $window.location.href = '#/costs?id=0';
            }
            else {

                $window.location.href = '#/costs?id=0';
            }
        }

        function calcTotalDevaluation() {

            if (!vm.cost.current) {

                return vm.cost.totalDevaluationOfEquipment;
            }
            else {

                if (vm.listEquipments) {

                    var totalDevaluation = 0;

                    vm.listEquipments.forEach(function (item) {

                        totalDevaluation += calcDevaluation(item);
                    })

                    return totalDevaluation;
                }
            }
        }

        function calcDevaluation(equipment) {

            if (equipment) {

                var devaluation = 0;

                devaluation = equipment.valor / (equipment.lifeSpan * 12);

                return devaluation;
            }
        }

        function submitForm() {

            if (!vm.cost.current) {


            }
            else if (vm.costConfiguration.preventCostOverLimit && vm.cost.totalCost > vm.costConfiguration.maxValue) {


            }
            else {

                $scope.costsForm.$setSubmitted();

                if ($scope.costsForm.$valid) {

                    blockUI.start("Salvaldo Base de Cálculo...");

                    vm.cost.totalDevaluationOfEquipment = vm.calcTotalDevaluation();

                    costService.save(vm.cost).success(function (response) {

                        blockUI.stop();

                        toastr.success(response.message);

                        vm.cost = response.value;

                    }).error(function (response) {

                        blockUI.stop();

                        toastr.error(response.message);
                    })
                }
            }
        }

        function editCost(costId) {

            if (costId) {

                $window.location.href = '#/costs?id=' + costId;
            }
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