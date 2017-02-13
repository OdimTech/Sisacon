(function () {

    'use stricts';

    angular.module('app').controller('MaterialController', MaterialController);

    MaterialController.$inject = ['$scope', '$window', '$routeParams', 'configurationService', 'materialService', 'providerService', 'materialCategoryService', 'priceResearchService', 'utilityService', 'localStorageService', 'blockUI', 'toastr'];

    function MaterialController($scope, $window, $routeParams, configurationService, materialService, providerService, materialCategoryService, priceResearchService, utilityService, localStorageService, blockUI, toastr) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.user = localStorageService.get('user');
        vm.material = {};
        vm.materialList = [];
        vm.priceReaserch = {};
        vm.configuration = {};
        vm.providers = [];
        vm.categories = [];
        vm.labels = [];
        vm.data = [[]];
        vm.btnSaveText = '';
        vm.idMaterialToRemove = '';

        //METHODS
        vm.loadConfiguration = loadConfiguration;
        vm.loadMaterial = loadMaterial;
        vm.loadCategories = loadCategories;
        vm.loadProviders = loadProviders;
        vm.loadMaterialList = loadMaterialList;
        vm.loadDataTables = loadDataTables;
        vm.newMaterial = newMaterial;
        vm.showModalEditCategory = showModalEditCategory;
        vm.addPriceResearch = addPriceResearch;
        vm.removePrice = removePrice;
        vm.submitForm = submitForm;
        vm.editMaterial = editMaterial;
        vm.showModalRemoveMaterial = showModalRemoveMaterial;
        vm.removeMaterialFromList = removeMaterialFromList;
        vm.removeMaterial = removeMaterial;
        vm.showModalPriceChart = showModalPriceChart;
        vm.showModalEditPrice = showModalEditPrice;
        vm.showModalHistoryChart = showModalHistoryChart;
        vm.addDataToGraphic = addDataToGraphic;

        initialize();

        function initialize() {

            vm.loadConfiguration();
            vm.loadProviders();
            vm.loadCategories();

            if ($routeParams.id) {

                loadMaterial($routeParams.id);
            }
            else {

                loadMaterialList();
            }

            initObjectPriceResearch();
        }

        function initObjectMaterial() {

            vm.material = {

                id: 0,
                user: vm.user,
                listPriceResearch: [],
                category: {
                    id: 0
                }
            };

        }

        function initObjectPriceResearch() {

            vm.priceReaserch = {

                id: 0,
                material: vm.material,
                provider: {
                    id: 0
                },
                dateToView: ''
            };
        }

        function loadConfiguration() {

            if (vm.userId) {

                configurationService.getConfigurationByIdUser(vm.userId).success(function (response) {

                    vm.configuration = response.value;
                })
            }
        }

        function loadMaterial(id) {

            if (id > 0) {

                blockUI.start('Carregando Material...');

                materialService.getMaterialById(id).success(function (response) {

                    response.value.registrationDate = utilityService.convertDateToString(response.value.registrationDate);

                    vm.btnSaveText = 'Atualizar';
                    vm.material = response.value;

                    //Caso não haja nenhuma pesquisa de preço, preparo o obj para ser salvo
                    if (vm.material.listPriceResearch.length == 0) {

                        vm.priceReaserch.material = vm.material;
                    }
                    else {

                        //Exibe o ultimo preço salvo
                        var lastPriceIndex = vm.material.listPriceResearch.length - 1;

                        vm.priceReaserch = vm.material.listPriceResearch[lastPriceIndex];

                        vm.material.listPriceResearch.forEach(function (item) {

                            vm.addDataToGraphic(item);
                        })
                    }

                    blockUI.stop();

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);

                })

            }
            else {

                if ($scope.materialForm) {

                    $scope.materialForm.$setPristine();
                }

                vm.btnSaveText = 'Salvar';

                initObjectMaterial();
            }

        }

        function loadProviders() {

            if (vm.userId) {

                providerService.getProviderByUserId(vm.userId).success(function (response) {

                    vm.providers = response.valueList;
                })
            }
        }

        function loadCategories() {

            if (vm.userId) {

                materialCategoryService.getCategoriesByUserId(vm.userId).success(function (response) {

                    vm.categories = response.valueList;
                })
            }
        }

        function loadDataTables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage);

        }

        function loadMaterialList() {

            blockUI.start('Carregando Materiais');

            materialService.getMaterialByUserId(vm.userId).success(function (response) {

                vm.materialList = response.valueList;

                blockUI.stop();

            }).error(function (response) {

                blockUI.stop();

                toastr.error('Erro ao carregar a lista de Materiais');
            })
        }

        function newMaterial() {

            if (!$scope.materialForm.$pristine) {

                angular.element('#newMaterialModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
            else {

                loadMaterial(0);
            }
        }

        function showModalEditCategory() {

            angular.element('#editCategory').modal({

                blurring: false,
                closable: true,
                autofocus: true,
                onHide: function () {

                    vm.loadCategories();
                }

            }).modal('show');

        }

        function showModalEditPrice() {

            $scope.priceResearchForm.$setSubmitted();

            if ($scope.priceResearchForm.$valid) {

                angular.element('#editMaterialPrice').modal({

                    blurring: false,
                    closable: true,
                    autofocus: true

                }).modal('show');
            }
        }

        function submitForm() {

            $scope.materialForm.$setSubmitted();

            if ($scope.materialForm.$valid) {

                blockUI.start("Salvando Material...");

                vm.material.registrationDate = utilityService.convertStringToDate(vm.material.registrationDate);

                materialService.save(vm.material).success(function (response) {

                    blockUI.stop();

                    vm.material = response.value;

                    toastr.success(response.message);

                    if (vm.material) {

                        loadMaterial(vm.material.id);
                    }

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        function editMaterial(id) {

            if (id > 0) {

                $window.location.href = "#/newMaterial?id=" + id;
            }
        }

        function showModalPriceChart() {

            angular.element('#showPriceResearchChart').modal({

                blurring: false,
                closable: true

            }).modal('show');

        }

        function showModalHistoryChart() {

            angular.element('#showHistoryChart').modal({

                blurring: false,
                closable: true

            }).modal('show');
        }

        function showModalRemoveMaterial(material) {

            if (material.id) {

                vm.idMaterialToRemove = material.id;

                vm.nameMaterial = material.desc;

                angular.element('#removeMaterialModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
        }

        function removeMaterialFromList() {

            if (vm.idMaterialToRemove) {

                blockUI.start('Excluíndo Material...');

                materialService.deleteMaterial(vm.idMaterialToRemove).success(function (response) {

                    blockUI.stop();

                    toastr.success(response.message);

                    vm.idMaterialToRemove = 0;

                    loadMaterialList();

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        function removeMaterial() {

            if (vm.material.id) {

                blockUI.start('Excluíndo Material...');

                materialService.deleteMaterial(vm.idMaterialToRemove).success(function (response) {

                    blockUI.stop();

                    toastr.success(response.message);

                    vm.idMaterialToRemove = 0;

                    $window.location.href = "#/materialList";

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        function addPriceResearch() {

            $scope.priceResearchForm.$setSubmitted();

            if ($scope.priceResearchForm.$valid) {

                blockUI.start('Alterando Preço Atual...');

                vm.priceReaserch.material = vm.material;

                vm.priceReaserch.id = 0;
                vm.priceReaserch.material.listPriceResearch = null;

                priceResearchService.save(vm.priceReaserch).success(function (response) {

                    blockUI.stop();
                    toastr.success(response.message);

                    vm.priceReaserch = response.value;

                    addDataToGraphic(vm.priceReaserch);

                }).error(function (response) {

                    blockUI.stop();

                    toastr.error(response.message);
                })
            }
        }

        function addDataToGraphic(priceReaserch) {

            priceReaserch.dateToView = utilityService.convertDateToString(priceReaserch.searchDate);

            //Adiciona as datas no grafico
            vm.labels.push(priceReaserch.dateToView);

            vm.data[0].push(priceReaserch.price);
        }

        function removeDataFromGraphic(priceReaserch) {

            var indexLabel = vm.labels.indexOf(priceReaserch.dateToView);

            var indexPrice = vm.data[0].indexOf(priceReaserch.price);

            if (indexLabel > -1 && indexPrice > -1) {

                vm.labels.splice(indexLabel);
                vm.data.splice(indexPrice);
            }
        }

        function removePrice(priceReaserch) {

            if (priceReaserch) {

                var index = vm.material.listPriceResearch.indexOf(priceReaserch);

                vm.material.listPriceResearch.splice(index, 1);

                removeDataFromGraphic(priceReaserch);
            }
        }
    }

})();