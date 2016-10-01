(function () {
    
    angular 
        .module('app')
        .controller('CompanyController', CompanyController);

    CompanyController.$inject = ['$scope', 'viaCepService', 'valuesService', 'companyService', 'toastr', 'blockUI','localStorageService'];

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
        $scope.userTypes = [

            {
                Type: "1",
                Desc: 'Pessoa Física'
            },
            {
                Type: "2",
                Desc: 'Pessoa Jurídica'
            }
        ];

        loadCompany();
        loadOccupationAreas();


        //LOAD INFORMATIONS
        function loadCompany() {

            companyService.getCompanyByUser($scope.userId).success(function (response) {

                $scope.company = response.value;

                if (!$scope.company) {

                    initObjectCompany();
                }

            }).error(function (response) {

                toastr.error(response.message);

            });
        }

        function initObjectCompany() {

            $scope.company = {

                eFormatImg: 1,
                ePersonType: '1',
                user: {

                    id: $scope.userId
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

        //METHODS
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