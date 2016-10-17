(function () {

    angular
        .module('app')
        .controller('CompanyController', CompanyController);

    CompanyController.$inject = ['$scope', 'viaCepService', 'valuesService', 'companyService', 'toastr', 'blockUI', 'localStorageService'];

    function CompanyController($scope, viaCepService, valuesService, companyService, toastr, blockUI, localStorageService) {

        //INIT CONTROLS
        angular.element('.ui.dropdown').dropdown();

        angular.element('button').popup({
            on: 'click',
            position: 'right center'
        });

        //INIT VARIABLES
        $scope.defaultLogo = valuesService.getDefaultLogo;
        $scope.userId = localStorageService.get('id');
        $scope.company = {};
        $scope.showHelp = showHelp;
        $scope.userTypes = [

            {
                id: 1,
                desc: 'Pessoa Física'
            },
            {
                id: 2,
                desc: 'Pessoa Jurídica'
            }
        ];

        loadCompany();
        loadOccupationAreas();

        //LOAD INFORMATIONS
        function showHelp() {

            angular.element('.ui.long.modal').modal({

                blurring: false,
                closable: true

            }).modal('show');
        };

        function loadCompany() {

            blockUI.start('Carregando Informações...');

            companyService.getCompanyByUser($scope.userId).success(function (response) {

                blockUI.stop();
                $scope.company = response.value;

                //Caso não exista nenhuma empresa cadastrada para este usuário
                if (!$scope.company) {

                    initObjectCompany();
                }

                defineSaveOrUpdate();

            }).error(function (response) {

                blockUI.stop();
                toastr.error(response.message);

            });
        }

        function initObjectCompany() {

            $scope.company = {

                id: 0,
                eFormatImg: 1,
                ePersonType: 0,
                user: {

                    id: $scope.userId
                },
                occupationArea: {

                    id: 0,
                    description: ''
                },
                address: {},
                contact: {}
            };
        }

        function loadOccupationAreas() {

            companyService.getOccupationAreas().success(function (response) {

                $scope.OccupationAreas = response.valueList;

            }).error(function () {

                console.log('Não foi possivel carregar as Areas de ocupação');
            });
        }

        function defineSaveOrUpdate() {

            if ($scope.company) {

                if ($scope.company.id === 0) {

                    $scope.btnSaveText = 'Salvar';
                }
                else {

                    $scope.btnSaveText = 'Atualizar';
                }
            }
        }

        //$SCOPE METHODS


        $scope.submitForm = function () {

            $scope.companyForm.$setSubmitted();
            $scope.save();
        };

        $scope.save = function () {

            if ($scope.companyForm.$valid) {

                companyService.save($scope.company).success(function (response) {

                    toastr.success(response.message);

                }).error(function (response) {

                    toastr.error(response.message);
                });
            }
        };

        $scope.getAddress = function () {

            blockUI.start('Obtendo Endereço...');

            viaCepService.getAddress($scope.company.address.cep).success(function (response) {

                blockUI.stop();

                $scope.company.address.cep = response.cep;
                $scope.company.address.logradouro = response.logradouro;
                $scope.company.address.complemento = response.complemento;
                $scope.company.address.bairro = response.bairro;
                $scope.company.address.cidade = response.localidade;
                $scope.company.address.estado = response.uf;

            }).error(function (response) {

                blockUI.stop();
                console.log(response);
            });
        };

        $scope.addLogo = function () {

            if ($scope.company.urlPathLogo) {

                companyService.addLogo($scope.company.urlPathLogo, $scope.userId).success(function (response) {

                    debugger;

                }).error(function (response) {

                    debugger;
                });
            }
        };


    }

})();