(function () {

    angular.module('app')
        .controller('CostsController', CostsController);

    CostsController.$inject = ['$scope', '$window', 'blockUI', '$routeParams', 'toastr', 'utilityService', 'costCategoryService', 'localStorageService', 'costConfigurationService', 'equipmentService', 'valuesService', 'costService', 'fixedCostService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function CostsController($scope, $window, blockUI, $routeParams, toastr, utilityService, costCategoryService, localStorageService, costConfigurationService, equipmentService, valuesService, costService, fixedCostService, DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.user = localStorageService.get('user');
        vm.costConfiguration = {};
        vm.cost = {};
        vm.fixedCost = {};
        vm.listCost = [];
        vm.categories = [];
        vm.listEquipments = [];
        vm.btnSaveText = 'Salvar';
        vm.categoryLabels = [];
        vm.periodLabels = [];
        vm.categoryData = [];
        vm.periodData = [];

        //METHODS
        vm.initialize = initialize;
        vm.initControls = initControls;
        vm.openModalOptions = openModalOptions;
        vm.openModalCategory = openModalCategory;
        vm.openModalFixedCost = openModalFixedCost;
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
        vm.saveFixedCost = saveFixedCost;
        vm.initObjFixedCost = initObjFixedCost;
        vm.calcTotalFixedCost = calcTotalFixedCost;
        vm.loadDataGraphic = loadDataGraphic;
        vm.loadLabelsGraphic = loadLabelsGraphic;

        vm.initialize();

        function initialize() {

            vm.initControls();
            vm.loadDataTables();
            vm.loadConfiguration();
            vm.loadCategories();

            // EDIÇÃO
            if ($routeParams.id) {

                if ($routeParams.id > 0) {

                    vm.loadCost($routeParams.id);
                }
                else {

                    vm.initObjects();
                }
            }
            //LISTAGEM
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
                user: vm.user,
                fixedCost: []
            }

            vm.initObjFixedCost();

            var monthNumber = new Date().getMonth();

            vm.cost.referenceMonthText = utilityService.getMonthText(monthNumber) + ' de ' + new Date().getFullYear();
        }

        function initObjFixedCost() {

            vm.fixedCost = {

                description: '',
                value: 0,
                cost: vm.cost,
                costCategory: {}
            }
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
                vm.initObjFixedCost();

            }).error(function (response) {

                blockUI.stop();
            })
        }

        function loadListCost() {

            blockUI.start("Carregando Informações...");

            costService.getCostByUserId(vm.userId).success(function (response) {

                blockUI.stop();

                vm.listCost = response.valueList;

                vm.loadDataGraphic();
                vm.loadLabelsGraphic();

            })
        }

        function loadDataGraphic() {

            var totalPerCategory = 0;
            var totalperPeriod = 0;
            vm.categoryLabels = [];
            vm.periodLabels = [];
            vm.categoryData = [];
            vm.periodData = [];

            //GRAFICO POR CATEGORIA
            //OBTEM O TOTAL DOS GASTOS DE ACORDO COM A CATEGORIA, PRA ISSO PERCORRE TODOS OS CUSTOS FIXOS DE TODOS OS CUSTOS E OS AGRUPA POR CATEGORIA
            vm.categories.forEach(function (category) {

                vm.listCost.forEach(function (cost) {

                    cost.listFixedCost.forEach(function (fixedCost) {

                        if (fixedCost.costCategoryId == category.id) {

                            totalPerCategory += fixedCost.value;
                        }
                    })
                })

                vm.categoryData.push(totalPerCategory);
                totalPerCategory = 0;
            })

            vm.listCost.forEach(function (cost) {

                vm.periodData.push(cost.totalCost);
            })
        }

        function loadLabelsGraphic() {

            //GRAFICO POR CATEGORIA
            vm.categories.forEach(function (item) {

                vm.categoryLabels.push(item.description);
            })

            //GRAFICO POR PERIODO
            vm.listCost.forEach(function (cost) {

                vm.periodLabels.push(cost.referenceMonthText);
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

                blockUI.start("Validando Novo Custo...");

                costService.validateNewCost(vm.userId).success(function (response) {

                    blockUI.stop();

                    //False: Já existe um custo para o mes atual 
                    if (!response.logicalTest) {

                        toastr.error(response.message);
                    }
                    else {

                        $window.location.href = '#/costs?id=0';
                    }

                }).error(function (response) {

                    blockUI.stop();

                    toastr.error(response.message);
                })
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

        function calcTotalFixedCost() {

            if (vm.cost.listFixedCost) {

                var totalFixedCost = 0;

                vm.cost.listFixedCost.forEach(function (item) {

                    totalFixedCost += item.value;
                })
            }

            return totalFixedCost;
        }

        function submitForm() {

            if (!vm.cost.current) {


            }
            else if (vm.costConfiguration.preventCostOverLimit && vm.cost.totalCost > vm.costConfiguration.maxValue) {

                alert('vc gastou muito');
            }
            else {

                $scope.costsForm.$setSubmitted();

                if ($scope.costsForm.$valid) {

                    blockUI.start("Salvaldo Valores...");

                    vm.cost.totalDevaluationOfEquipment = vm.calcTotalDevaluation();

                    costService.save(vm.cost).success(function (response) {

                        blockUI.stop();

                        toastr.success(response.message);

                        vm.cost = response.value;
                        vm.initObjFixedCost();

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

        function saveFixedCost(params) {

            $scope.FixedCostForm.$setSubmitted();

            if ($scope.FixedCostForm.$valid) {

                blockUI.start('Salvando Gasto Mensal');

                fixedCostService.save(vm.fixedCost).success(function (response) {

                    blockUI.stop();

                    toastr.success(response.message);

                    loadCost(vm.cost.id);

                }).error(function (response) {

                    blockUI.stop();

                    toastr.error(response.message);
                })
            }
        }

        function openModalOptions() {

            angular.element('#costOptions').modal({

                blurring: false,
                closable: true,
                autofocus: true,
                onHide: function () {

                    vm.loadListCost();
                }

            }).modal('show');
        }

        function openModalCategory() {

            angular.element('#editCategory').modal({

                blurring: false,
                closable: true,
                autofocus: true,
                onHide: function () {

                    vm.openModalFixedCost();
                }

            }).modal('show');
        }

        function openModalFixedCost() {

            angular.element('#modalFixedCost').modal({

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